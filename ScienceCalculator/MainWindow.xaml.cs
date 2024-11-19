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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScienceCalculator
{
    public partial class MainWindow : Window
    {
        private double _currentValue;
        private string _operation;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Display.Text += button.Content.ToString();
            InputDisplay.Text += button.Content.ToString();
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (double.TryParse(Display.Text, out _currentValue))
            {
                _operation = button.Content.ToString();
                Display.Clear();
            }
            InputDisplay.Text += button.Content.ToString();
        }

        private void Function_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string x = Display.Text;
            if (double.TryParse(Display.Text, out double value))
            {
                switch (button.Content.ToString())
                {
                    case "sin(x)":
                        Display.Text = Math.Sin(value * Math.PI / 180).ToString();
                        InputDisplay.Text = string.Format("sin({0})", x);
                        break;
                    case "cos(x)":
                        Display.Text = Math.Cos(value * Math.PI / 180).ToString();
                        InputDisplay.Text = string.Format("cos({0})", x);
                        break;
                    case "tan(x)":
                        Display.Text = Math.Tan(value * Math.PI / 180).ToString();
                        InputDisplay.Text = string.Format("tan({0})", x);
                        break;
                    case "√":
                        Display.Text = Math.Sqrt(value).ToString();
                        InputDisplay.Text = string.Format("√{0}", x);
                        break;
                    case "∛":
                        Display.Text = Math.Pow(value, 1.0/3.0).ToString();
                        InputDisplay.Text = string.Format("√{0}", x);
                        break;
                }
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Display.Text, out double secondValue))
            {
                double result = 0;
                switch (_operation)
                {
                    case "+":
                        result = _currentValue + secondValue;
                        break;
                    case "-":
                        result = _currentValue - secondValue;
                        break;
                    case "*":
                        result = _currentValue * secondValue;
                        break;
                    case "/":
                        result = _currentValue / secondValue;
                        break;
                    case "^":
                        result = Math.Pow(_currentValue, secondValue);
                        break;
                }
                Display.Text = result.ToString();
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputDisplay.Text = "";
            Display.Clear();
            _currentValue = 0;
            _operation = string.Empty; 
        }

        private void Inversion_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = _currentValue * -1;
        }

        private void To_Binary_Click(object sender, RoutedEventArgs e)
        {
           if (Display.Text != "")
           {
                Display.Text = Convert.ToString(int.Parse(Display.Text), 2);
           }
           
        }

        private void To_Hex_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text != "")
            {
                Display.Text = Convert.ToString(int.Parse(Display.Text), 16).ToUpper();
            }
               
        }

        private void To_Octal_Click(object sender, RoutedEventArgs e)
        {
            if (Display.Text != "")
            {
                Display.Text = Convert.ToString(int.Parse(Display.Text), 8);
            }
               
        }
    }
}
