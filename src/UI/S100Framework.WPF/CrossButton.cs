using System.Windows;
using System.Windows.Controls;

namespace S100Framework.WPF
{
    public class CrossButton : Button
    {
        /// <summary>
        /// Initializes the <see cref="CrossButton"/> class.
        /// </summary>
        static CrossButton() {
            //  Set the style key, so that our control template is used.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CrossButton), new FrameworkPropertyMetadata(typeof(CrossButton)));
        }
    }
}
