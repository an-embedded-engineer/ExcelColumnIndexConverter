using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelColumnIndexConverter.Model;

namespace ExcelColumnIndexConverter.CLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            var converter = new ConverterModel();

            while (true)
            {
                Console.Write(">");

                var input = Console.ReadLine();

                if (input == "exit")
                {
                    break;
                }
                else
                {
                    converter.InputText.Value = input;

                    if(converter.HasError.Value != true)
                    {
                        Console.WriteLine($"Input Type : {converter.InputType.Value}");

                        Console.WriteLine($"Output Type : {converter.OutputType.Value}");

                        Console.WriteLine($"Output Text : {converter.OutputText.Value}");
                    }
                    else
                    {
                        Console.WriteLine($"Error : {converter.ErrorMessage.Value}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
