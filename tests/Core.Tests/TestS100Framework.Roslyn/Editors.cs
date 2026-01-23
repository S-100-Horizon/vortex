using System.Collections;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace S100Framework.WPF.Editors
{
    public abstract class ValidatingEditor<T> : ITypeEditor where T : struct
    {
        public virtual FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }

    public abstract class ValidatingUnknownEditor<T> : ValidatingEditor<T> where T : struct
    {
    }

    public abstract class HorizonEditor : ITypeEditor
    {
        public abstract FrameworkElement ResolveEditor(PropertyItem propertyItem);
    }

    public class HorizonEditor<T> : HorizonEditor where T : class
    {
        public override FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }

    public abstract class BindingRoleEditor : ComboBoxEditor
    {
    }

    public class InformationBindingRoleEditor : BindingRoleEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }

    public class FeatureBindingRoleEditor : BindingRoleEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }

    public abstract class BindingLinkEditor : ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }

        private void Control_ContextMenuOpening(object sender, ContextMenuEventArgs e) {
            throw new NotImplementedException();
        }
    }

    public class InformationBindingLinkEditor : BindingLinkEditor
    {

    }

    public class FeatureBindingLinkEditor : BindingLinkEditor
    {

    }


    public class S100TruncatedDateEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }

    public class EnumComboBoxEditor : ComboBoxEditor
    {
        protected override IEnumerable CreateItemsSource(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }

    public class UnknownCodeListEditor : Xceed.Wpf.Toolkit.PropertyGrid.Editors.ITypeEditor
    {
        public FrameworkElement ResolveEditor(PropertyItem propertyItem) {
            throw new NotImplementedException();
        }
    }
}
