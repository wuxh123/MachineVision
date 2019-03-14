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
using System.Runtime.InteropServices;
using ReadImageHalconLibrary;
using LogClassLibrary;
using MultTree;
using ThridLibray;




namespace DaHuaLibrary.UI
{
    public partial class DaHuaCamerFrm : Form
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
        private IReadShuJu _re;
        #endregion

        //#region   取图工具
        ///// <summary>
        ///// 取图工具
        ///// </summary>
        //private IReadImage _IRead=new ReadImage();
        //#endregion

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
        /// <summary>
        /// 重置相机流数据
        /// </summary>
        event _run_delegate _clear_camer_stream;


        #endregion

        #region   检测时间
        /// <summary>
        /// 检测时间
        /// </summary>
        Stopwatch _stopWatch = new Stopwatch();
        #endregion

        #region   相机驱动
        /// <summary>
        /// 相机驱动
        /// </summary>
        Camer.IDaHua _IDaHua;
       
        /// <summary>
        /// 设置相机驱动参数
        /// </summary>
        Camer.Set_DaHua_Date _Set_DaHua;
        #endregion

        #endregion

        #region   构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="IDaHua_"></param>
        public DaHuaCamerFrm(Camer.IDaHua IDaHua_ )
        {
            InitializeComponent();
            _IDaHua = IDaHua_;
        }
        #endregion

        #region  初始化   
        private void ParentFrm_Load(object sender, EventArgs e)
        {
            try
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
                        _re = (ReadShuJu)TreeStatic.Mult_Tree_Node_Picture.Obj;
                        
                        #region  把图片写入
                        foreach (string file_name in _re.Path_Picture)
                        {
                            listBox_acquire_picture.Items.Add(file_name); //加载所有文件
                        }
                        #endregion

                    }
                    else
                    {
                        _re = new ReadShuJu();
                    }
                }
                else
                {
                    _re = new ReadShuJu();
                }
                #endregion

                #region  设置相机参数工具
                _Set_DaHua = new Camer.Set_DaHua_Date();
                #endregion

#if DEBUG == true
                //_IDaHua = MachineVision.MainStatic.MainStatic.DaHua_Date_One1;
                //MachineVision.MainStatic.MainStatic.DaHua_Date_One1.Dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;
#region 无用代码

            //if (TreeStatic.Mult_Tree_Node.Obj == null)
            //{
            //    /*BarCodeHalcon.BarCodeShuJu.IBarCodeShuJu su = new BarCodeHalcon.BarCodeShuJu.BarCodeShuJu();*/
            //    _IDaHua = new Camer.DaHua.DaHua_Date();
            //}
            //else
            //{
            //    _IDaHua = (Camer.DaHua.DaHua_Date)TreeStatic.Mult_Tree_Node.Obj; ;
            //}
#endregion 
#else
                string str = "";
                // BarCodeHalcon.BarCodeShuJu.IBarCodeShuJu su = new BarCodeHalcon.BarCodeShuJu.BarCodeShuJu();
               // _IDaHua = new Camer.DaHua_Date();
                _Set_DaHua.open_camer(_IDaHua, _IDaHua.CamerIndx1, OnCameraOpen, null, OnConnectLoss, ref str);
               
                if (str == "")
                {                  
                    MessageBox.Show("相机打开成功");
                }
#endif
                _Set_DaHua.show_DaHua_ShuJu(_IDaHua, Controls);
                _IDaHua.Dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "初始化报错");
            }

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
        
        #region   无用代码
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

        #endregion

        #region   读取一张图片事件

        bool read_one_image()
        {
            bool ok = false;
            try
            {
                _stopWatch.Restart();
                halconWinControl_11.Ho_Image.Dispose();
                //_IRead.read_Image(_re);
               Dictionary<string ,Object> dis_=new Dictionary<string,object>();
               _re.analyze_show(halconWinControl_11.HalconWindow1, "1", ref dis_);
                halconWinControl_11.Ho_Image= _re.Ho_image;
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
                MessageBox.Show("取图片一张出错:"+ex.Message);
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
            _IDaHua.Dev.StreamGrabber.ImageGrabbed -= OnImageGrabbed;
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

            if (_re.Path_Picture.Count!=0)
            {
                _re.Path_Picture.Clear();
            }

            foreach (string file_name in open_file.FileNames)
            {
                listBox_acquire_picture.Items.Add(file_name); //加载所有文件

                _re.Path_Picture.Add(file_name);

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
        
        #region 确定相机曝光跟增益
        private void bnt_que_ding_xiangji_bao_guang_Click(object sender, EventArgs e)
        {
            double ex = Convert.ToDouble(Exposuretime.Text);
            double ga = Convert.ToDouble(Gainraw.Text);
            _Set_DaHua.set_exposuretime_gainraw(_IDaHua, ex, ga);
        }
        #endregion

        #region   软触发相机
        private void tSB_trigger_Click(object sender, EventArgs e)
        {
            _IDaHua.ExecuteSoftwareTrigger();
        }
        #endregion

        #region  获取相机驱动个数
        private void button1_Click(object sender, EventArgs e)
        {
            int number = 0;
            _Set_DaHua.get_camer_number(ref number);
            Device_Number.Text = number.ToString();
        }
        #endregion

        #region   相机取图回调函数
        /// <summary>
        /// 相机取图写入注册表后回调事件
        /// </summary>
        /// <param name="ptr"></param>
        public void OnImageGrabbed(Object sender, GrabbedEventArgs e)
        {
            try
            {
                if (_re.Acquire_Image == Acquire.Folder_Image)
                {
                    MessageBox.Show("当前取图方式不是注册表取图，请先设置成注册表取图");
                    return;
                }

                _stopWatch.Restart();
                HObject ho_Image;
                HOperatorSet.GenEmptyObj(out ho_Image);
                IntPtr ptr = Marshal.AllocHGlobal(Convert.ToInt32(_re._Width* _re._Height));
                var frame = e.GrabResult;
                Marshal.Copy(frame.Image, 0, ptr, Convert.ToInt32(_re._Width * _re._Height));
                HOperatorSet.GenImage1(out ho_Image, "byte",_re._Width,_re._Height, ptr);
                Marshal.FreeHGlobal(ptr);
                halconWinControl_11.HalconWindow1.DispObj(ho_Image);
                halconWinControl_11.Ho_Image.Dispose();
                halconWinControl_11.Ho_Image = ho_Image;
            
                _stopWatch.Stop();

                BeginInvoke(new Action(delegate
                {
                    m_CtrlHStatusLabelCtrl.Text = _stopWatch.ElapsedMilliseconds.ToString();
                    _IDaHua.ResetCamerStream();
                }));              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
                
        /// <summary>
        /// 相机打开回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraOpen(object sender, EventArgs e)
        {
            MessageBox.Show("打开相机ok");
        }
        
        /// <summary>
        /// 相机关闭回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCameraClose(object sender, EventArgs e)
        {
            MessageBox.Show("相机关闭");
        }
      
        /// <summary>
        ///  相机丢失回调
        /// </summary>
        private void OnConnectLoss()
        {
            MessageBox.Show("相机丢失");
        }
        #endregion

        #region 设置相机的触发方式
        private void TriggerSourceenum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ss =TriggerSourceenum.Text;
            _Set_DaHua.set_trigger(_IDaHua, ss);
        }
        #endregion 

    }
}
