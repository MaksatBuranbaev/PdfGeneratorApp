using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using PdfGenerator.Services;
using PdfGeneratorApp.Data;
using PdfGeneratorApp.Models;

namespace PdfGeneratorApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _inputText;
        private string _labelText;
        private DataLoaderService _dataLoader;
        private PdfGeneratorService _pdfGenerator;

        public MainViewModel()
        {
            _dataLoader = new DataLoaderService();
            _pdfGenerator = new PdfGeneratorService();
        }

        public string InputText
        {
            get { return _inputText; }
            set
            {
                _inputText = value;
                LabelText = value;
                OnPropertyChanged(nameof(InputText));
            }
        }

        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                OnPropertyChanged(nameof(LabelText));
            }
        }

        public ICommand PrintCommand => new RelayCommand(async () => await Print());

        private async Task Print()
        {
            string headerTitle = InputText;
            string pdfPath = $"{InputText}.pdf";

            var data = await _dataLoader.LoadPeopleAsync();

            if (data.Count == 0)
            {
                Console.WriteLine("Нет данных для генерации PDF.");
                return;
            }

            _pdfGenerator.GeneratePdf(headerTitle, data, pdfPath);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

