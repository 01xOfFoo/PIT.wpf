using System;
using System.Windows.Input;

namespace PIT.WPF.Commands
{
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private bool CanExecute
        {
            get
            {
                return true;
            }
        }

        public abstract void Execute(object parameter);

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute;
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
