using SimpleTIckleChecker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTIckleChecker
{
    class TickleElementViewModel
    {
        #region Properties

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

        #endregion Public interface

        #region Attributes

        private ITickleElement m_element;

        #endregion Attributes
    }
}
