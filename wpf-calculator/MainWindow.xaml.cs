using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace wpf_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const short MAX_DIGITS = 10;
        string selectedOperation = "";
        long firstNumber = 0;
        long secondNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumbersHandler(object sender, RoutedEventArgs e)
        {
            if (displayTextBlock.Text.Length < MAX_DIGITS)
            {
                Button senderButton = (Button) sender;
                if (displayTextBlock.Text.Equals("0"))
                {
                    displayTextBlock.Text = senderButton.Content.ToString();
                } else
                {
                    displayTextBlock.Text += senderButton.Content.ToString();
                }
            }
        }

        private void DeleteHandler(object sender, RoutedEventArgs e)
        {
            if (displayTextBlock.Text.Length > 0)
            {
                displayTextBlock.Text = displayTextBlock.Text.Substring(0, displayTextBlock.Text.Length - 1);
                if (string.IsNullOrEmpty(displayTextBlock.Text))
                {
                    displayTextBlock.Text = "0";
                }
            }
        }

        private void OperationsHandler(object sender, RoutedEventArgs e)
        {
            firstNumber = int.Parse(displayTextBlock.Text);
            Button senderButton = (Button) sender;
            selectedOperation = senderButton.Content.ToString();
            displayTextBlock.Text = "0";
        }

        private void EqualsHandler(object sender, RoutedEventArgs e)
        {
            // assigning 0 to supress the error in line 93
            long result = 0;
            if (secondNumber == 0)
            {
                secondNumber = int.Parse(displayTextBlock.Text);
            }
            switch(selectedOperation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }
            firstNumber = result;
            displayTextBlock.Text = result.ToString();
        }

        private void ClearHandler(object sender, RoutedEventArgs e)
        {
            selectedOperation = "";
            displayTextBlock.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
        }

    }
}