﻿using System;
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

        const int MAX_DIGITS = 10;

        string displayString = "";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumbersHandler(object sender, RoutedEventArgs e)
        {
            if (displayString.Length < MAX_DIGITS)
            {
                Button senderButton = (Button)sender;
                displayString += senderButton.Content.ToString();
                displayTextBlock.Text = displayString;
            }
        }

        private void DeleteHandler(object sender, RoutedEventArgs e)
        {
            if (displayString.Length > 0)
            {
                displayString = displayString.Substring(0, displayString.Length - 1);                
            }
            
            if (displayString.Equals(""))
            {
                displayTextBlock.Text = "0";
            } else
            {
                displayTextBlock.Text = displayString;
            }
        }

    }
}