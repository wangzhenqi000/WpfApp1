using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        private double calc(int i)
        {
            if(i > 1000)
            {
                return 1;
            }
            double re = Math.Cos(i) * Math.Sin(i);
            return re * calc(i + 1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double result = 0.0;
            button.IsEnabled = false;
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            for (int i = 0; i < 10000; i++)
            {
                result += calc(0);
            }
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            button.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double result = 0.0;
            button1.IsEnabled = false;

            Thread thread = new Thread(new ParameterizedThreadStart(_ => {
                Console.WriteLine(DateTime.Now.ToShortTimeString());
                for (int i = 0; i < 100000; i++)
                {
                    result += calc(0);
                }
                Console.WriteLine(DateTime.Now.ToShortTimeString());
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    button1.IsEnabled = true;
                }));
            }));//创建线程

            thread.Start(); //启动线程
        }
    }
}
