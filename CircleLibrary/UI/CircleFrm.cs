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
using System.Diagnostics;
using ReadImageHalconLibrary;
using MultTree;
using LogClassLibrary;
using CircleLibrary;





namespace CircleLibrary.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CircleFrm : Form
    {
        #region    全局变量
          
        #region  委托,事件
        /// <summary>
        /// 委托
        /// </summary>
        /// <returns></returns>
        delegate bool _run_delegate();

        /// <summary>
        /// 事件取图 
        /// </summary>
        event _run_delegate _read;

        /// <summary>
        /// 检测事件
        /// </summary>
        event _run_delegate _run;

        #endregion

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #region   拟合圆数据
        /// <summary>
        /// 拟合圆数据
        /// </summary>
        ICircleShuJu _ICircleShuJu;
        #endregion

        #region  设置拟合圆参数
        /// <summary>
        /// 设置拟合圆参数
        /// </summary>
        SetCirleShuJu _Set_CirleShuJu;
        #endregion

        #region   处理的结果
        /// <summary>
        /// 处理的结果
        /// </summary>
        Dictionary<string, Object> _result=new Dictionary<string,object>();
        #endregion

        #endregion

        #region   构造函数
        public CircleFrm()
        {
            InitializeComponent();

            //BeginInvoke(new Action(delegate
            //{
            //HOperatorSet.GenEmptyObj(out _ho_Image);
            //_ho_Image.Dispose();
            //}));


        }
        #endregion

        #region  初始化
        private void ParentFrm_Load(object sender, EventArgs e)
        {
            halconWinControl_ROI1.init();         

            _read += read_one_image;
            _run += run;
                      
            _Set_CirleShuJu = new SetCirleShuJu();
             
#if DEBUG == true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {               
                _ICircleShuJu = new CircleShuJu();
            }
            else
            {
                _ICircleShuJu = (CircleShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
          _ICircleShuJu = new CircleShuJu();
#endif
            _Set_CirleShuJu.Set_ShowParameterHalconWinControl(_ICircleShuJu, this.Controls, this.halconWinControl_ROI1, ROIMoveEvent);

        }
        #endregion

        #region  无用代码
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
        #endregion

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
            //_Circle.Spoke(_ICircleShuJu, halconWinControl_ROI1.Ho_Image);
            //_Circle.Circle_Show(_ICircleShuJu, halconWinControl_ROI1.HalconWindow1);
            this._result.Clear();
            this._ICircleShuJu.analyze_show( this.halconWinControl_ROI1.HalconWindow1, "1",ref this._result);

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
                //if (!halconWinControl_ROI1.Exit_Image())
                //{
                //    halconWinControl_ROI1.Ho_Image.Dispose();
                //    //_IRead.read_Image(_IReadShuJu);                   
                //}
                halconWinControl_ROI1.Ho_Image = this._ICircleShuJu.ImageFather.Ho_image;
                //if (_xun_huan_yun_xing_biao_zhi)
                //{
                //    trigger_run();
                //}
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(LogFile.Error, "取图片一张出错");
                MessageBox.Show(ex.Message + " " + "取图片一张出错");
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

        #region 无用代码
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
        #endregion

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

        #region 无用代码
        //#region  确定卡尺路劲   
        //private void btn_que_ding_ka_chi_lu_jing_Click(object sender, EventArgs e)
        //{
        //    halconWinControl_ROI1.ShieldMouseEvent();
        //    if (halconWinControl_ROI1.Exit_Image() == false)
        //    {
        //        MessageBox.Show("图片是空的");
        //        return;
        //    }
        //    _Set_CirleShuJu.Set_DrawSpoke(_ICircleShuJu, halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1);
        //    halconWinControl_ROI1.ReloadMouseEvent();
        //}
        //#endregion

        //#region  显示卡尺
        //private void btn_show_ka_chi_Click(object sender, EventArgs e)
        //{
        //    if (halconWinControl_ROI1.Exit_Image() == false)
        //    {
        //        MessageBox.Show("图片是空的，或者卡尺是空的");
        //        return;
        //    }

        //    if (_ICircleShuJu.Ho_Regions.IsInitialized())
        //    {
        //        _Set_CirleShuJu.Set_Show_DrawSpoke(_ICircleShuJu, halconWinControl_ROI1.HalconWindow1);
        //    }
        //}
        //#endregion
        #endregion

        #region  测量当前图片
        private void btn_ce_liang_dang_qian_tu_pian_Click(object sender, EventArgs e)
        {
            if ((halconWinControl_ROI1.Exit_Image() == false) || (!(_ICircleShuJu.Ho_Regions.IsInitialized())))
            {
                MessageBox.Show("图片是空的，或者卡尺是空的");
                return;
            }
            trigger_run();

        }
        #endregion

        #region  无用代码
        //#region  显示拟合圆
        //private void btn_show_ni_he_de_yuan_Click(object sender, EventArgs e)
        //{
        //    _Set_CirleShuJu.Set_show_Circle(_ICircleShuJu
        //        , halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        //#region  显示找到的点位
        //private void btn_show_zhao_dao_de_dian_Click(object sender, EventArgs e)
        //{
        //    _Set_CirleShuJu.Set_show_point(_ICircleShuJu, halconWinControl_ROI1.HalconWindow1);
        //}
        //#endregion

        //#region   确定卡尺参数
        //private void btn_que_ding_draw_spoke_can_shu_Click(object sender, EventArgs e)
        //{
        //    _Set_CirleShuJu.Set_CalliPers(_ICircleShuJu, Hv_Elements.Text, Hv_DetectHeight.Text, Hv_DetectWidth.Text);
        //}
        //#endregion

        //#region  确定测量参数  
        //private void btn_que_ding_spoke_can_shu_Click(object sender, EventArgs e)
        //{
        //    _Set_CirleShuJu.Set_Measure(_ICircleShuJu, Hv_ActiveNum.Text, Hv_Sigma.Text, Hv_Threshold.Text, Hv_Transition.Text, Hv_Select.Text);
        //}
        //#endregion
        #endregion

        #region  确定测量参数
        private void button_queDingCanShu_Click(object sender, EventArgs e)
        {
            if (!halconWinControl_ROI1.Exit_Image())
            {
                return;
            }
            _Set_CirleShuJu.Set_Measure(_ICircleShuJu, numericUpDown_Hv_Elements.Text, numericUpDown_Hv_DetectHeight.Text, numericUpDown_Hv_DetectWidth.Text, comboBox_Hv_Direct.Text, numericUpDown_startAngle.Value.ToString(), numericUpDown_endAngle.Value.ToString(), numericUpDown_Hv_ActiveNum.Text, comboBox_Hv_Sigma.Text, numericUpDown_Hv_Threshold.Text, comboBox_Hv_Transition.Text, comboBox_Hv_Select.Text);
            _Set_CirleShuJu.Set_ShowDrawSpoke2(halconWinControl_ROI1.Ho_Image, this._ICircleShuJu, halconWinControl_ROI1.HWindowControl.HalconWindow);
        }
        #endregion

        #region  roi移动是触发的事件
        /// <summary>
        ///  roi移动是触发的事件
        /// </summary>
        void ROIMoveEvent(HWindow _halconWindow1)
        {
            if (!halconWinControl_ROI1.Exit_Image())
            {
                return;
            }
            this._result.Clear();
            this._ICircleShuJu.analyze_show(this.halconWinControl_ROI1.HalconWindow1, "1", ref this._result);
            //_Circle.Spoke(_ICircleShuJu, halconWinControl_ROI1.Ho_Image);
            //_Circle.Circle_Show(_ICircleShuJu, halconWinControl_ROI1.HalconWindow1);
        }
        #endregion

        #region  无用代码
        //#region   刷新标定
        //private void toolStripButton_ShuaXinBiaoDing_Click(object sender, EventArgs e)
        //{
        //    this._Set_CirleShuJu.ShuaXinBiaoDing(this._ICircleShuJu);
        //}
        //#endregion
#endregion

    }
}
