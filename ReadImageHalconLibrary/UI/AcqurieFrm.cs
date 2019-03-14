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
using MultTree;
using LogClassLibrary;




namespace ReadImageHalconLibrary.UI
{
    public partial class AcqurieFrm : Form
    {
        #region    全局变量

        #region    循环运行的标志
        /// <summary>
        /// 循环运行的标志
        /// </summary>
        public bool _xun_huan_yun_xing_biao_zhi = false;
        #endregion

        #region   读图的数据
        /// <summary>
        /// 读图的数据
        /// </summary>
        //   public ReadImageHalcon.ReadImageShuJu.IReadShuJu _IRead;
        ReadImageHalconLibrary.IReadShuJu _IRead;
        #endregion

        #region  委托,事件
        /// <summary>
        /// 委托
        /// </summary>
        /// <returns></returns>
        delegate bool _run_delegate();

        /// <summary>
        /// 事件 
        /// </summary>
        event _run_delegate _read;

        #endregion

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #region   取图数据
        // ReadImageHalcon.ReadImageShuJu.SetReadShuJu Set_ReadShuJu = new ReadImageHalcon.ReadImageShuJu.SetReadShuJu();
        ReadImageHalconLibrary.SetReadShuJu Set_ReadShuJu = new ReadImageHalconLibrary.SetReadShuJu();
        #endregion

        //#region  取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //ReadImageHalconLibrary.IReadImage ReadImage = new ReadImageHalconLibrary.ReadImage();
        //#endregion

        #region   结果
        /// <summary>
        /// 结果
        /// </summary>
        Dictionary<string, Object> _result = new Dictionary<string, object>();

        #endregion

        #endregion

        #region   构造函数
        public AcqurieFrm()
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
            halconWinControl_11.init();
            _read += read_one_image;
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

            #region 初始化数据

            if (TreeStatic.Mult_Tree_Node_Picture != null)
            {
                if (TreeStatic.Mult_Tree_Node_Picture.SelfId.Contains("acquire"))
                {
                    _IRead = (ReadImageHalconLibrary.ReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;

                    #region  把图片写入

                    foreach (string file_name in _IRead.Path_Picture)
                    {
                        listBox_acquire_picture.Items.Add(file_name); //加载所有文件
                    }
                    #endregion
                }
                else
                {
                    _IRead = new ReadImageHalconLibrary.ReadShuJu();
                }
            }
            else
            {
                _IRead = new ReadImageHalconLibrary.ReadShuJu();
            }
            #endregion

            Set_ReadShuJu.Set_ReadShuJu_Parameter(_IRead, Controls);

        }
        #endregion

        #region  循环运行
        private void tSB_circulation_run_Click(object sender, EventArgs e)
        {
            string str = tSB_circulation_run.Text;
            if (str == "循环运行")
            {
                _xun_huan_yun_xing_biao_zhi = true;
                tSB_circulation_run.Text = "停止循环";

                trigger_read();

            }
            else
            {
                _xun_huan_yun_xing_biao_zhi = false;

                tSB_circulation_run.Text = "循环运行";
            }
        }
        #endregion

        #region     运行
        private void tSB_run_one_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 运行成功后回调
        /// </summary>
        //void run_callBack(IAsyncResult re)
        //{
        //    if (_xun_huan_yun_xing_biao_zhi)
        //    {
        //        timer_run.Enabled = true;
        //    }
        //}

        #endregion

        #region   读取一张图片事件

        bool read_one_image()
        {
            bool ok = false;
            try
            {
                _stopWatch.Restart();
                halconWinControl_11.Ho_Image.Dispose();
                //ReadImage.read_Image(_IRead);
                _result.Clear();
                _IRead.analyze_show(halconWinControl_11.HalconWindow1, "1", ref _result);
                halconWinControl_11.Ho_Image = _IRead.Ho_image;
                _stopWatch.Stop();

                Invoke(new Action(delegate
                {
                    m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();
                }));

                if (_xun_huan_yun_xing_biao_zhi == true)
                {
                    Thread thr = new Thread(new ThreadStart(trigger_read));
                    thr.Start();
                }

                #region   无用代码
                //int i = listBox_acquire_picture.Items.Count;
                //if (i > 0)
                //{
                //    if (_number_Image >= i)
                //    {
                //        _number_Image = 0;
                //    }

                //    ReadImageHalcon.Tool.readImage read = new ReadImageHalcon.Tool.readImage();
                //    listBox_acquire_picture.SelectedIndex = _number_Image;

                //    string path = listBox_acquire_picture.SelectedItem.ToString();
                //    _number_Image++;

                //    read.read_Image(path, halconWinControl_11.HalconWindow1);
                //    halconWinControl_11.Ho_Image = read.ho_Image;
                //    ok = true;

                //    if (_xun_huan_yun_xing_biao_zhi)
                //    {
                //        if (_read != null)
                //        {
                //            _read();
                //        }
                //    }
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

        #region    添加图片
        private void bnt_add_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open_file = new OpenFileDialog();
            open_file.Filter = "All files (*.*)|*.*|TIFF files (*.tif)|*tif";
            open_file.FilterIndex = 2;
            open_file.RestoreDirectory = true;
            open_file.Multiselect = true;
            open_file.ShowDialog();//打开对话框           

            if (listBox_acquire_picture.Items.Count != 0)//判断有无图片
            {
                listBox_acquire_picture.Items.Clear();//清空图片
            }

            if (_IRead.Path_Picture.Count != 0)
            {
                _IRead.Path_Picture.Clear();
            }

            foreach (string file_name in open_file.FileNames)
            {
                listBox_acquire_picture.Items.Add(file_name); //加载所有文件

                _IRead.Path_Picture.Add(file_name);

            }
        }
        #endregion

        #region     删除图片
        private void btn_delete_picture_Click(object sender, EventArgs e)
        {
            listBox_acquire_picture.Items.Clear();
        }
        #endregion

        #region    移除图片
        private void btn_remove_picture_Click(object sender, EventArgs e)
        {

        }
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

        #region  设置取图方式
        private void Acquire_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = Acquire.Text;
            Set_ReadShuJu.Set_Acquire(_IRead, str);
        }
        #endregion

        #region  确定注册表
        private void bnt_write_registry_Click(object sender, EventArgs e)
        {
            Set_ReadShuJu.Set_Registry(_IRead, Registry_width.Text, Registry_height.Text);
        }
        #endregion

    }
}
