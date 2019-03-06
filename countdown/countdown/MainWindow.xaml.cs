using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace countdown
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
            TimeSurplus timeSurplus = new TimeSurplus();
            timeSurplus.SurplusTime(new DateTime(2018, 12, 23));
            DataContext = timeSurplus;
            //this.LabelTime.Content = timeSurplus.Day.ToString() + timeSurplus.Hour.ToString() + timeSurplus.Min.ToString() + timeSurplus.Second.ToString();
        }

        private new void MouseMove(object sender, MouseButtonEventArgs e)
        {
            //窗口移动
            this.DragMove();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MinWindowSize(object sender, RoutedEventArgs e)
        {
            //最小化窗口
            this.WindowState = WindowState.Minimized;
        }

        private void HelpEvent(object sender, RoutedEventArgs e)
        {
            // 路由事件，得到当前选中的Button
            Button cmd = (Button)e.OriginalSource;

            // 根据当前选中的Button的名字
            // 打开窗口，注：xmal中Content为要打开窗口的名字
            Type type = this.GetType();
            Assembly assembly = type.Assembly;
            Window win = (Window)assembly.CreateInstance(
                type.Namespace + "." + "Help");

            // Show the window.
            win.ShowDialog();

        }
    }
}
