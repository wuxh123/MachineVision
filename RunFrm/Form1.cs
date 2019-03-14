using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CheckStreamLibrary;
using MultTree;





/*********************运行的窗体*****************************/
namespace RunFrm
{
    public partial class Form1 : Form
    {
        #region   全局变量

        #region  第一个检测流
        /// <summary>
        /// 第一个检测流
        /// </summary>
        CheckStreamLibrary.ICheckStream _iCheckStrOne;
        #endregion

        #region   第二个检测流
        /// <summary>
        /// 第二个检测流
        /// </summary>
        CheckStreamLibrary.ICheckStream _iCheckStrTwo;
        #endregion

        #region   开始启动标志
        /// <summary>
        /// 开始检测的标志
        /// </summary>
        bool _kaiShiQiDongBiaoZhi = false;
        #endregion

        #region   循环检测的线程
        /// <summary>
        /// 循环检测的线程1
        /// </summary>
        Thread _thr1;
        /// <summary>
        /// 循环检测的线程2
        /// </summary>
        Thread _thr2;
        #endregion

        #endregion

        #region   构造函数
        public Form1()
        {
            InitializeComponent();

            #region  初始化窗体
            halconWinControl_11.init();
            halconWinControl_12.init();
            #endregion

        }
        #endregion

        #region   加载检测的job
        private void toolStripButton_loadJob_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "det files (*.det)|*det";
            open_file.FilterIndex = 1;
            open_file.RestoreDirectory = true;
            open_file.Multiselect = true;
            //open_file.ShowDialog();//打开对话框 

            if (open_file.ShowDialog() == DialogResult.OK)
            {                
                string path = open_file.FileName;

                if (TreeStatic.Root.getChildNodeCount() != 0)//清空一下底层的树
                {
                    TreeStatic.Root.deleteClearAll();
                }//清空树

                CheckStreamLibrary.MultTreeStaticSave.LoadTreeStatic(ref path);
                this._iCheckStrOne.Check_Root = MultTreeControlLibrary.Select_MultTreeCheckStream.Select_CheckFristNodeStream();

                int i = 1;
                this._iCheckStrTwo.Check_Root = MultTreeControlLibrary.Select_MultTreeCheckStream.Select_CheckNodeStream(ref i);

                toolStripButton_loadJob.Text = "job加载成功";

            }         
        }
        #endregion
        
        #region  开始检测
        private void toolStripButton_startTest_Click(object sender, EventArgs e)
        {
            if (this._kaiShiQiDongBiaoZhi == false)
            {
                this._kaiShiQiDongBiaoZhi = true;
                toolStripButton_startTest.Text = "正在检测";
            }
            else
            {
                this._kaiShiQiDongBiaoZhi = false;
                toolStripButton_startTest.Text = "开始检测";
            }           
        }
        #endregion
        
        #region  手动单步触发第一个相机
        private void toolStripButton_shouDongDanBuChuFa_Click(object sender, EventArgs e)
        {
            this._iCheckStrOne.trigger_check();
        }
        #endregion        
        
        #region  初始化
        private void Form1_Load(object sender, EventArgs e)
        {
            
            #region   初始化检测流
            this._iCheckStrOne = new CheckStreamLibrary.CheckStream();
            this._iCheckStrTwo = new CheckStreamLibrary.CheckStream();

            this._iCheckStrOne.CheckStream_Init(this.halconWinControl_11);
            this._iCheckStrTwo.CheckStream_Init(this.halconWinControl_12);
            #endregion

            #region   初始化事件
            this._iCheckStrOne._Resulte1 += _iCheckStrOne__Resulte1;
            this._iCheckStrTwo._Resulte1 += _iCheckStrTwo__Resulte1;
            #endregion

        }

        #endregion

        #region  单步触发第二个相机
        private void toolStripButton_danBuChuFaDiErGeXiangJi_Click(object sender, EventArgs e)
        {
            this._iCheckStrTwo.trigger_check();
        }
        #endregion

        #region   第一个回调事件
        /// <summary>
        /// 第一个回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _iCheckStrOne__Resulte1(object sender, CheckStreamLibrary.CheckStreamEventArgs e)
        {
            if (e.AllResult)
            {
                #region  显示数据
                CheckShuJuResultTool Ch = new CheckShuJuResultTool();
                this.listBox1.Items.Clear();
                Ch.ShowOnListBox1(this.listBox1, e);
                #endregion
            }
            else
            {
                this.listBox1.Items.Clear();
                this.listBox1.Text = "检测错误";
            }
        }        
        #endregion

        #region   第二个回调事件
        /// <summary>
        /// 第二个回调事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _iCheckStrTwo__Resulte1(object sender, CheckStreamLibrary.CheckStreamEventArgs e)
        {
            if (e.AllResult)
            {
                #region  显示数据
                CheckShuJuResultTool Ch = new CheckShuJuResultTool();
                this.listBox2.Items.Clear();
                Ch.ShowOnListBox1(this.listBox2, e);
                #endregion
            }
            else
            {
                this.listBox2.Items.Clear();
                this.listBox2.Text = "检测错误";
            }
        }
        #endregion

        #region  使用tcpip  
        private void toolStripButton_TcpIp_Click(object sender, EventArgs e)
        {
            TCPIPFrm tcpipfrm = new TCPIPFrm();
            tcpipfrm.ShowDialog();
        }
        #endregion
        
        #region  使用串口
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ComFrm comfrm = new ComFrm();
            comfrm.ShowDialog();
        }
        #endregion

        #region   检测线程

        #region  检测线程1
        /// <summary>
        /// 检测线程1
        /// </summary>
        void checkCamerOne()
        {

        }
        #endregion

        #region   检测线程2
        /// <summary>
        /// 检测线程2
        /// </summary>
        void checkCamerTwo()
        {

        }
        #endregion

        #endregion

    }
}
