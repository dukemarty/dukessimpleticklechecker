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
using System.Windows.Shapes;

namespace SimpleTIckleChecker.UI
{
    /// <summary>
    /// Interaktionslogik für TickleDateSelection.xaml
    /// </summary>
    public partial class TickleDateSelection : Window
    {
        public string ElementName { get; set; }
        public string ChosenTickleDate { get; set; }

        public TickleDateSelection(string element, string oldTickleDate)
        {
            InitializeComponent();

            ElementName = element;
            ChosenTickleDate = oldTickleDate;

            DataContext = new
            {
                settings = Settings.Default,
                vm = this,
            };

            PreviewKeyDown += HandleEscapeKey;
            PreviewKeyDown += HandleEnterKey;
            PreviewKeyDown += HandleActionKeys;
        }

        private void HandleEscapeKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                DialogResult = false;
                Close();
            }
        }

        private void HandleEnterKey(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                DialogResult = true;
                Close();


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
            }
        }

        private void HandleActionKeys(object sender, KeyEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case Key.I:
            //        if (ActiveTicklesList.SelectedIndex == -1) { return; }
            //        if ((ActiveTicklesList.SelectedItem as TickleElementViewModel).HasInfoFile)
            //        {
            //            (ActiveTicklesList.SelectedItem as TickleElementViewModel).OpenDescription();
            //        }
            //        else
            //        {
            //            MessageBox.Show($"Unfortunately, no information file available for '{(ActiveTicklesList.SelectedItem as TickleElementViewModel).Name}'.", "Information", MessageBoxButton.OK);
            //        }
            //        break;
            //    case Key.O:
            //        if (ActiveTicklesList.SelectedIndex == -1) { return; }
            //        (ActiveTicklesList.SelectedItem as TickleElementViewModel).OpenElement();
            //        break;
            //    case Key.M:
            //        if (ActiveTicklesList.SelectedIndex == -1) { return; }
            //        MessageBox.Show("'M' pressed.", "Information", MessageBoxButton.OK);
            //        break;
            //    case Key.D:
            //        if (ActiveTicklesList.SelectedIndex == -1) { return; }
            //        (ActiveTicklesList.SelectedItem as TickleElementViewModel).DeferElement(this);
            //        MessageBox.Show("'D' pressed.", "Information", MessageBoxButton.OK);
            //        break;
            //    default:
            //        // ignore all other keys
            //        break;
            //}
        }
    }
}
