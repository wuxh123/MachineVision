using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


namespace BarTenderLibrary
{
    public partial class BartenderControl : UserControl
    {
        #region  全局变量
        /// <summary>
        /// bartender接口
        /// </summary>
        IBarTenderTool _IBartender=null;
        /// <summary>
        /// bartender设置器
        /// </summary>
        BarTenderLibrary.SetBartender _SetBartender;
#endregion

        #region 构造函数
        public BartenderControl()
        {
            InitializeComponent();
            _SetBartender = new SetBartender();
        }
        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="IBartender"></param>
        public void init(IBarTenderTool IBartender)
        {
            _IBartender = IBartender;
            _SetBartender.ShowBartenderConfig(_IBartender, this.Controls);
            lab_BantenderPrintNumber.Text = BarTenderLibrary.StaticBartenderTool.BartenderPrintNumber1.ToString();
            trackBar_BartenderPrintNumber.Value = BarTenderLibrary.StaticBartenderTool.BartenderPrintNumber1;
        }
        #endregion

        #region  保存数据
        private void toolStripButton1_Click(object sender, EventArgs e)
        {           
            if (_IBartender == null)
            {
                return;
            }
            _SetBartender.SaveBatenderIniConfig(_IBartender);

            SavedBartenderConfig();
            #region  无用代码
            //#region  无用代码
            //BeginInvoke(new MethodInvoker(delegate
            //{
            //   // Thread.Sleep(30000);
            //    tSB_save.BackColor = Color.White;

            //}));
            #endregion
      
        }
        #endregion

        #region  更换打印文件
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (_IBartender == null)
            {
                return;
            }
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "BTW files (*.btw)|*btw";
            open_file.FilterIndex = 1;
            open_file.RestoreDirectory = true;
            open_file.Multiselect = true;
            if (open_file.ShowDialog()/*打开对话框 */== DialogResult.OK)
            {
                PathFileName.Text = open_file.FileName;

                _SetBartender.SetBartenderConfig(_IBartender, PathFileName.Text, null, null);
                
                tSB_SetPathFileName.BackColor = Color.YellowGreen;

                NoSaveBartenderConfig();
            }
        }
        #endregion

        #region  触发一次打印
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _IBartender.TriggerPrint();
        }
        #endregion

        #region  没有保存数据
        /// <summary>
        /// 没有保存数据
        /// </summary>
        void NoSaveBartenderConfig()
        {
            Invoke(new MethodInvoker(delegate {
                tSB_save.BackColor = Color.White; 
            }));
        }
        #endregion

        #region   保存了数据
        /// <summary>
        /// 保存了数据
        /// </summary>
        void SavedBartenderConfig()
        {



            Invoke(new MethodInvoker(delegate
            {
                tSB_save.BackColor = Color.YellowGreen;         
                tSB_SetPathFileName.BackColor = Color.White;
            }));
        }
        #endregion

        #region    设置打印份数
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lab_BantenderPrintNumber.Text = trackBar_BartenderPrintNumber.Value.ToString();

            BarTenderLibrary.StaticBartenderTool.BartenderPrintNumber1 = trackBar_BartenderPrintNumber.Value;
        }
        #endregion
    }
}
