using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExcelColumnIndexConverter.Model
{
    public static class ColumnIndexConverter
    {
        public const ulong AlphabetNum = ('Z' - 'A' + 1ul);

        public const string LabelPattern = @"^[A-Z]+$";

        public const string IndexPattern = @"^[1-9][0-9]*$";

        public static string ConvertLabelToIndex(string label)
        {
            if (!Regex.IsMatch(label, LabelPattern))
            {
                throw new ArgumentException($"無効なラベル名です : {label}");
            }
            else
            {
                var index = 0ul;

                var n = 1ul;

                var array = label.ToList();

                array.Reverse();

                foreach (var c in array)
                {
                    index += ((ulong)(c - 'A') + 1ul) * n;
                    n *= ColumnIndexConverter.AlphabetNum;
                }

                return $"{index}";
            }
        }

        public static string ConvertIndexToLabel(string index)
        {
            if (!Regex.IsMatch(index, IndexPattern))
            {
                throw new ArgumentException($"無効なインデックスです : {index}");
            }
            else
            {
                var value = ulong.Parse(index);

                if (value <= 0)
                {
                    throw new ArgumentException($"無効なインデックスです : {index}");
                }
                else
                {
                    var label = string.Empty;

                    var a = ColumnIndexConverter.AlphabetNum;

                    while (value > 0)
                    {
                        value--;

                        var c = (char)('A' + (value % a));

                        label = $"{c}{label}";

                        value /= a;
                    }

                    return label;
                }
            }
        }
    }
}
