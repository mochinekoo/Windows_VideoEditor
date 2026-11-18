using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Windows_VideoEditor {
    public class Command : ICommand {

        private readonly Action action;
        public event EventHandler? CanExecuteChanged;

        public Command(Action action) {
            this.action = action;
        }

        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            action();
        }
    }
}
