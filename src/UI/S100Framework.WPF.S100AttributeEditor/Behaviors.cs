using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace S100Framework.WPF
{
    public class SelectionChangedBehavior : Behavior<ComboBox>
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(SelectionChangedBehavior));

        public ICommand Command {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (AssociatedObject.SelectedItem != null) {
                if (Command?.CanExecute(AssociatedObject.SelectedItem) == true) {
                    Command.Execute(AssociatedObject.SelectedItem);

                    AssociatedObject.SelectedItem = null;
                }
            }

            if (sender is ComboBox comboBox) {
                comboBox.Items.Refresh();
            }
        }
    }

    public class ClickedBehavior : Behavior<Button>
    {
        public class DeleteAttributeCommandEventArgs(object? parameter, object? parent)
        {
            public object? parameter { get; } = parameter;
            public object? parent { get; } = parent;
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(ClickedBehavior));

        public ICommand Command {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.Register(nameof(Parameter), typeof(object), typeof(ClickedBehavior), new PropertyMetadata(null));

        public object? Parameter { 
            get => GetValue(ParameterProperty); 
            set => SetValue(ParameterProperty, value); 
        }

        public static readonly DependencyProperty ParentProperty =
            DependencyProperty.Register(nameof(Parent), typeof(object), typeof(ClickedBehavior), new PropertyMetadata(null));

        public object? Parent {
            get => GetValue(ParentProperty);
            set => SetValue(ParentProperty, value);
        }

        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.Click += OnClicked;
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            AssociatedObject.Click -= OnClicked;
        }

        private void OnClicked(object sender, RoutedEventArgs e) {
            if (this.Parameter != null) {
                if (Command?.CanExecute(this.Parameter) == true) {
                    Command.Execute(new DeleteAttributeCommandEventArgs(this.Parameter, this.Parent));
                }
            }
        }
    }
}
