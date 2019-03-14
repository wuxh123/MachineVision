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
//using MachineVision.ShuJuJieGou;
using System.Diagnostics;
using ReadImageHalconLibrary;
using MultTree;
using LogClassLibrary;




namespace TemplateHalconLibrary.UI
{
    public partial class TemplateFrm : Form
    {
        #region    全局变量

        //#region    循环运行的标志
        ///// <summary>
        ///// 循环运行的标志
        ///// </summary>
        //public bool _xun_huan_yun_xing_biao_zhi = false;
        //#endregion

        //#region  取图工具

        //#region   读图的数据
        ///// <summary>
        ///// 读图的数据
        ///// </summary>
        //IReadShuJu _IRe;
        //#endregion

        //#region  取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //IReadImage _IRead = new ReadImage();
        //#endregion

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
        /// 运行的算法
        /// </summary>
        event _run_delegate _run;

        #endregion

        #region   模板工具

        #region  模板匹配数据
        /// <summary>
        /// 模板匹配数据
        /// </summary>
        ITemplateShuJu _ITemplateShuJu;
        #endregion

        #region   设置模板数据工具
        /// <summary>
        /// 设置模板数据工具
        /// </summary>
        SetTemplateShuJu _SetTemplateShuJu;
        #endregion

        //#region   模板查找工具
        ///// <summary>
        ///// 模板查找工具
        ///// </summary>
        //Template _Template;
        //#endregion
        #endregion

        #region  结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();
        #endregion

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #endregion

        #region   构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public TemplateFrm()
        {
            InitializeComponent();
            halconWinControl_ROI1.init();
        }
        #endregion

        #region  初始化
        private void ParentFrm_Load(object sender, EventArgs e)
        {
            _read += read_one_image;
            _run += run;

            #region  无用代码
            #region  逻辑控制
            //_read_event = new AutoResetEvent(false);

            //_run_event = new AutoResetEvent(false);

            #endregion

            #region   初始化线程

            //_read_th = new Thread(new ThreadStart(read_one_image));
            //_read_th.Name = "取图线程";
            //_run_th = new Thread(new ThreadStart(run));
            //_run_th.Name = "检测线程";
            //_read_th.Start();
            //_run_th.Start();

            #endregion
            #endregion

            //#region 初始化数据

            //if (TreeStatic.Mult_Tree_Node_Picture != null)
            //{
            //    if (TreeStatic.Mult_Tree_Node_Picture.SelfId.Contains("acquire"))
            //    {
            //        _IRe = (ReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;

            //        #region  把图片写入

            //        foreach (string file_name in _IRe.Path_Picture)
            //        {
            //            listBox_acquire_picture.Items.Add(file_name); //加载所有文件
            //        }
            //        #endregion
            //    }
            //    else
            //    {
            //        _IRe = new ReadShuJu();
            //    }
            //}
            //else
            //{
            //    _IRe = new ReadShuJu();
            //}
            //#endregion

            #region   模板工具初始化
            _SetTemplateShuJu = new SetTemplateShuJu();
           
            #endregion

#if DEBUG == true
            if (TreeStatic.Mult_Tree_Node.Obj == null)
            {
                _ITemplateShuJu = new TemplateShuJu();
            }
            else
            {
                _ITemplateShuJu = (TemplateShuJu)TreeStatic.Mult_Tree_Node.Obj; ;
            }
#else
          _ITemplateShuJu = new TemplateShuJu();
#endif
            _SetTemplateShuJu.Show_parameter_HalconWinControl(_ITemplateShuJu, this.Controls, this.halconWinControl_ROI1);

        }
        #endregion

        #region   无用代码 
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
        /// 运行检测
        /// </summary>
        /// <returns></returns>
        bool run()
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            { return false; }

            _stopWatch.Restart();
            bool ok = false;

            //_Template.find_mode(_ITemplateShuJu, halconWinControl_ROI1.Ho_Image);
            //_Template.show_template(_ITemplateShuJu, halconWinControl_ROI1.HalconWindow1);
            this._result.Clear();
            this._ITemplateShuJu.analyze_show(halconWinControl_ROI1.HalconWindow1, "1", ref _result);

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
        /// 读取一张图片
        /// </summary>
        /// <returns></returns>
        bool read_one_image()
        {
            bool ok = false;
            try
            {
                _stopWatch.Restart();
                #region  无用代码
                //if (!halconWinControl_ROI1.Exit_Image())//防止空图片
                //{
                //    halconWinControl_ROI1.Ho_Image.Dispose();
                //    //_IRead.read_Image(_IRe);                  
                //}                
                //halconWinControl_ROI1.Ho_Image = _IRe.Ho_image;
                #endregion
                halconWinControl_ROI1.Ho_Image = this._ITemplateShuJu.ImageFather.Ho_image;
                _stopWatch.Stop();
                #region  无用代码
                //if (_xun_huan_yun_xing_biao_zhi)
                //{
                //    trigger_run();
                //}
                #endregion
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

        //    if (_IRe.Path_Picture.Count != 0)
        //    {
        //        _IRe.Path_Picture.Clear();
        //    }

        //    foreach (string file_name in open_file.FileNames)
        //    {
        //        listBox_acquire_picture.Items.Add(file_name); //加载所有文件

        //        _IRe.Path_Picture.Add(file_name);

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

        #region 设置模板参数
        private void bnt_SaveFind_Click(object sender, EventArgs e)
        {
            _SetTemplateShuJu.Set_FindModelParameter(_ITemplateShuJu, numericUpDown_FindAngleStart.Text, numericUpDown_FindAngleExtent.Text, numericUpDown_FindMinScore.Text,
                numericUpDown_FindNumMatches.Text, numericUpDown_FindMaxOverlap.Text, FindSubPixel.Text, numericUpDown_FindNumLevels.Text, numericUpDown_FindGreediness.Text);

        }
        #endregion

        #region   涂抹模板区域
        private void bnt_ExtractRegion_Click(object sender, EventArgs e)
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            {
                MessageBox.Show("当前图片是空的");
                return;
            }
            _SetTemplateShuJu._IExtractModel.PrintScreenTool(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);
            _SetTemplateShuJu._IExtractModel.ExtractModelXLD(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);
        }
        #endregion

        #region 确定提取模板参数
        private void bnt_SureExtractModelContoursParameter_Click(object sender, EventArgs e)
        {
            _SetTemplateShuJu._IExtractModel.Set_ExtractModel(_ITemplateShuJu.IExtractModel, null, comboBox_Fiter.Text, numericUpDown_Aplha.Text, comboBox_Low.Text, comboBox_High.Text, null, null, null, null, null);
            _SetTemplateShuJu._IExtractModel.EdgesSubPix(halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);
            _SetTemplateShuJu._IExtractModel.ExtractModelXLD(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);

        }
        #endregion

        #region   确定过滤模板轮廓参数
        private void bnt_SureFilterParameter_Click(object sender, EventArgs e)
        {
            _SetTemplateShuJu._IExtractModel.Set_ExtractModel(_ITemplateShuJu.IExtractModel, null, null, null, null, null, comboBox_Feature.Text, numericUpDown_Min1.Text, numericUpDown_Max1.Text, numericUpDown_Min2.Text, numericUpDown_Max2.Text);
            _SetTemplateShuJu._IExtractModel.ExtractModelXLD(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);

        }
        #endregion

        //#region 提取模板轮廓
        //private void bnt_ExtracXLDtModel_Click(object sender, EventArgs e)
        //{
        //    _SetTemplateShuJu._IExtractModel.ExtractModelXLD(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);
        //}
        //#endregion

        #region   确定创建模板的参数
        private void bnt_SaveCreateXLDModelParameter_Click(object sender, EventArgs e)
        {
            _SetTemplateShuJu._ITemplateCreate.Set_TemplateCreate(_ITemplateShuJu.ITemplateCreate, null, comboBox_CreateNumLevels.Text, numericUpDown_CreateAngleStart.Text, numericUpDown_CreateAngleExtent.Text, comboBox_CreateAngleStep.Text, comboBox_CreateOptimization.Text, comboBox_CreateMetric.Text, numericUpDown_CreateMinContrast.Text);
            if (_SetTemplateShuJu.Set_TemplateCreate(_ITemplateShuJu, TextBox_Create_ModelName.Text))
            {
                _SetTemplateShuJu.WriteShapeModel(_ITemplateShuJu);
            }
        }
        #endregion

        //#region  创建模板
        //private void bnt_CreateXLDModel_Click(object sender, EventArgs e)
        //{
        //    bnt_CreateXLDModel.Text = "正在创建模板。。。";
        //    //_ITemplateShuJu.ITemplateCreate.ModelName = Create_ModelName.Text;
        //    _SetTemplateShuJu.Set_TemplateCreate(_ITemplateShuJu, Create_ModelName.Text);
        //    bnt_CreateXLDModel.Text = "创建模板";
        //    trigger_run();
        //}
        //#endregion

        #region  显示涂抹
        private void bnt_show_painting_picture_Click(object sender, EventArgs e)
        {
            halconWinControl_ROI1.HalconWindow1.ClearWindow();
            if (_ITemplateShuJu.IExtractModel.PrintScreenImage != null)
            {
                halconWinControl_ROI1.HalconWindow1.DispObj(_ITemplateShuJu.IExtractModel.PrintScreenImage);
            }
        }
        #endregion

        #region  显示涂抹的区域
        private void bnt_show_painting_region_Click(object sender, EventArgs e)
        {
            if (_ITemplateShuJu.IExtractModel.PrintScreenRegionXLD != null)
            {
                halconWinControl_ROI1.HalconWindow1.DispObj(_ITemplateShuJu.IExtractModel.PrintScreenRegionXLD);
            }
        }
        #endregion

        #region  清空涂抹的区域
        private void bnt_clear_prainting_region_Click(object sender, EventArgs e)
        {
            if (halconWinControl_ROI1.Exit_Image() == false)
            {
                MessageBox.Show("图片是空的");
                return;
            }

            _SetTemplateShuJu._IExtractModel.ClearExtractModel(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);
        }
        #endregion

        //#region  显示模板轮廓
        //private void bnt_show_ExtracXLDtModel_Click(object sender, EventArgs e)
        //{
        //    halconWinControl_ROI1.HalconWindow1.DispObj(_ITemplateShuJu.IExtractModel.SelectedContours);
        //}
        //#endregion

        //#region 确定提取模板参数 显示结果
        //private void bnt_show_extract_edges_Click(object sender, EventArgs e)
        //{
        //    _SetTemplateShuJu._IExtractModel.EdgesSubPix(halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);
        //    //halconWinControl_Draw1.HalconWindow1.DispObj(_ITemplateShuJu.IExtractModel.Edges);
        //}
        //#endregion

        //#region 确定过滤模板轮廓参数  显示结果
        //private void bnt_show_fiter_selectcontour_Click(object sender, EventArgs e)
        //{
        //    #region   无用代码
        //    //_SetTemplateShuJu._IExtractModel.SelectXLD(halconWinControl_Draw1.Ho_Image, halconWinControl_Draw1.HalconWindow1, _ITemplateShuJu.IExtractModel);
        //    //halconWinControl_Draw1.HalconWindow1.DispObj(_ITemplateShuJu.IExtractModel.SelectedContours);
        //    #endregion

        //    _SetTemplateShuJu._IExtractModel.ExtractModelXLD(halconWinControl_ROI1.Ho_Image, halconWinControl_ROI1.HalconWindow1, _ITemplateShuJu.IExtractModel);

        //}
        //#endregion

        //#region 保存模板
        //private void bnt_Save_Template_Click(object sender, EventArgs e)
        //{
        //    _SetTemplateShuJu.WriteShapeModel(_ITemplateShuJu);
        //}
        //#endregion

        #region  确定画笔大小
        private void bnt_sure_printScreen_R_Click(object sender, EventArgs e)
        {
            _SetTemplateShuJu._IExtractModel.Set_ExtractModel(_ITemplateShuJu.IExtractModel, numericUpDown_PrintScreen_R.Text, null, null, null, null, null, null, null, null, null);
        }
        #endregion

        #region    刷新定位点
        private void toolStripButton_ShuaXinDingWeiDian_Click(object sender, EventArgs e)
        {
            this._SetTemplateShuJu.Set_ShuaXinDingWeiDian(this._ITemplateShuJu);
        }
        #endregion

        #region  创建模板
        private void toolStripButton_chuangJianMuBan_Click(object sender, EventArgs e)
        {
            toolStripButton_chuangJianMuBan.Text = "正在创建模板";

            if (_SetTemplateShuJu.Set_TemplateCreate(_ITemplateShuJu, TextBox_Create_ModelName.Text))
            {
                _SetTemplateShuJu.WriteShapeModel(_ITemplateShuJu);
                toolStripButton_chuangJianMuBan.Text = "模板创建成功";
            }
            else
            {
                toolStripButton_chuangJianMuBan.Text = "模板创建失败";
            }
        }
        #endregion
    }
}
