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

        string displayString = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumbersHandler(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            displayString += senderButton.Content.ToString();
            displayText.Text = displayString;
        }

    }
}