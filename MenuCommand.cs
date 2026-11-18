using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using VorticeDirectX_Sample;

namespace Windows_VideoEditor {
    public class MenuCommand {

        private readonly MainViewModel mainViewModel;

        public ICommand ExitCommand {
            get; private set;
        }

        public ICommand SaveCommand {
            get; private set;
        }

        public MenuCommand(MainViewModel mainViewModel) {
            this.mainViewModel = mainViewModel;
            ExitCommand = new Command(RunExitCommand);
            SaveCommand = new Command(RunSaveCommand);
        }

        public void RunSaveCommand() {
            new SaveWindow().Show();
        }

        public void RunExitCommand() {
            Application.Current.Shutdown(0);
        }

    }
}
