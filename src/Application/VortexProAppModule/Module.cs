using ArcGIS.Core.Data;
using ArcGIS.Core.Events;
using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Mapping.Events;
using S100Framework.Catalogues;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace VortexProAppModule
{
    internal class Module : ArcGIS.Desktop.Framework.Contracts.Module
    {
        private static Module _this = null;

        internal static List<string> RegisteredFeatureLayers = new();

        /// <summary>
        /// Retrieve the singleton instance to this module here
        /// </summary>
        public static Module Current => _this ??= (Module)FrameworkApplication.FindModule("VortexProAppModule_Module");

        private SubscriptionToken _tokenActiveMapViewChangedEvent;

        private ImmutableArray<FeatureCatalogue> _featureCatalogues = ImmutableArray<FeatureCatalogue>.Empty;

        public string[] GetFeatureCatalogues() => _featureCatalogues.Select(e => e.ProductID).ToArray();

        public FeatureCatalogue GetFeatureCatalogue(string name) => _featureCatalogues.Single(e => e.ProductID.Equals(name));

        /// <summary>
        /// A new MapView is incoming
        /// </summary>
        /// <param name="args"></param>
        private static async void OnActiveMapViewChanged(ActiveMapViewChangedEventArgs args) {
            Map incomingMap = args?.IncomingView?.Map;
            if (incomingMap == null)
                return;

            foreach (var table in incomingMap.GetStandaloneTablesAsFlattenedList()) {
                if (table.Name.Equals("attributebinding", StringComparison.InvariantCultureIgnoreCase))
                    continue;
                await RegisterStandaloneTableGuidAsync(table);
            }

            // process each layer to see if the layer needs the custom attribute tab
            foreach (var featLayer in incomingMap.GetLayersAsFlattenedList().OfType<FeatureLayer>()) {
                await RegisterFeatureClassGuidAsync(featLayer);
            }
        }

        #region Overrides

        protected override bool Initialize() {
            _tokenActiveMapViewChangedEvent = ActiveMapViewChangedEvent.Subscribe(OnActiveMapViewChanged);
            _featureCatalogues = S100Framework.Catalogues.FeatureCatalogue.Catalogues;

            return base.Initialize();
        }

        protected override void Uninitialize() {
            ActiveMapViewChangedEvent.Unsubscribe(_tokenActiveMapViewChangedEvent);
            base.Uninitialize();
        }

        /// <summary>
        /// Called by Framework when ArcGIS Pro is closing
        /// </summary>
        /// <returns>False to prevent Pro from closing, otherwise True</returns>
        protected override bool CanUnload() {
            //TODO - add your business logic
            //return false to ~cancel~ Application close
            return true;
        }

        #endregion Overrides

        #region Register Guid with Feature Class to add Custom Tab to Edit Attributes Dockpane

        /// <summary>
        /// Register Feature Class with GUID defined in config.daml categories
        /// </summary>
        /// <param name="layer"></param>
        internal static Task RegisterFeatureClassGuidAsync(FeatureLayer layer) {
            return QueuedTask.Run(() => {
                //note: These methods must be called on the Main CIM Thread. Use QueuedTask.Run.
                var fc = layer.GetFeatureClass();
                if (fc is null)
                    return;

                var metadata = layer.GetMetadata();
                if (!metadata.Contains("<keyword>vortex</keyword>"))
                    return;

                var fcName = fc.GetName();
                //if (!fcName.Equals(Module1.TaxParcelPolygonLayerName)) 
                //    return;

                var table = layer.GetTable();

                var join = table.IsJoinedTable() ? table.GetJoin() : default;


                // This Guid defines the "Custom Tab" in the config.daml                
                Guid extension = new("{6a5e0ba6-3da6-4c73-b7c0-e5434a4a100e}");

                if (!fc.GetHasActivationExtension(extension)) {
                    CoreDataExtensions.AddActivationExtension(fc, extension);
                }

                // remember the registration
                if (!RegisteredFeatureLayers.Contains(fcName)) {
                    RegisteredFeatureLayers.Add(fcName);
                }
            });
        }

        /// <summary>
        /// Register Standalone Table with GUID defined in config.daml categories
        /// </summary>
        /// <param name="featureLayer"></param>
        internal static Task RegisterStandaloneTableGuidAsync(StandaloneTable layer) {
            return QueuedTask.Run(() => {
                var table = layer.GetTable();
                if (table is null)
                    return;

                var metadata = layer.GetMetadata();
                if (!metadata.Contains("<keyword>vortex</keyword>"))
                    return;

                var fcName = table.GetName();

                var join = table.IsJoinedTable() ? table.GetJoin() : default;

                // This Guid defines the "Custom Tab" in the config.daml                
                Guid extension = new("{6a5e0ba6-3da6-4c73-b7c0-e5434a4a100e}");

                if (!table.GetHasActivationExtension(extension)) {
                    CoreDataExtensions.AddActivationExtension(table, extension);
                }

                // remember the registration
                if (!RegisteredFeatureLayers.Contains(fcName)) {
                    RegisteredFeatureLayers.Add(fcName);
                }
            });
        }


        #endregion
    }
}
