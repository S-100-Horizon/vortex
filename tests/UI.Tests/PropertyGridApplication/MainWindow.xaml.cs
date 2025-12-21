using S100Framework.Catalogues;
using System.DirectoryServices.ActiveDirectory;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace PropertyGridApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var feature = System.Text.Json.JsonSerializer.Deserialize<S100Framework.DomainModel.S101.FeatureTypes.LightSectored>(json)!;
            //var viewModel = new S100Framework.WPF.ViewModel.S101.LightSectoredViewModel {
            //}.Load(feature);

            var viewModel = new S100Framework.WPF.ViewModel.S101.LateralBuoyViewModel {
            };

            this.MainPropertyGrid.SelectedObject = viewModel;

            // Tilmeld property changed events
            //SubscribeToPropertyChanges(viewModel);
            viewModel.PropertyChanged += (s, ev) => {
                if (!string.IsNullOrEmpty(ev.PropertyName)) {
                    LogMessage($"ViewModel property changed: {ev.PropertyName}");
                    // Send the new value of the property to the log
                    var propInfo = viewModel.GetType().GetProperty(ev.PropertyName);
                    if (propInfo != null) {
                        var newValue = propInfo.GetValue(viewModel);
                        LogMessage($"New value of {ev.PropertyName}: {newValue}");
                    }
                    else {
                        LogMessage($"Property {ev.PropertyName} not found on ViewModel");
                    }
                }
                else {
                    LogMessage($"Property {ev.PropertyName} not found on ViewModel");
                }
;
                if (viewModel.HasErrors) {
                    LogMessage("The model contains errors");
                }
            };

            LogMessage("Application started");
            LogMessage($"Loaded object: {viewModel.GetType().Name}");
        }
    

    private void SubscribeToPropertyChanges(object obj) {
        if (obj is System.ComponentModel.INotifyPropertyChanged notifyPropertyChanged) {
            notifyPropertyChanged.PropertyChanged += (s, e) => {
                if (!string.IsNullOrEmpty(e.PropertyName)) {
                    LogMessage($"Property changed: {e.PropertyName}");
                }
            };
        }

        // Subscribe to collection changes hvis objektet har observable collections
        var properties = obj.GetType().GetProperties();
        foreach (var prop in properties) {
            try {
                var value = prop.GetValue(obj);
                if (value is System.Collections.Specialized.INotifyCollectionChanged notifyCollection) {
                    notifyCollection.CollectionChanged += (s, e) => {
                        if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add) {
                            LogMessage($"Collection '{prop.Name}': Added {e.NewItems?.Count ?? 0} item(s)");
                        }
                        else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove) {
                            LogMessage($"Collection '{prop.Name}': Removed {e.OldItems?.Count ?? 0} item(s)");
                        }
                        else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset) {
                            LogMessage($"Collection '{prop.Name}': Reset");
                        }
                        else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace) {
                            LogMessage($"Collection '{prop.Name}': Replaced {e.OldItems?.Count ?? 0} item(s)");
                        }
                    };

                    // Subscribe to nested items if they are INotifyPropertyChanged
                    if (value is System.Collections.IEnumerable enumerable) {
                        foreach (var item in enumerable) {
                            //                                if (item != null && item.GetType().IsClass && item.GetType() != typeof(string))
                            //                                {
                            SubscribeToPropertyChanges(item);
                            //                                }
                        }
                    }
                }
            }
            catch (Exception ex) {
                // Ignorer fejl ved at læse properties
                System.Diagnostics.Debug.WriteLine($"Error subscribing to property {prop.Name}: {ex.Message}");
            }
        }
    }

    private void LogMessage(string message) {
        var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
        var logEntry = $"[{timestamp}] {message}\n";

        // Ensure we're on the UI thread
        Dispatcher.Invoke(() => {
            ChangeLogTextBox.AppendText(logEntry);
            ChangeLogTextBox.ScrollToEnd();
        });
    }

    private void ClearLog_Click(object sender, RoutedEventArgs e) {
        ChangeLogTextBox.Clear();
        LogMessage("Log cleared");
    }

    private void SaveLog_Click(object sender, RoutedEventArgs e) {
        var saveDialog = new SaveFileDialog {
            Filter = "Text files (*.txt)|*.txt|Log files (*.log)|*.log|All files (*.*)|*.*",
            DefaultExt = "txt",
            FileName = $"ChangeLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
        };

        if (saveDialog.ShowDialog() == true) {
            try {
                File.WriteAllText(saveDialog.FileName, ChangeLogTextBox.Text);
                LogMessage($"Log saved to: {saveDialog.FileName}");
                MessageBox.Show($"Log saved successfully to:\n{saveDialog.FileName}",
                    "Save Successful", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show($"Error saving log:\n{ex.Message}",
                    "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    const string json = "{\"categoryOfLight\":[],\"exhibitionConditionOfLight\":null,\"featureName\":[],\"fixedDateRange\":null,\"height\":11,\"interoperabilityIdentifier\":null,\"marksNavigationalSystemOf\":null,\"multiplicityOfFeatures\":null,\"periodicDateRange\":[],\"sectorCharacteristics\":[{\"lightCharacteristic\":7,\"lightSector\":[{\"colour\":[1],\"directionalCharacter\":null,\"lightVisibility\":[],\"sectorLimit\":{\"sectorLimitOne\":{\"sectorBearing\":158,\"sectorLineLength\":null},\"sectorLimitTwo\":{\"sectorBearing\":171,\"sectorLineLength\":null}},\"valueOfNominalRange\":11,\"sectorInformation\":[],\"sectorArcExtension\":null}],\"signalGroup\":[\"(1)\"],\"signalPeriod\":4,\"signalSequence\":[]},{\"lightCharacteristic\":7,\"lightSector\":[{\"colour\":[3],\"directionalCharacter\":null,\"lightVisibility\":[],\"sectorLimit\":{\"sectorLimitOne\":{\"sectorBearing\":171,\"sectorLineLength\":null},\"sectorLimitTwo\":{\"sectorBearing\":290,\"sectorLineLength\":null}},\"valueOfNominalRange\":8.5,\"sectorInformation\":[],\"sectorArcExtension\":null}],\"signalGroup\":[\"(1)\"],\"signalPeriod\":4,\"signalSequence\":[]},{\"lightCharacteristic\":7,\"lightSector\":[{\"colour\":[4],\"directionalCharacter\":null,\"lightVisibility\":[],\"sectorLimit\":{\"sectorLimitOne\":{\"sectorBearing\":110,\"sectorLineLength\":null},\"sectorLimitTwo\":{\"sectorBearing\":158,\"sectorLineLength\":null}},\"valueOfNominalRange\":8.5,\"sectorInformation\":[],\"sectorArcExtension\":null}],\"signalGroup\":[\"(1)\"],\"signalPeriod\":4,\"signalSequence\":[]}],\"signalGeneration\":null,\"status\":[],\"verticalDatum\":null,\"scaleMinimum\":179999,\"information\":[]}";
}
}