using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




namespace TcpIpLibrary
{
    public partial class TCPIPFrm : Form
    {

        #region  全局变量
        /// <summary>
        /// tcpip的数据接口
        /// </summary>
        ITcpIpShuJu _iTcpIp = null;
        #endregion
        
        #region  构造函数
        public TCPIPFrm(ITcpIpShuJu tp)
        {
            InitializeComponent();
            _iTcpIp = tp;
        }
        #endregion

        #region  确定数据
        private void button_QueDingIpDiGenShuJu_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region  发送数据
        private void button_FaSong_Click(object sender, EventArgs e)
        {
            if (this._iTcpIp.TcpipKeHuDuan != null)
            {
                this._iTcpIp.TcpipKeHuDuan.fasong(this._iTcpIp.TcpipIP, Convert.ToInt32(this._iTcpIp.TcpipDuanKou), richTextBox_FaSongDeShuJu.Text) ;
            }
            else 
            {
                MessageBox.Show("通讯工具不是做客户端，不能发送数据");
            }
        }
        #endregion

        #region  清空发送的数据
        private void button_QingKong_Click(object sender, EventArgs e)
        {
            richTextBox_FaSongDeShuJu.Clear();
        }
        #endregion
        
        #region  清空接收的数据
        private void button_QingKongJieShouDeShuJu_Click(object sender, EventArgs e)
        {
            richTextBox_JieShouDeShuJu.Clear();
        }
        #endregion

        #region  初始化函数
        private void TCPIPFrm_Load(object sender, EventArgs e)
        {
            if (this._iTcpIp != null)
            {               
                textBox_IP.Text = this._iTcpIp.TcpipIP;
                textBox_DuanKou.Text = this._iTcpIp.TcpipDuanKou;

                if (this._iTcpIp.TcpipFuWuDuan != null)//判断一下是不是链接了服务端
                {
                    label_keHuDuanZhuanTai.BackColor = Color.GreenYellow;
                }

                if (this._iTcpIp.TcpipKeHuDuan != null)//判断一下是不是链接了客户端
                {
                    label_fuWuDuanZhuanTai.BackColor = Color.GreenYellow;
                }
            }
            else
            {
                MessageBox.Show("工具tcpip是空的");
            }
        }
        #endregion

    }
}
