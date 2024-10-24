using System.Windows.Controls;
using System.Windows.Data;

namespace VortexProAppModule.Convertors
{
    public class IndexConverter : IValueConverter
    {
        private int _index = 0;

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {

            var lvi = value as ListViewItem;

            if (lvi != null) {
                ListView lv = ItemsControl.ItemsControlFromItemContainer(lvi) as ListView;
                //index = lv.ItemContainerGenerator.IndexFromContainer(lvi) + 1;
            }

            return $"{++_index}";

        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            // This converter does not provide conversion back from ordinal position to list view item
            throw new System.InvalidOperationException();
        }
    }
}
