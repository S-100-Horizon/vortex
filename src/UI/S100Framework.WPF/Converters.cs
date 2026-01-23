namespace S100Framework.WPF.Converters
{
#if TRISTATE
    public class TristateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            //if (value is Tristate<Enum> tristateValue) {
            //    if (tristateValue.HasValue)
            //        return tristateValue.Value;
            //    return string.Empty;
            //}
            if (value is TristateStatus tristateStatus) {
                return tristateStatus == (TristateStatus)parameter;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            string? strValue = value as string;

            // If the textbox is empty, we interpret it as the Null state.
            if (string.IsNullOrEmpty(strValue)) {
                return Tristate<string>.Null;
            }

            // Otherwise, it's a value.
            // NOTE: With this simple converter, there's no way for the user to input the "Unknown" state.
            return new Tristate<string>(strValue);
        }
    }
#endif
}
