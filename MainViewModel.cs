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

        public float ObjectX {
            set; get;
        }

        public float ObjectY {
            set; get;
        }

        public float ObjectZ {
            set; get;
        }

        public float ScaleX {
            set; get;
        }

        public float ScaleY {
            set; get;
        }

        public float ScaleZ {
            set; get;
        }

        public float RotationX {
            set; get;
        }

        public float RotationY {
            set; get;
        }

        public float RotationZ {
            set; get;
        }
    }
}
