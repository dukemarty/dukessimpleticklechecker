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

        public ICommand OpenElementCommand { get; set; }
        public ICommand OpenDescriptionCommand { get; set; }

        #endregion Properties

        #region Public interface

        public TickleElementViewModel(ITickleElement element)
        {
            m_element = element;
        }

        public void OpenDescription()
        {
            m_element.OpenInformation();
        }

        public void OpenElement()
        {
            m_element.OpenElement();
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

        #endregion Public interface

        #region Attributes

        private ITickleElement m_element;

        #endregion Attributes
    }
}
