using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using VorticeDirectX_Sample;
using Windows_VideoEditor;

namespace Windows_VideoEditor {
    public class SaveViewModel : INotifyPropertyChanged {

        public event PropertyChangedEventHandler? PropertyChanged;
        private SaveWindow? saveWindow;

        public ICommand FileChooseButton {
            get; set;
        }

        public ICommand SaveButton {
            get; set;
        }

        public SaveViewModel(SaveWindow window) {
            this.saveWindow = window;
            this.FileChooseButton = new Command(RunFileChooseButton);
            this.SaveButton = new Command(RunSaveCommand);
        }

        public void RunFileChooseButton() {
            var dialog = new Microsoft.Win32.SaveFileDialog {
                DefaultExt = ".txt",
                Filter = "動画ファイル (.mp4)|*.mp4"
            };
            bool? result = dialog.ShowDialog();
            if (result == true) {
                saveWindow.FileNameBox.Text = dialog.FileName;
            }
        }

        public void RunSaveCommand() {
            var desc = Render.DX3D.Texture2D.Description;
            int width = (int) desc.Width;
            int height = (int)desc.Height;
            Render.Encoder.Save(saveWindow.FileNameBox.Text, Render.NowPixel, width, height);
        } 
    }
}
