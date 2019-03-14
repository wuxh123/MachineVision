using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;





namespace TcpIpLibrary
{
    #region    tcpip数据类
    /// <summary>
    /// tcpip数据类
    /// </summary>
    public class TcpIpShuJu : ITcpIpShuJu
    {
        #region  监听的个数
        int _jianTingDeGeShu = 10;      
        #endregion
        
        #region  tcpip的IP地址
        /// <summary>
        /// tcpip的ip地址
        /// </summary>
        string _tcpipIP = "192.168.188.1";               
        #endregion
        
        #region   tcpip的端口号
        /// <summary>
        /// tcpip的端口号
        /// </summary>
        string _tcpipDuanKou = "9600";       
        #endregion

        #region   客户端
        /// <summary>
        /// 客户端
        /// </summary>
        TCPIP_KeHu _tcpipKeHuDuan = null;       
        #endregion

        #region   服务端
        /// <summary>
        /// 服务端
        /// </summary>
        TCPIP_FuWu _tcpipFuWuDuan = null;      
        #endregion

        #region  属性

        #region  tcpip的IP地址
        /// <summary>
        /// tcpip的ip地址
        /// </summary>
        public string TcpipIP
        {
            get { return _tcpipIP; }
            set { _tcpipIP = value; }
        }
        #endregion

        #region  tcpip的端口号 
        /// <summary>
        /// tcpip的端口号
        /// </summary>
        public string TcpipDuanKou
        {
            get { return _tcpipDuanKou; }
            set { _tcpipDuanKou = value; }
        }
        #endregion

        #region  监听的个数
        /// <summary>
        /// 监听的个数
        /// </summary>
        public int JianTingDeGeShu
        {
            get { return _jianTingDeGeShu; }
            set { _jianTingDeGeShu = value; }
        }
        #endregion

        #region  客户端
        /// <summary>
        /// 客户端
        /// </summary>
        public TCPIP_KeHu TcpipKeHuDuan
        {
            get { return _tcpipKeHuDuan; }
            set { _tcpipKeHuDuan = value; }
        }
        #endregion
        
        #region   服务端
        /// <summary>
        /// 服务端
        /// </summary>
        public TCPIP_FuWu TcpipFuWuDuan
        {
            get { return _tcpipFuWuDuan; }
            set { _tcpipFuWuDuan = value; }
        }
        #endregion

        #endregion
    }
    #endregion

    #region  tcpip的数据接口
    /// <summary>
    /// tcpip的数据接口
    /// </summary>
    public interface ITcpIpShuJu
    {
        #region  属性

        #region  tcpip的IP地址
        /// <summary>
        /// tcpip的ip地址
        /// </summary>
        string TcpipIP
        {
            get;
            set;
        }
        #endregion

        #region  tcpip的端口号
        /// <summary>
        /// tcpip的端口号
        /// </summary>
         string TcpipDuanKou
        {
            get;
            set;
        }
        #endregion
        
        #region  客户端
        /// <summary>
        /// 客户端
        /// </summary>
         TCPIP_KeHu TcpipKeHuDuan
        {
            get;
            set;
        }
        #endregion

        #region   服务端
        /// <summary>
        /// 服务端
        /// </summary>
         TCPIP_FuWu TcpipFuWuDuan
        {
            get;
            set;
        }
        #endregion
        
        #endregion
    }
    #endregion
    
    #region   tcpip服务端
    /// <summary>
    /// tcpip服务端
    /// </summary>
    public class TCPIP_FuWu
    {
        ///<summary>
        /// 服务端
        /// </summary>
        public Socket fuwuduan;
        /// <summary>
        /// ip地址
        /// </summary>
        IPAddress ip;
        /// <summary>
        /// 表示网络端点
        /// </summary>
        IPEndPoint ipe;
        /// <summary>
        /// 初始化ip地址
        /// </summary>
        /// <param name="ip_zifu">输入ip地址</param>
        /// <param name=" duanko">输入端口</param>
        /// <returns>初始化成功，返回ip，失败返回空</returns>
        public string Fu_Wu_Duan(string ip_zifu,int duankou)
        {
            string ok = "";
            try
            {            
                fuwuduan = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                fuwuduan.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                ip = IPAddress.Parse(ip_zifu);//IPAddress.Parse(txtServer.Text);
                ipe = new IPEndPoint(ip, duankou);
                fuwuduan.Bind(ipe);
                ok = ip_zifu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("初始化服务端失败："+ex.Message, "警告", MessageBoxButtons.OK);
            }
            return ok;
        }

        /// <summary>
        /// 检测启动
        /// </summary>
        /// <param name="a">允许监听多小个客户端</param>
        /// <returns>返回一个标志，true表示监听成功</returns>
        public bool qidong_jiankong(int a)
        {
            bool ok = false;
            try
            {
                fuwuduan.Listen(a);
                ok=true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动监听失败：" + ex.Message, "警告", MessageBoxButtons.OK);
            }

            return ok;
        }
    }
    #endregion

    #region  TCPIP客户端
    /// <summary>
    /// TCPIP客户端
    /// </summary>
    public class TCPIP_KeHu
    {
        /// <summary>
        /// ip地址
        /// </summary>
        IPAddress ip;
        /// <summary>
        /// 表示网络端点
        /// </summary>
        IPEndPoint ipe;
        /// <summary>
        /// 客户端
        /// </summary>
        Socket clientSocket;
        /// <summary>
        /// 初始化客户端
        /// </summary>
        /// <param name="ipDiZhi">ip地址</param>
        /// <param name="duanKou">端口</param>
        /// <returns>返回true成功</returns>
        public bool init(string ipDiZhi,int duanKou)
        {
            bool ok = false;       
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ip = IPAddress.Parse(ipDiZhi);
            ipe = new IPEndPoint(ip, duanKou);
            clientSocket.Connect(ipe);
            ok = true;
            return ok;
        }
        
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="ip_">IP地址</param>
        /// <param name="duankou">端口</param>
        /// <param name="str">发送的数据</param>
        /// <returns>返回true发送成功</returns>
        public bool fasong(string ip_, int duankou,string str)
        {           
            IPAddress ip;
            IPEndPoint ipe;
            bool ok = false;
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ip = IPAddress.Parse(ip_);
            ipe = new IPEndPoint(ip, duankou);
            clientSocket.Connect(ipe);
            clientSocket.Send(Encoding.ASCII.GetBytes(str));
            ok = true;
            return ok;
        }

        /// <summary>
        /// 接收初始化后的端口数据
        /// </summary>
        /// <returns>返回接收到的数据</returns>
        public string jieshou()
        {
            byte[] result = new byte[1024];
            string str="";
            int receiveLength;
            receiveLength = clientSocket.Receive(result);
            str= Encoding.ASCII.GetString(result, 0, receiveLength);
            return str;
        }
    }
   #endregion

    #region  TCPIP的状态类
    /// <summary>
    /// TCPIP的状态类
    /// </summary>
    public class StateObject
    {
        /// <summary>
        /// 固定buf的大小值
        /// </summary>
        public const int BUFFER_SIZE = 1024;
       /// <summary>
       /// 工作的socket
       /// </summary>
        public Socket workSocket;
        /// <summary>
        /// 缓存大小
        /// </summary>
        public byte[] buffer;

        /// <summary>
        ///构造函数
        /// </summary>
        public StateObject()
        {
            this.workSocket = null;
            this.buffer = new byte[BUFFER_SIZE];

        }
        ~StateObject()
        {
            this.workSocket = null;
        }

    }
    #endregion
}
