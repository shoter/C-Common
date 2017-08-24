using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.Commands
{
    public class ActionCommand<T> : ICommand
    {
        public Predicate<T> CanExecuteDelegate { get; set; }
        public Action<T> ExecuteDelegate { get; set; }

        #region ICommand Members

        public ActionCommand() { }
        public ActionCommand(Predicate<T> canExecuteDelegate, Action<T> executeDelegate)
        {
            CanExecuteDelegate = canExecuteDelegate;
            ExecuteDelegate = executeDelegate;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null && parameter.GetType() != typeof(T))
                throw new Exception("Wrong type!");

            if (CanExecuteDelegate != null)
                return CanExecuteDelegate((T)parameter);
            return true;// if there is no can execute default to true
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            
            if (parameter != null && parameter.GetType() != typeof(T))
                throw new Exception("Wrong type!");

            if (ExecuteDelegate != null)
                ExecuteDelegate((T)parameter);
        }

        #endregion
    }
}
