using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TcpIpLibrary;
using System.Net.Sockets;

namespace RunFrm
{
    public partial class TCPIPFrm : Form
    {
        #region  全局变量 

        #region   服务端
        /// <summary>
        /// 服务端
        /// </summary>
        TCPIP_FuWu _fuWuDuan =null;        
        #endregion

        #endregion
        
        #region   构造函数
        public TCPIPFrm()
        {
            InitializeComponent();
        }
        #endregion
        
        #region  创建客户端
        private void button_chuangJianKeHuDuan_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region  创建服务端
        private void button_chuangJianFuWuDuan_Click(object sender, EventArgs e)
        {
            if (_fuWuDuan != null)
            {
                _fuWuDuan = null;
            }
            _fuWuDuan = new TCPIP_FuWu();
            _fuWuDuan.Fu_Wu_Duan(textBox_ipDiZhi.Text, Convert.ToInt32(textBox_duanKouHao.Text));
            _fuWuDuan.qidong_jiankong(100);
            _fuWuDuan.fuwuduan.BeginAccept(new AsyncCallback(AcceptCallback), _fuWuDuan.fuwuduan);
            button_chuangJianFuWuDuan.Text = "服务启动成功";

        }
        #endregion

        SocketError errorCode;

        void AcceptCallback(IAsyncResult ar)
        {
            Socket zhongjian, handler;
            zhongjian = (Socket)ar.AsyncState;
            handler = zhongjian.EndAccept(ar);
          StateObject state = new StateObject();
            state.workSocket = handler;
            state.buffer = new byte[StateObject.BUFFER_SIZE];

            handler.BeginReceive(state.buffer, 0, StateObject.BUFFER_SIZE, 0, out errorCode, new AsyncCallback(ReadCallback), state);

        }


        void ReadCallback(IAsyncResult ar)
        {
            StateObject state = (StateObject)ar.AsyncState;
            Socket hander = state.workSocket;
            int bytesRead = hander.EndReceive(ar);
            if (bytesRead > 0)
            {
                byte[] tmpbytes = new byte[bytesRead];
                Array.Copy(state.buffer, 0, tmpbytes, 0, bytesRead);
                string str = "";
                str = Encoding.ASCII.GetString(tmpbytes, 0, bytesRead);

                if (InvokeRequired)
                {

                    Invoke(new Action(() =>
                    {
                        richTextBox_FaSongShuJu.Text = str;
                    }));
                }
                else
                {
                    richTextBox_FaSongShuJu.Text = str;
                }
                _fuWuDuan.fuwuduan.BeginAccept(new AsyncCallback(AcceptCallback), _fuWuDuan.fuwuduan);

            }

        }


        #region  服务端发送数据
        private void button_fuWuDuanFaSongShuJu_Click(object sender, EventArgs e)
        {

        }
        #endregion
        
        #region 清空发送的数据
        private void button_keHuDuanJieShouShuJu_Click(object sender, EventArgs e)
        {

        }
        #endregion
        
    }
}
