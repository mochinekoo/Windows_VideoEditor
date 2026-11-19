using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VorticeDirectX_Sample;

namespace Windows_VideoEditor {
    /// <summary>
    /// SaveWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SaveWindow : Window {
        public SaveWindow() {
            InitializeComponent();
            DataContext = new SaveViewModel(this);
        }
    }
}
