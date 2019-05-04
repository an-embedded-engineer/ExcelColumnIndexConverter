using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelColumnIndexConverter.Model;
using Reactive.Bindings;

namespace ExcelColumnIndexConverter.Wpf.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private ConverterModel Converter { get; set; }

        public ReactiveProperty<string> InputType { get; }

        public ReactiveProperty<string> OutputType { get; }

        public ReactiveProperty<string> InputText { get; }

        public ReactiveProperty<string> OutputText { get; }

        public MainWindowViewModel()
        {
            this.Converter = new ConverterModel();

            this.InputType = this.Converter.InputType;

            this.OutputType = this.Converter.OutputType;

            this.InputText = this.Converter.InputText;

            this.OutputText = this.Converter.OutputText;
        }

        public void Initialize()
        {

        }
    }
}
