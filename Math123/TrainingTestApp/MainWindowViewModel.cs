using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TrainingTestApp
{
    public class Command : ICommand
    {
        private Action<object> commandAction; 
        public Command(Action<object> commandAction)
        {
            this.commandAction = commandAction;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandAction(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }

    public class MainWindowViewModel
    {
        public ICommand PrimeNumbers { get { return new Command(o=> MessageBox.Show("Простые числа")); } }
    }
}
