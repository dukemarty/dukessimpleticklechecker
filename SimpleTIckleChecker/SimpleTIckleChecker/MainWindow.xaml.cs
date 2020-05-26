using SimpleTIckleChecker.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleTIckleChecker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            vm = new MainWindowViewModel(this);
            DataContext = new
            {
                vm,
                settings = Settings.Default
            };

            PreviewKeyDown += HandleEscapeKey;
            PreviewKeyDown += HandleEnterKey;
            PreviewKeyDown += HandleActionKeys;

            Loaded += (sender, e) => MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
        }

        private void HandleEscapeKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void HandleEnterKey(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter || e.Key == Key.Return)
            //{
            //    object focusObj = FocusManager.GetFocusedElement(this);
            //    if (focusObj != null && focusObj is TextBox)
            //    {
            //        var binding = (focusObj as TextBox).GetBindingExpression(TextBox.TextProperty);

            //        if (binding != null)
            //        {
            //            binding.UpdateSource();
            //        }
            //    }

            //    if (vm.InstallNewProject())
            //    {
            //        Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Template could not be installed with the given parameters.", "Error", MessageBoxButton.OK);
            //    }
            //}
        }

        private void HandleActionKeys(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.I:
                    if (ActiveTicklesList.SelectedIndex > -1 && (ActiveTicklesList.SelectedItem as TickleElementViewModel).HasInfoFile)
                    {
                        (ActiveTicklesList.SelectedItem as TickleElementViewModel).OpenDescription();
                    }
                    else
                    {
                        MessageBox.Show($"Unfortunately, no information file available for '{(ActiveTicklesList.SelectedItem as TickleElementViewModel).Name}'.", "Information", MessageBoxButton.OK);
                    }
                    break;
                case Key.O:
                    MessageBox.Show("'O' pressed.", "Information", MessageBoxButton.OK);
                    break;
                case Key.M:
                    MessageBox.Show("'M' pressed.", "Information", MessageBoxButton.OK);
                    break;
                case Key.D:
                    MessageBox.Show("'D' pressed.", "Information", MessageBoxButton.OK);
                    break;
                default:
                    // ignore all other keys
                    break;
            }
        }

        public void ExitWithError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK);
            Close();
        }

        MainWindowViewModel vm;
    }
}
