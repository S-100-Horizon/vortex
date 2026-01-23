using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace S100Framework.WPF.Validation
{
    public class TruncatedDateRule : ValidationRule
    {
        private static readonly Regex _regexValidation = new(@"^(\d{4}|-{4})(\d{2}|-{2})(\d{2}|-{2})$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo) {
            var s = (value as string) ?? string.Empty;
            return _regexValidation.IsMatch(s) ? ValidationResult.ValidResult
                : new ValidationResult(false, "Must be yyyyMMdd, but yyyy, MM or dd may be all \"-\".");
        }
    }
}
