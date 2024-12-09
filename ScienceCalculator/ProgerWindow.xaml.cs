using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScienceCalculator
{
    /// <summary>
    /// Логика взаимодействия для ProgerWindow.xaml
    /// </summary>
    public partial class ProgerWindow : Window
    {
        public ProgerWindow()
        {
            InitializeComponent();
        }
        private void ConvertToBinary_Click(object sender, RoutedEventArgs e)
        {
            ConvertAndDisplay(2);
        }

        private void ConvertToOctal_Click(object sender, RoutedEventArgs e)
        {
            ConvertAndDisplay(8);
        }

        private void ConvertToDecimal_Click(object sender, RoutedEventArgs e)
        {
            ConvertAndDisplay(10);
        }

        private void ConvertToHexadecimal_Click(object sender, RoutedEventArgs e)
        {
            ConvertAndDisplay(16);
        }

        
        private void ConvertAndDisplay(int targetBase)
        {
            string input = resultInp.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Введите число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
               
                int inputBase = DetectBase(input);
                int decimalValue = ConvertToDecimal(input, inputBase);
                string result = ConvertFromDecimal(decimalValue, targetBase);

                resultInp.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Неверный ввод", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

      
        private int DetectBase(string input)
        {
            if (input.StartsWith("0x") || input.StartsWith("0X")) return 16; 
            if (input.StartsWith("0") && input.Length > 1 && input.All(c => char.IsDigit(c))) return 8; 
            if (input.All(c => c == '0' || c == '1')) return 2;
            return 10;
        }

        
        private int ConvertToDecimal(string input, int baseOfInput)
        {
            if (baseOfInput == 16)
                input = input.Replace("0x", "").Replace("0X", ""); 

            return Convert.ToInt32(input, baseOfInput);
        }

       
        private string ConvertFromDecimal(int decimalValue, int targetBase)
        {
            if (targetBase == 2)
            {
                return Convert.ToString(decimalValue, 2);
            }
            else if (targetBase == 8)
            {
                return Convert.ToString(decimalValue, 8);
            }
            else if (targetBase == 10)
            {
                return decimalValue.ToString();
            }
            else if (targetBase == 16)
            {
                return Convert.ToString(decimalValue, 16).ToUpper();
            }
            else
            {
                throw new NotSupportedException("Неподдерживаемая система счисления");
            }
        }
    }
}
