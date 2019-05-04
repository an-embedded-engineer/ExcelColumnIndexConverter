using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Reactive.Bindings;

namespace ExcelColumnIndexConverter.Model
{
    public class ConverterModel : NotificationObject
    {
        public ReactiveProperty<string> InputType { get; }

        public ReactiveProperty<string> OutputType { get; }

        public ReactiveProperty<string> InputText { get; }

        public ReactiveProperty<string> OutputText { get; }

        public ConverterModel()
        {
            this.InputType = new ReactiveProperty<string>("");

            this.OutputType = new ReactiveProperty<string>("");

            this.InputText = new ReactiveProperty<string>("").SetValidateNotifyError(x => this.ValidateInput(x));

            this.OutputText = new ReactiveProperty<string>("").SetValidateNotifyError(x => this.ValidateOutput(x));

            this.InputText.Subscribe(_ => this.Convert());
        }

        private string ValidateInput(string x)
        {
            if (string.IsNullOrWhiteSpace(x))
            {
                return "ラベル名またはインデックスを入力してください";
            }
            else
            {
                if (!Regex.IsMatch(x, ColumnIndexConverter.LabelPattern) && !Regex.IsMatch(x, ColumnIndexConverter.IndexPattern))
                {
                    return "無効な入力値です";
                }
                else
                {
                    return null;
                }
            }
        }

        private string ValidateOutput(string x)
        {
            if (x == null)
            {
                return "出力値がnullです";
            }
            else
            {
                if (!Regex.IsMatch(x, ColumnIndexConverter.LabelPattern) && !Regex.IsMatch(x, ColumnIndexConverter.IndexPattern) && x != string.Empty)
                {
                    return "無効な出力値です";
                }
                else
                {
                    return null;
                }
            }
        }

        private void Convert()
        {
            this.InputText.Value = this.InputText.Value.ToUpper();

            if (!this.InputText.HasErrors)
            {
                var input = this.InputText.Value;

                if (Regex.IsMatch(input, ColumnIndexConverter.LabelPattern))
                {
                    this.OutputText.Value = ColumnIndexConverter.ConvertLabelToIndex(input);
                    this.InputType.Value = "ラベル名";
                    this.OutputType.Value = "インデックス";
                }
                else if (Regex.IsMatch(input, ColumnIndexConverter.IndexPattern))
                {
                    this.OutputText.Value = ColumnIndexConverter.ConvertIndexToLabel(input);
                    this.InputType.Value = "インデックス";
                    this.OutputType.Value = "ラベル名";
                }
                else
                {
                    this.Clear();
                }
            }
            else
            {
                this.Clear();
            }
        }

        private void Clear()
        {
            this.InputType.Value = string.Empty;
            this.OutputType.Value = string.Empty;
            this.OutputText.Value = string.Empty;
        }
    }
}
