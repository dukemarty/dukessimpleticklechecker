using SimpleTIckleChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleTIckleChecker
{
    class TickleElementViewModel
    {
        #region Properties

        public string TickleDate => m_element.TickleDate.ToString("yyyy-MM-dd");

        public string Name => m_element.Name;

        public ElementType ElementType => m_element.ElementType;

        public bool HasInfoFile => m_element.HasInfoFile;

        public ICommand OpenElementCommand => new DelegateCommand(OpenElement);
        public ICommand OpenDescriptionCommand => new DelegateCommand(OpenDescription);
        public ICommand MoveElementCommand => new DelegateCommand(MoveElementAction);
        public ICommand DeferElementCommand => new DelegateCommand(DeferElementAction);
        public ICommand RemoveElementCommand => new DelegateCommand(RemoveElementAction);

        #endregion Properties

        #region Public interface

        public TickleElementViewModel(ITickleElement element)
        {
            m_element = element;
        }

        public void OpenDescription(object o = null)
        {
            m_element.OpenInformation();
        }

        public void OpenElement(object o = null)
        {
            m_element.OpenElement();
        }

        public bool MoveElement(Window owner)
        {

            return false;
        }

        public void MoveElementAction(object o)
        {
            var owner = o as Window;

            MoveElement(owner);
        }

        public bool DeferElement(Window owner)
        {
            var selector = new UI.TickleDateSelection(Name, TickleDate);

            owner.IsEnabled = false;
            var dialogRes = selector.ShowDialog() ?? false;
            if (!dialogRes)
            {
                owner.IsEnabled = true;
                return false;
            }

            var newDate = selector.ChosenTickleDate;

            m_element.DeferElement(newDate);

            owner.IsEnabled = true;

            return true;
        }

        public void DeferElementAction(object o)
        {
            var owner = o as Window;

            DeferElement(owner);
        }

        public bool RemoveElement(Window owner)
        {
            var resConfirmRemove = MessageBox.Show($"Do you really want to remove tickle '{Name}' permanently?", "Confirm deleting", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
            if (resConfirmRemove != MessageBoxResult.Yes) { return false; }

            m_element.RemoveElement();

            return true;
        }

        public void RemoveElementAction(object o)
        {
            var owner = o as Window;

            RemoveElement(owner);
        }
        #endregion Public interface

        #region Attributes

        private ITickleElement m_element;

        #endregion Attributes
    }
}
