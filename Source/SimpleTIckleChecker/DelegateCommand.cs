using System;
using System.Windows.Input;

namespace SimpleTIckleChecker
{
    class DelegateCommand : ICommand
    {
        #region Properties
        public event EventHandler CanExecuteChanged;
        #endregion Properties

        #region Public interface
        public DelegateCommand(Action<object> execute) : this(execute, null) { }

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            m_canExecute = canExecute;
            m_execute = execute;
        }

        public bool CanExecute(object parameter)
        {
            if (m_canExecute == null)
            {
                return true;
            }

            return m_canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            m_execute(parameter);
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #endregion Public interface

        #region Attributes

        private readonly Predicate<object> m_canExecute;

        private readonly Action<object> m_execute;

        #endregion Attributes
    }
}
