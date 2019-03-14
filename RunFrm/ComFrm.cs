using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RunFrm
{
    public partial class ComFrm : Form
    {
        #region   构造函数
        public ComFrm()
        {
            InitializeComponent();
        }
        #endregion
        
        private StringBuilder builder = new StringBuilder();//避免在事件处理方法中反复的创建，定义到外面。
      
        #region  串口接收的数据
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            String comtext = "";
            string dctm = "";
            int n = serialPort1.BytesToRead;                                //先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致
            byte[] buf = new byte[n];                                //声明一个临时数组存储当前来的串口数据
            serialPort1.Read(buf, 0, n);                                    //读取缓冲数据
            builder.Clear();                                         //清除字符串构造器的内容
            builder.Append(Encoding.ASCII.GetString(buf));
            comtext = builder.ToString(0, builder.Length);
            richTextBox_jieShouShuJu.Text = comtext;
        }
        #endregion
    }
}
