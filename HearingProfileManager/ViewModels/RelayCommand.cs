using System;
using System.Windows.Input;

namespace HearingProfileManager.ViewModels
{
    // RelayCommand lets us bind buttons to methods in ViewModel
    public class RelayCommand : ICommand
    {
        private readonly Action execute;

        public RelayCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            execute();
        }

        public event EventHandler CanExecuteChanged;
    }
}