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
using System.Xml.XPath;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static String display;
        private double result;
        private Operations operation;

        public MainWindow()
        {
            InitializeComponent();
            display = resultLabel.Content.ToString();
            
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            result = 0;
            display = result.ToString();
            resultLabel.Content = display;
        }


        private void negButton_Click(object sender, RoutedEventArgs e)
        {
            if (display[0] != '-')
            {
                display = "-" + display;
            }
            else
            {
                display = display.Substring(1);
            }
            resultLabel.Content = display;
        }

        private void percentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(display, out double newResult))
            {
                display = ((result * newResult) / 100.0).ToString();
                resultLabel.Content = display;
            }
        }



        private void decimalButton_Click(object sender, RoutedEventArgs e)
        {
            if (!display.Contains("."))
            {
                display = display + ".";
                resultLabel.Content = display;
            }
        }

        private void equalsButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(display, out double newResult))
            {
                switch(operation)
                {
                    case Operations.Addition:
                        display = Arithmetic.Add(result, newResult).ToString();
                        resultLabel.Content = display;
                        break;
                    case Operations.Subtraction:
                        display = Arithmetic.Subtract(result, newResult).ToString();
                        resultLabel.Content = display;
                        break;
                    case Operations.Multiplication:
                        display = Arithmetic.Multiply(result, newResult).ToString();
                        resultLabel.Content = display;
                        break;
                    case Operations.Division:
                        display = Arithmetic.Divide(result, newResult).ToString();
                        resultLabel.Content = display;
                        break;
                    default:
                        break;
                }
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int value = 0;

            if (sender == zeroButton)
                value = 0;
            else if (sender == oneButton)
                value = 1;
            else if (sender == twoButton)
                value = 2;
            else if (sender == threeButton)
                value = 3;
            else if (sender == fourButton)
                value = 4;
            else if (sender == fiveButton)
                value = 5;
            else if (sender == sixButton)
                value = 6;
            else if (sender == sevenButton)
                value = 7;
            else if (sender == eightButton)
                value = 8;
            else if (sender == nineButton)
                value = 9;
            


            if (display.Equals("0") || display.Contains('E'))
            {
                display = value.ToString();
            }
            else
            {
                display = display + value.ToString();
            }
            resultLabel.Content = display;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(display, out result))
            {
                display = "0";
                resultLabel.Content = display;
            }

            if (sender == addButton)
            {
                operation = Operations.Addition;
            }
            else if (sender == subtButton)
            {
                operation = Operations.Subtraction;
            }
            else if (sender == multButton)
            {
                operation = Operations.Multiplication;
            }
            else if (sender == divideButton)
            {
                operation = Operations.Division;
            }
        }
    }

    public class Arithmetic
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Subtract(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            // Do something for b == 0;
            if (b == 0)
            {
                MessageBox.Show("Divide by 0 exception", "Not cool", MessageBoxButton.OK, MessageBoxImage.Information);
                return a;
            }
            else
            {
                return a / b;
            }
        }
    }

    public enum Operations
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
