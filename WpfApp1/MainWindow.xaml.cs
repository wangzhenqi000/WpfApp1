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

        private void timeUseFunc()
        {
            double result = 0.0;
            Console.WriteLine(DateTime.Now.ToShortTimeString());
            for (int i = 0; i < 10000; i++)
            {
                result += calc(0);
            }
            Console.WriteLine(DateTime.Now.ToShortTimeString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //timeUseFunc直接阻塞界面线程
            button.IsEnabled = false;
            timeUseFunc();
            button.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            Thread thread = new Thread(new ParameterizedThreadStart(_ => {
                timeUseFunc();
                this.Dispatcher.BeginInvoke(new Action(() =>
                {//相当于回调函数
                    button1.IsEnabled = true;
                }));
            }));//创建线程

            thread.Start(); //启动线程
        }

        private async void asyncFunc()
        {
            button3.IsEnabled = false;
            await Task.Factory.StartNew(delegate { timeUseFunc(); });
            //Task t1 = new Task(timeUseFunc);           
            button3.IsEnabled = true;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {            
            asyncFunc();           
        }
    }
}
