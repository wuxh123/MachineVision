using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZhuCeRuanJianLibrary;

namespace ShengChengRuanJianZhuCeMa
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region  构造函数
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region  生成注册码
        private void button_ShengChengZhuCeMa_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string jiqima_ = textBox_JiQiMa.Text;
                textBox_ZhuCeMa.Text = ZhuCeRuanJianLibrary.ShengChengZhuCeMa.GetCode(jiqima_);
            }
            catch
            {
                MessageBox.Show("生成注册码出错");
            }
        }
        #endregion
    }
}
