using SimpleTIckleChecker.Model;
using SimpleTIckleChecker.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTIckleChecker
{
    internal class SampleTickle : ITickleElement
    {
        public ElementType ElementType { get; set; }

        public string Name { get; set; }

        public DateTime TickleDate { get; set; }

        public bool HasInfoFile { get; set; }

        public SampleTickle(ElementType type, string name, DateTime tickleDate, bool hasInfoFile)
        {
            ElementType = type;
            Name = name;
            TickleDate = tickleDate;
            HasInfoFile = hasInfoFile;
        }

        public bool DeferElement(DateTime newTickleDate)
        {
            return true;
        }

        public bool MoveElement(string newLocation, bool removeInfoFile = false, bool removeTickleDatePrefix = true)
        {
            return true;
        }

        public bool OpenElement()
        {
            return true;
        }

        public bool OpenInformation()
        {
            return true;
        }
    }

    internal class SampleMainViewModel
    {
        #region Constants

        private List<ITickleElement> ActiveElements = new List<ITickleElement>
        {
            new SampleTickle(ElementType.File, "Bla1", DateTime.Now, true),
            new SampleTickle(ElementType.Directory, "Asdf", DateTime.Now, true),
            new SampleTickle(ElementType.File, "ASdlc nlawkenf", DateTime.Now, false),
            new SampleTickle(ElementType.Link, "adswc", DateTime.Now, true),
        };


        private List<ITickleElement> WaitingElements = new List<ITickleElement>
        {
            new SampleTickle(ElementType.Directory, "aswdcsd", DateTime.Now, true),
            new SampleTickle(ElementType.File, "asdc", DateTime.Now, true),
        };

        #endregion Constants

        #region Properties

        public string VersionText => $"v{Assembly.GetExecutingAssembly().GetName().Version}";

        public ObservableCollection<TickleElementViewModel> ActiveTicklers { get; set; } = new ObservableCollection<TickleElementViewModel>();

        public ObservableCollection<TickleElementViewModel> WaitingTicklers { get; set; } = new ObservableCollection<TickleElementViewModel>();

        #endregion Properties

        public SampleMainViewModel()
        {
            ActiveTicklers = new ObservableCollection<TickleElementViewModel>(ActiveElements.Select(ae => new TickleElementViewModel(ae)));
            WaitingTicklers = new ObservableCollection<TickleElementViewModel>(WaitingElements.Select(ae => new TickleElementViewModel(ae)));
        }
    }

    internal class SampleSettings
    {
        public string InputBackgroundColor { get; set; } = "#96212626";
        public string WindowBackgroundColor { get; set; } = "#CC131616";
        public string TextColor { get; set; } = "#FF00C8C8";
        public string SymbolBackground { get; set; } = "#CC80A33A";
    }

    internal class SampleDataContext
    {
        public SampleMainViewModel vm { get; set; } = new SampleMainViewModel();

        public SampleSettings settings { get; set; } = new SampleSettings();
    }
}
