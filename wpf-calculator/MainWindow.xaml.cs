using System.Windows;
using System.Windows.Controls;
using System;

namespace wpf_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        const short MAX_DIGITS = 10;
        string selectedOperation = "";
        double firstNumber = 0;
        double secondNumber = 0;

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
            double result = 0;
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
            firstNumber = 0;
            secondNumber = 0;
            int truncatedDigits = result.ToString().Split(".")[0].Length;
            displayTextBlock.Text = Math.Round(result, MAX_DIGITS - truncatedDigits).ToString();
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