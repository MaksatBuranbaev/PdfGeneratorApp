using System.Windows;
using PdfGeneratorApp.ViewModels;

namespace PdfGeneratorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}