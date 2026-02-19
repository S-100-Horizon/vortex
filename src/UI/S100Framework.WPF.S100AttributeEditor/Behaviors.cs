using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace S100Framework.WPF
{
    public class SelectionChangedBehaviorEventArgs {
        public object? SelectedItem { get; set; }

        public object? Parameter { get; set; }
    }

    public class SelectionChangedBehavior : Behavior<ComboBox>
    {
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(SelectionChangedBehavior));

        public ICommand Command {
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.Register(nameof(Parameter), typeof(object), typeof(SelectionChangedBehavior));

        public object? Parameter {
            get => (object?)this.GetValue(ParameterProperty);
            set => this.SetValue(ParameterProperty, value);
        }

        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += this.OnSelectionChanged;            
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            this.AssociatedObject.SelectionChanged -= this.OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (this.AssociatedObject.SelectedItem != null) {
                if (this.Command?.CanExecute(this.AssociatedObject.SelectedItem) == true) {
                    //this.Command.Execute(this.AssociatedObject.SelectedItem);
                    this.Command.Execute(new SelectionChangedBehaviorEventArgs {
                        SelectedItem = this.AssociatedObject.SelectedItem,
                        Parameter = this.Parameter,
                    });

                    this.AssociatedObject.SelectedItem = null;
                }
            }

            //if (sender is ComboBox comboBox) {
            //    comboBox.Items.Refresh();
            //}
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
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.Register(nameof(Parameter), typeof(object), typeof(ClickedBehavior), new PropertyMetadata(null));

        public object? Parameter {
            get => this.GetValue(ParameterProperty);
            set => this.SetValue(ParameterProperty, value);
        }

        public static readonly DependencyProperty ParentProperty =
            DependencyProperty.Register(nameof(Parent), typeof(object), typeof(ClickedBehavior), new PropertyMetadata(null));

        public object? Parent {
            get => this.GetValue(ParentProperty);
            set => this.SetValue(ParentProperty, value);
        }

        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.Click += this.OnClicked;
        }

        protected override void OnDetaching() {
            base.OnDetaching();
            this.AssociatedObject.Click -= this.OnClicked;
        }

        private void OnClicked(object sender, RoutedEventArgs e) {
            if (this.Parameter != null) {
                if (this.Command?.CanExecute(this.Parameter) == true) {
                    this.Command.Execute(new DeleteAttributeCommandEventArgs(this.Parameter, this.Parent));
                }
            }
        }
    }
}
