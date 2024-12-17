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
    public partial class CountWindow : Window
    {
        public CountWindow()
        {
            InitializeComponent();
        }
        private void BinaryCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(BinaryInput1.Text, 2);
                int num2 = Convert.ToInt32(BinaryInput2.Text, 2);
                int result = PerformOperation(num1, num2, BinaryOperation.Text);
                BinaryResult.Text = Convert.ToString(result, 2);
            }
            catch
            {
                BinaryResult.Text = "Ошибка ввода!";
            }
        }

       
        private void OctalCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(OctalInput1.Text, 8);
                int num2 = Convert.ToInt32(OctalInput2.Text, 8);
                int result = PerformOperation(num1, num2, OctalOperation.Text);
                OctalResult.Text = $"Результат: {Convert.ToString(result, 8)}";
            }
            catch
            {
                OctalResult.Text = "Ошибка ввода!";
            }
        }

       
        private void HexCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num1 = Convert.ToInt32(HexInput1.Text, 16);
                int num2 = Convert.ToInt32(HexInput2.Text, 16);
                int result = PerformOperation(num1, num2, HexOperation.Text);
                HexResult.Text = $"Результат: {Convert.ToString(result, 16).ToUpper()}";
            }
            catch
            {
                HexResult.Text = "Ошибка ввода!";
            }
        }

      
        private int PerformOperation(int a, int b, string operation)
        {
            if (operation == "+")
            {
                return a + b;
            }
            else if (operation == "-")
            {
                return a - b;
            }
            else if (operation == "*")
            {
                return a * b;
            }
            else if (operation == "/")
            {
                if (b == 0)
                    throw new DivideByZeroException("Деление на ноль");
                return a / b;
            }
            else
            {
                throw new InvalidOperationException("Неподдерживаемая операция");
            }
        }
    }
}
