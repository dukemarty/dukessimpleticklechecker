using SimpleTIckleChecker.Model;
using SimpleTIckleChecker.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTIckleChecker
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Properties

        public string VersionText => $"v{Assembly.GetExecutingAssembly().GetName().Version}";

        public ObservableCollection<TickleElementViewModel> ActiveTicklers { get; set; } = new ObservableCollection<TickleElementViewModel>();

        public ObservableCollection<TickleElementViewModel> WaitingTicklers { get; set; } = new ObservableCollection<TickleElementViewModel>();

        #endregion Properties

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="window">assigned m_window for this vm</param>
        public MainWindowViewModel(MainWindow window)
        {
            m_settings = SimpleTIckleCheckerConfiguration.LoadOrDefaultSettings(Resources.ConfigFilename);

            m_tickleFolder = new TickleFolder(m_settings.TicklePath);

            var today = DateTime.Now;
            ActiveTicklers = new ObservableCollection<TickleElementViewModel>(m_tickleFolder.Elements.Where(e => e.TickleDate <= today).Select(te => new TickleElementViewModel(te)));
            WaitingTicklers = new ObservableCollection<TickleElementViewModel>(m_tickleFolder.Elements.Where(e => e.TickleDate > today).Select(te => new TickleElementViewModel(te)));
        }

        #region Private methods

        #endregion Private methods


        public void NotifyPropertyChanged(string propName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));


        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Events

        #region Attributes

        private readonly SimpleTIckleCheckerConfiguration m_settings;

        private TickleFolder m_tickleFolder;

        #endregion Attributes
    }
}
