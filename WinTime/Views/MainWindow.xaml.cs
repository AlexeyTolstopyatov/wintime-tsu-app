using MicaWPF.Controls;
using Wpf.Ui.Appearance;

namespace WinTime.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MicaWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationThemeManager.ApplySystemTheme();
        }
    }
}