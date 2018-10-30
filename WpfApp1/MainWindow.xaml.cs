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

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double result = 0.0;
            button.IsEnabled = false;
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            for (int i = 0; i < 1000000; i++)
            {
                result += Math.Cos(i);
                result *= Math.Sin(i);
            }
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            button.IsEnabled = true;
        }
    }
}
