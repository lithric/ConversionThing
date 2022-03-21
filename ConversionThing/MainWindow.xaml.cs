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

namespace ConversionThing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int[] coins = { 100, 25, 10, 5, 1 };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InputHandler(object sender, TextChangedEventArgs e)
        {
            string userIn = ((TextBox)e.Source).Text;
            int intInput = 0;
            bool success = int.TryParse(userIn, out intInput);
            if(!success)
            {
                return;
            }
            else
            {
                var good = coinSelection(intInput);
                DollarCount.Content = $"{good[0]}";
                QuarterCount.Content = $"{good[1]}";
                DimeCount.Content = $"{good[2]}";
                NickelCount.Content = $"{good[3]}";
                PennyCount.Content = $"{good[4]}";
            }
        }

        public List<int> coinSelection(int num)
        {
            List<int> returnValue = new List<int>();
            returnValue.Add(num / coins[0]);
            returnValue.Add(num % coins[0] / coins[1]);
            returnValue.Add(num % coins[1] / coins[2]);
            returnValue.Add(num % coins[2] / coins[3]);
            returnValue.Add(num % coins[3] / coins[4]);
            return returnValue;
        }
    }
}
