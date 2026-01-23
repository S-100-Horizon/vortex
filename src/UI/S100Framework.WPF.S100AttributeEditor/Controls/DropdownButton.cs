using System.Windows;
using System.Windows.Controls;

namespace S100Framework.WPF.Controls
{
    public class DropdownButton : ContentControl
    {
        static DropdownButton() {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DropdownButton),
                new FrameworkPropertyMetadata(typeof(DropdownButton)));
        }

        public object DropdownContent {
            get => this.GetValue(DropdownContentProperty);
            set => this.SetValue(DropdownContentProperty, value);
        }

        public static readonly DependencyProperty DropdownContentProperty =
            DependencyProperty.Register(nameof(DropdownContent),
                typeof(object), typeof(DropdownButton));

        public bool IsOpen {
            get => (bool)this.GetValue(IsOpenProperty);
            set => this.SetValue(IsOpenProperty, value);
        }

        public static readonly DependencyProperty IsOpenProperty =
            DependencyProperty.Register(nameof(IsOpen),
                typeof(bool), typeof(DropdownButton));
    }



    //public class DropdownButton : Control
    //{
    //    static DropdownButton() {
    //        DefaultStyleKeyProperty.OverrideMetadata(
    //            typeof(DropdownButton),
    //            new FrameworkPropertyMetadata(typeof(DropdownButton)));
    //    }

    //    public object DropdownContent {
    //        get => GetValue(DropdownContentProperty);
    //        set => SetValue(DropdownContentProperty, value);
    //    }

    //    public static readonly DependencyProperty DropdownContentProperty =
    //        DependencyProperty.Register(nameof(DropdownContent),
    //            typeof(object), typeof(DropdownButton));

    //    public bool IsOpen {
    //        get => (bool)GetValue(IsOpenProperty);
    //        set => SetValue(IsOpenProperty, value);
    //    }

    //    public static readonly DependencyProperty IsOpenProperty =
    //        DependencyProperty.Register(nameof(IsOpen),
    //            typeof(bool), typeof(DropdownButton));
    //}
}
