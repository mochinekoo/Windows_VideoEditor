using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;

namespace Windows_VideoEditor {
    public class MainViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler? PropertyChanged;

        private MainWindow? mainWindow_ = null;
        public MenuCommand MenuCommand {
            private set; get;
        }

        public MainViewModel(MainWindow main) {
            this.mainWindow_ = main;
            this.MenuCommand = new MenuCommand(this);
        }
    }
}
