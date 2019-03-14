using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using System.IO;
using System.Threading;
using ReadImageHalconLibrary;
using System.Diagnostics;
using MultTree;
using LogClassLibrary;
using LineLibrary;





namespace LineLibrary.UI
{
    public partial class LineFrm : Form
    {
        #region   全局变量

        //#region    循环运行的标志
        ///// <summary>
        ///// 循环运行的标志
        ///// </summary>
        //public bool _xun_huan_yun_xing_biao_zhi = false;
        //#endregion

        //#region   读图的数据
        ///// <summary>
        ///// 读图的数据
        ///// </summary>
        //public IReadShuJu _IReadShuJu;
        //#endregion

        //#region   取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //public IReadImage _IReadImage;
        //#endregion

        #region  委托,事件
        /// <summary>
        /// 委托
        /// </summary>
        /// <returns></returns>
        delegate bool _run_delegate();

        /// <summary>
        /// 取图事件 
        /// </summary>
        event _run_delegate _read;

        /// <summary>
        /// 运行检测
        /// </summary>
        event _run_delegate _run;
        #endregion

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #region  卡尺

        #region   卡尺数据
        /// <summary>
        /// 卡尺数据
        /// </summary>
        ILineShuJu _ILineShuJu;
        #endregion

        #region   卡尺设置器
        /// <summary>
        /// 卡尺设置器
        /// </summary>
        SetLineShuJu _SetLineShuJu;
        #endregion

        //#region   卡尺工具
        ///// <summary>
        ///// 卡尺工具
        ///// </summary>
        //Line _Line;
        //#endregion

        #endregion

        #region  结果数据
        /// <summary>
        /// 结果数据
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();
        #endregion

        #endregion

        #region   构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public LineFrm()
        {
            InitializeComponent();
        }
        #endregion

        #region  初始化
        private void ParentFrm_Load(object sender, EventArgs e)
        {
            halconWinControl_ROI1.init();

            _read += read_one_image;
            _run += run;

            _SetLineShuJu = new SetLineShuJu();

            #region 无用代码
            //_Line = new Line();
            //_IReadImage = new ReadImage();
            //#region 初始化数据
            //if (TreeStatic.Mult_Tree_Node_Picture != null)
            //{
            //    if (TreeStatic.Mult_Tree_Node_Picture.SelfId.Contains("acquire"))
            //    {
            //        _IReadShuJu = (ReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;
            //        #region  把图片写入
            //        foreach (string file_name in _IReadShuJu.Path_Picture)
            //        {
            //            listBox_acquire_picture.Items.Add(file_name); //加载所有文件
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        _IReadShuJu = new ReadShuJu();
            //    }
            //}
            //else
            //{
            //    _IReadShuJu = new ReadShuJu();
            //}
            //#endregion
#endregion

#if DEBUG == true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _ILineShuJu = new LineShuJu();
            }
            else
            {
                _ILineShuJu = (LineShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
             _ILine = new LineShuJu();
#endif
            _SetLineShuJu.Set_Show_Parameter_HalconWindows(_ILineShuJu, this.Controls, this.halconWinControl_ROI1, ShuaXinJianCe);

        }
        #endregion

        //#region  循环运行
        //private void tSB_circulation_run_Click(object sender, EventArgs e)
        //{
        //    string str = tSB_circulation_run.Text;
        //    if (str == "循环运行")
        //    {
        //        _xun_huan_yun_xing_biao_zhi = true;
        //        tSB_circulation_run.Text = "停止循环";
        //        trigger_read();
        //    }
        //    else
        //    {
        //        _xun_huan_yun_xing_biao_zhi = false;
        //        tSB_circulation_run.Text = "循环运行";
        //    }
        //}
        //#endregion

        #region     运行
        private void tSB_run_one_Click(object sender, EventArgs e)
        {
            trigger_run();
        }

        /// <summary>
        /// 运行
        /// </summary>
        /// <returns></returns>
        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            { return false; }
            _stopWatch.Restart();
            bool ok = false;

            //_Line.Spoke(_ILineShuJu, halconWinControl_ROI1);
            //_Line.Line_Show(_ILineShuJu, halconWinControl_ROI1.HalconWindow1);
            _result.Clear();
            this._ILineShuJu.analyze_show(halconWinControl_ROI1.HalconWindow1, "1", ref _result);

            _stopWatch.Stop();
            Invoke(new Action(delegate
            {
                m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();
                //if (_xun_huan_yun_xing_biao_zhi)
                //{
                //    Thread th = new Thread(new ThreadStart(() =>
                //    {
                //        trigger_read();
                //    }));
                //    th.Start();
                //}
            }));
            ok = true;
            return ok;
        }
        #endregion

        #region   读取一张图片事件
        /// <summary>
        /// 读取一张图片事件
        /// </summary>
        /// <returns></returns>
        bool read_one_image()
        {
            bool ok = false;
            try
            {
                if (!halconWinControl_ROI1.Exit_Image())
                {
                    halconWinControl_ROI1.Ho_Image.Dispose();
                }
                //_IReadImage.read_Image(_IReadShuJu);
                halconWinControl_ROI1.Ho_Image = this._ILineShuJu.ImageFather.Ho_image;

                //if (_xun_huan_yun_xing_biao_zhi)
                //{
                //    trigger_run();
                //}
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LogFile.Error, "取图片一张出错");
                MessageBox.Show("取图片一张出错:" + ex.Message);
                ok = false;
            }
            return ok;
        }
        #endregion

        #region  取一张图片
        private void tSB_read_image_Click(object sender, EventArgs e)
        {
            trigger_read();
        }
        #endregion

        #region 退出
        private void acquriefrm_FormClosing(object sender, FormClosingEventArgs e)
        {

            // MachineVision.ShuJuJieGou.TreeStatic.Mult_Tree_Node.Obj = _re;         

        }
        #endregion

        //#region    添加图片
        //private void bnt_add_picture_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog open_file = new OpenFileDialog();
        //    open_file.Filter = "All files (*.*)|*.*|TIFF files (*.tif)|*tif";
        //    open_file.FilterIndex = 2;
        //    open_file.RestoreDirectory = true;
        //    open_file.Multiselect = true;
        //    open_file.ShowDialog();//打开对话框           

        //    if (listBox_acquire_picture.Items.Count != 0)//判断有无图片
        //    {
        //        listBox_acquire_picture.Items.Clear();//清空图片
        //    }

        //    if (_IReadShuJu.Path_Picture.Count != 0)
        //    {
        //        _IReadShuJu.Path_Picture.Clear();
        //    }

        //    foreach (string file_name in open_file.FileNames)
        //    {
        //        listBox_acquire_picture.Items.Add(file_name); //加载所有文件

        //        _IReadShuJu.Path_Picture.Add(file_name);

        //    }
        //}
        //#endregion

        //#region     删除图片
        //private void btn_delete_picture_Click(object sender, EventArgs e)
        //{
        //    listBox_acquire_picture.Items.Clear();
        //}
        //#endregion

        //#region    移除图片
        //private void btn_remove_picture_Click(object sender, EventArgs e)
        //{

        //}

        //#endregion

        #region  无用代码
        #region 读取图片后的回调函数
        //void read_callBack(IAsyncResult re)
        //{
        //    if (_xun_huan_yun_xing_biao_zhi)
        //    {
        //        _read.BeginInvoke(read_callBack, null);
        //    }
        //}
        #endregion
        #endregion

        #region   触发取图
        /// <summary>
        /// 触发取图
        /// </summary>
        void trigger_read()
        {
            if (_read != null)
            {
                _read();
            }
        }



        #endregion

        #region 运行触发器
        /// <summary>
        /// 运行触发器
        /// </summary>
        void trigger_run()
        {
            if (_run != null)
            {
                _run();
            }
        }
        #endregion

        #region  确定卡尺参数
        private void btn_que_ding_draw_spoke_can_shu_Click(object sender, EventArgs e)
        {
            _SetLineShuJu.Set_Draw_Rake(_ILineShuJu, numericUpDown_Hv_Elements.Text, numericUpDown_Hv_DetectHeight.Text, numericUpDown_Hv_DetectWidth.Text);
            _SetLineShuJu.Set_Rake(_ILineShuJu, Hv_Sigma.Text, numericUpDown_Hv_Threshold.Text, Hv_Transition.Text, Hv_Select.Text, numericUpDown_Hv_ActiveNum.Text);
            _SetLineShuJu.Set_ShowSpoke(_ILineShuJu, halconWinControl_ROI1);

        }
        #endregion

        //#region    确定卡尺路径 
        //private void btn_que_ding_ka_chi_lu_jing_Click(object sender, EventArgs e)
        //{
        //    halconWinControl_ROI1.ShieldMouseEvent();
        //    _SetLineShuJu.Set_Draw_Rake(_ILineShuJu, halconWinControl_ROI1.HalconWindow1);
        //    halconWinControl_ROI1.ReloadMouseEvent();

        //}
        //#endregion

        //#region  显示卡尺
        //private void btn_show_ka_chi_Click(object sender, EventArgs e)
        //{
        //    _SetLineShuJu.Set_Show_Rake(_ILineShuJu, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        //#region 确定测量参数
        //private void btn_que_ding_spoke_can_shu_Click(object sender, EventArgs e)
        //{
        //    _SetLineShuJu.Set_Rake(_ILineShuJu, Hv_Sigma.Text, numericUpDown_Hv_Threshold.Text, Hv_Transition.Text, Hv_Select.Text, numericUpDown_Hv_ActiveNum.Text);

        //}
        //#endregion

        //#region  测量当前图片
        //private void btn_ce_liang_dang_qian_tu_pian_Click(object sender, EventArgs e)
        //{
        //    trigger_run();
        //}
        //#endregion

        //#region  显示拟合的直线
        //private void btn_show_ni_he_de_yuan_Click(object sender, EventArgs e)
        //{
        //    _SetLineShuJu.Set_Show_Line(_ILineShuJu, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        //#region  显示找的点
        //private void btn_show_zhao_dao_de_dian_Click(object sender, EventArgs e)
        //{
        //    _SetLineShuJu.Set_Show_Point(_ILineShuJu, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        #region   刷新检测
        /// <summary>
        ///  roi移动是触发的事件
        /// </summary>
        void ShuaXinJianCe(HWindow _halconWindow1)
        {
            if (!halconWinControl_ROI1.Exit_Image())
            {
                return;
            }
            _SetLineShuJu.Set_ShowSpoke(_ILineShuJu, halconWinControl_ROI1);
        }
        #endregion

        #region 无用代码
        //#region  刷新定点位
        //private void toolStripButton_ShuaXinDingWeiDian_Click(object sender, EventArgs e)
        //{
        //    this._SetLineShuJu.Set_ShuaXinDingWeiDian(this._ILineShuJu);
        //}
        //#endregion
        #endregion
    }
}
