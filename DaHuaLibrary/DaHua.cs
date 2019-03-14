using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ThridLibray;
using System.IO;



namespace DaHuaLibrary.Camer
{
    #region  委托
    /// <summary>
    /// 相机丢失委托
    /// </summary>
    public delegate void delegate_OnConnectLoss();

    #endregion

    #region  驱动数据
    /// <summary>
    /// 驱动数据
    /// </summary>
    [Serializable]
    public class DaHua_Date : IDaHua
    {
        #region  无用代码
        #region 相机图片缓存
        ///// <summary>
        ///// 相机图片缓存
        ///// </summary>
        //HObject ho_Image;
        ///// <summary>
        ///// 相机图片缓存
        ///// </summary>
        //public HObject Ho_Image
        //{
        //    get { return ho_Image; }
        //    set { ho_Image = value; }
        //}
        #endregion

        #region  无用代码
        #region 码流数据回调
        /// <summary>
        /// 码流数据回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //public void OnImageGrabbed(Object sender, GrabbedEventArgs e)
        //{
        //    try
        //    {
        //        // 原始数据转换为bitmap
        //        var frame = e.GrabResult;

        //        IntPtr ptr = Marshal.AllocHGlobal(Convert.ToInt32(Camer.DaHua.DaHua_Date.STRIDE * Camer.DaHua.DaHua_Date.NUMROWS));
        //        Marshal.Copy(frame.Image, 0, ptr, Convert.ToInt32(Camer.DaHua.DaHua_Date.STRIDE * Camer.DaHua.DaHua_Date.NUMROWS));
        //        Application.DoEvents();

        //        //ho_Image.Dispose();
        //        //HOperatorSet.GenImage1(out ho_Image, "byte", Camer.DaHua.DaHua_Date.STRIDE, Camer.DaHua.DaHua_Date.NUMROWS, ptr);
        //       // Marshal.FreeHGlobal(ptr);                

        //        if (event_OnImageGrabbed != null)
        //        {
        //            event_OnImageGrabbed(ref ptr);
        //        }

        //        #region  无用代码
        //        //IntPtr mmfPtr = (IntPtr)m_rawPtr[0];
        //        //Marshal.Copy(frame.Image, 0, mmfPtr, Convert.ToInt32(STRIDE * NUMROWS));
        //        //  VirtualTrigger(1);
        //        //// 转换帧数据为Bitmap
        //        //// var bitmap = e.GrabResult.ToBitmap(false);
        //        //var bmp = _Display.ToBmp(frame.Raw, frame.ImageSize, frame.Width, frame.Height, frame.PixelFmt);

        //        //// 显示图片数据
        //        //if (InvokeRequired)
        //        //{
        //        //    BeginInvoke(new MethodInvoker(() =>
        //        //    {
        //        //        try
        //        //        {
        //        //            _Display.Pain(bmp, pbImage.Handle);
        //        //            bmp.Dispose();
        //        //        }
        //        //        catch (Exception exception)
        //        //        {
        //        //          //  Catcher.Show(exception);
        //        //        }
        //        //    }));
        //        //}
        //        #endregion
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.ToString());
        //    }
        //}
        #endregion
        #endregion
        #endregion

        #region 大华相机驱动
        #region   大华相机驱动
        /// <summary>
        /// 大华相机驱动
        /// </summary>
        private ThridLibray.IDevice m_dev;
        #endregion

        #region   无用代码
        /// <summary>
        /// 图像绘制
        /// </summary>
        //  private Graphics _g = null;

        /// <summary>
        /// 显示工具类
        /// </summary>
        // private IDisplay _Display = Tools.CreateDisplay();
        #endregion

        #region 相机曝光
        /// <summary>
        /// 相机曝光
        /// </summary>
        double exposuretime = 500;
        #endregion

        #region    相机增益
        /// <summary>
        /// 相机增益
        /// </summary>
        double gainraw = 1;
        #endregion

        #region  相机触发模式
        /// <summary>
        /// 相机触发模式
        /// </summary>
        string triggerSourceenum = TriggerSourceEnum.Line1;
        #endregion

        #region  第几个相机
        int CamerIndx;
        #endregion
        #endregion

        #region 静态相机像素
        /// <summary>
        /// Number of pixel columns in camera
        /// </summary>
        static public uint STRIDE = 3000;               /* Number of pixel columns in camera */

        /// <summary>
        /// Number of pixel rows in image
        /// </summary>
        static public uint NUMROWS = 1700;            /* Number of pixel rows in image */

        /// <summary>
        /// Number of pixel rows in image
        /// </summary>
        static public uint ImageHeight = 1700;

        #endregion

        #region   大华相机驱动

        #region  大华相机驱动
        /// <summary>
        /// 大华相机驱动
        /// </summary>
        public ThridLibray.IDevice Dev
        {
            get { return m_dev; }
            set { m_dev = value; }
        }
        #endregion

        #region  相机曝光
        /// <summary>
        /// 相机曝光
        /// </summary>
        public double Exposuretime
        {
            get
            {
                return exposuretime;
            }

            set
            {
                exposuretime = value;
            }
        }
        #endregion

        #region   相机增益
        /// <summary>
        /// 相机增益
        /// </summary>
        public double Gainraw
        {
            get
            {
                return gainraw;
            }

            set
            {
                gainraw = value;
            }
        }
        #endregion

        #region   触发模式
        /// <summary>
        /// 触发模式
        /// </summary>
        public string TriggerSourceenum
        {
            get
            {
                return triggerSourceenum;
            }

            set
            {
                triggerSourceenum = value;
            }
        }

        #endregion

        #region  第几个相机
        /// <summary>
        /// 第几个相机
        /// </summary>
        public int CamerIndx1
        {
            get
            {
                return CamerIndx;
            }

            set
            {
                CamerIndx = value;
            }
        }
        #endregion

        #endregion

        #region  无用代码
        #region 图像绘制
        /// <summary>
        /// 图像绘制
        /// </summary>
        //public Graphics G
        //{
        //    get { return _g; }
        //    set { _g = value; }
        //}
        #endregion

        #region 显示工具类
        /// <summary>
        /// 显示工具类
        /// </summary>
        //public IDisplay Display
        //{
        //    get { return _Display; }
        //    set { _Display = value; }
        //}
        #endregion
        #endregion

        #region 事件
        /// <summary>
        /// 相机丢失事件
        /// </summary>
        public event delegate_OnConnectLoss event_OnConnectLoss;
        #endregion

        #region   软触发相机
        /// <summary>
        /// 软触发相机
        /// </summary>
        /// <returns></returns>
        public bool ExecuteSoftwareTrigger()
        {
            bool ok = false;

            if (m_dev == null)
            {
                throw new InvalidOperationException("Device is invalid");
                return ok;
            }

            try
            {
                m_dev.ExecuteSoftwareTrigger();
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
            }
            ok = true;
            return ok;
        }
        #endregion

        #region  相机丢失回调
        /// <summary>
        /// 相机丢失回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnConnectLoss(object sender, EventArgs e)
        {
            m_dev.ShutdownGrab();
            m_dev.Dispose();
            m_dev = null;
            if (event_OnConnectLoss != null)
            {
                event_OnConnectLoss();
            }
        }
        #endregion

        #region  重启流数据，清空流缓存、
        /// <summary>
        /// 重启流数据，清空流缓存、
        /// </summary>
        /// <returns></returns>
        public bool ResetCamerStream()
        {
            bool ok = false;


            if (!Dev.StreamGrabber.Stop())
            {
                // System.Windows.MessageBox.Show(@"关闭码流失败",this.ToString());
                MessageBox.Show("关闭码流失败", this.ToString());
                return ok;
            }

            Thread.Sleep(40);


            if (!Dev.StreamGrabber.Start())
            {
                //  MessageBox.Show(@"开启码流失败",this.ToString());
                MessageBox.Show("开始码流失败", this.ToString());

                return ok;
            }
            ok = true;
            return ok;
        }


        #endregion

    }
    #endregion

    #region 接口
    /// <summary>
    /// 数据接口
    /// </summary>
    public interface IDaHua
    {
        #region  无用代码
        ///// <summary>
        ///// 相机图片缓存
        ///// </summary>
        //HObject Ho_Image
        //{
        //    get;
        //    set;
        //}

        #region  无用代码
        #region 图像绘制
        /// <summary>
        /// 图像绘制
        /// </summary>
        //Graphics G
        //{
        //    get;
        //    set;
        //}
        #endregion

        #region  显示工具类
        /// <summary>
        /// 显示工具类
        /// </summary>
        //IDisplay Display
        //{
        //    get;
        //    set;
        //}
        #endregion
        #endregion


        #region 无用代码
        #region 码流数据回调
        /// <summary>
        /// 码流数据回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //  void OnImageGrabbed(Object sender, GrabbedEventArgs e);

        #endregion
        #endregion
        #endregion

        #region   大华相机驱动
        /// <summary>
        /// 大华相机驱动
        /// </summary>
        ThridLibray.IDevice Dev
        {
            get;
            set;
        }
        #endregion

        #region   相机曝光
        /// <summary>
        /// 相机曝光
        /// </summary>
        double Exposuretime
        {
            get
           ;
            set
            ;
        }
        #endregion

        #region  相机增益
        /// <summary>
        /// 相机增益
        /// </summary>
        double Gainraw
        {
            get
          ;
            set
          ;
        }
        #endregion

        #region   相机触发模式
        /// <summary>
        /// 触发模式
        /// </summary>
        string TriggerSourceenum
        {
            get
         ;
            set
          ;
        }

        #endregion

        #region   第几个相机
        /// <summary>
        /// 第几个相机
        /// </summary>
        int CamerIndx1
        {
            get
          ;
            set
         ;
        }
        #endregion

        #region   软触发相机
        /// <summary>
        /// 软触发相机
        /// </summary>
        /// <returns></returns>
        bool ExecuteSoftwareTrigger();
        #endregion

        #region 事件
        // delegate void delegate_OnConnectLoss();
        /// <summary>
        /// 相机丢失事件
        /// </summary>
        event delegate_OnConnectLoss event_OnConnectLoss;

        #endregion

        #region  相机丢失回调
        /// <summary>
        /// 相机丢失回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnConnectLoss(object sender, EventArgs e);
        #endregion

        #region  重启流数据，清空流缓存、
        /// <summary>
        /// 重启流数据，清空流缓存、
        /// </summary>
        /// <returns></returns>
        bool ResetCamerStream();
        #endregion

    }
    #endregion

    #region  设置相机参数
    /// <summary>
    /// 设置相机参数
    /// </summary>
    public class Set_DaHua_Date
    {
        #region 打开一个相机驱动
        /// <summary>
        /// 打开一个相机驱动,
        /// </summary>
        /// <param name="IDa"></param>
        /// <param name="camer_number"></param>
        /// <param name="CameraOpened"></param>
        /// <param name="CameraClosed"></param>
        /// <param name="event_OnConnectLoss"></param>
        /// <param name="event_OnImageGrabbed"></param>
        /// <param name="result"></param>
        public void open_camer(IDaHua IDa, int camer_number, EventHandler<EventArgs> CameraOpened,
            EventHandler<EventArgs> CameraClosed, delegate_OnConnectLoss event_OnConnectLoss
            , ref string result)
        {
            try
            {
                int number = 0;
                get_camer_number(ref number);
                if (number > 0)
                {
                    if (camer_number < number)
                    {
                        #region 检测打开的相机是否有配置的数据
                        #region  无用代码
                        //string filename="Camer" + camer_number.ToString();
                        //Config.IniFile.IniFiles inifiles = new Config.IniFile.IniFiles(ref filename,"DaHua", null);
                        //if (File.Exists(inifiles.FileName_Path1))
                        //{
                        //    IDa.CamerIndx1 = Convert.ToInt16(inifiles.ReadString(IDa.ToString(), "CamerIndx1", IDa.CamerIndx1.ToString()));
                        //    IDa.TriggerSourceenum= inifiles.ReadString(IDa.ToString(), "TriggerSourceenum", IDa.TriggerSourceenum);
                        //    IDa.Exposuretime=Convert.ToDouble(inifiles.ReadString(IDa.ToString(), "Exposuretime", IDa.Exposuretime.ToString()));
                        //    IDa.Gainraw=Convert.ToDouble(inifiles.ReadString(IDa.ToString(), "Gainraw", IDa.Gainraw.ToString()));
                        //}
                        //else
                        //{
                        //    inifiles.WriteString(IDa.ToString(), "CamerIndx1", camer_number.ToString());
                        //    inifiles.WriteString(IDa.ToString(), "TriggerSourceenum", IDa.TriggerSourceenum);
                        //    inifiles.WriteString(IDa.ToString(), "Exposuretime", IDa.Exposuretime.ToString());
                        //    inifiles.WriteString(IDa.ToString(), "Gainraw", IDa.Gainraw.ToString());
                        //}
                        #endregion
                        load_DaHua_ShuJu(IDa, camer_number);
                        #endregion
                        IDa.Dev = Enumerator.GetDeviceByIndex(camer_number);
                        // 注册链接时间

                        if (CameraOpened != null)
                        {
                            IDa.Dev.CameraOpened += CameraOpened;
                        }

                        IDa.Dev.ConnectionLost += IDa.OnConnectLoss; ;

                        if (CameraClosed != null)
                        {
                            IDa.Dev.CameraClosed += CameraClosed;
                        }

                        if (event_OnConnectLoss != null)
                        {
                            IDa.event_OnConnectLoss += event_OnConnectLoss;
                        }

                        //if (event_OnImageGrabbed != null)
                        //{
                        //    IDa.event_OnImageGrabbed += event_OnImageGrabbed;
                        //}

                        // 打开设备
                        if (!IDa.Dev.Open())
                        {
                            result = "设备打开失败";
                            return;
                        }

                        // 打开Software Trigger
                        // IDa.Dev.TriggerSet.Open(TriggerSourceEnum.Line1);

                        IDa.Dev.TriggerSet.Open(IDa.TriggerSourceenum);

                        /* 设置图像格式 */
                        using (IEnumParameter p = IDa.Dev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
                        {
                            p.SetValue("Mono8");
                        }

                        /* 设置曝光 */
                        using (IFloatParameter p = IDa.Dev.ParameterCollection[ParametrizeNameSet.ExposureTime])
                        {
                            p.SetValue(IDa.Exposuretime);
                        }

                        /* 设置增益 */
                        using (IFloatParameter p = IDa.Dev.ParameterCollection[ParametrizeNameSet.GainRaw])
                        {
                            p.SetValue(IDa.Gainraw);
                        }

                        /* 设置缓存个数为8（默认值为16） */
                        IDa.Dev.StreamGrabber.SetBufferCount(8);

                        // 注册码流回调事件
                        //    IDa.Dev.StreamGrabber.ImageGrabbed +=IDa.OnImageGrabbed;

                        /* 开启码流 */
                        if (!IDa.Dev.GrabUsingGrabLoopThread())
                        {
                           MessageBox.Show(@"开启码流失败");
                            return;
                        }
                    }
                    else
                    {
                        result = "绑定相机number大于相机实际个数";
                    }
                }
                else
                {
                    result = "相机驱动个数为零";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开相机报错：" + ex.Message, this.ToString());
            }
        }
        #endregion

        #region 设计相机曝光
        /// <summary>
        /// 设置相机曝光
        /// </summary>
        /// <param name="IDa"></param>
        /// <param name="exposuretime"></param>
        /// <param name="gainraw"></param>
        /// <returns></returns>
        public bool set_exposuretime_gainraw(IDaHua IDa, double exposuretime, double gainraw)
        {
            bool ok = false;

            if (exposuretime != 0)
            {
                /* 设置曝光 */
                using (IFloatParameter p = IDa.Dev.ParameterCollection[ParametrizeNameSet.ExposureTime])
                {
                    p.SetValue(exposuretime);
                }
            }

            if (gainraw != 0)
            {
                /* 设置增益 */
                using (IFloatParameter p = IDa.Dev.ParameterCollection[ParametrizeNameSet.GainRaw])
                {
                    p.SetValue(1.0);
                }
            }
            Save_DaHua_ShuJu(IDa);

            ok = true;
            return ok;
        }
        #endregion

        #region   获取驱动个数
        /// <summary>
        /// 获取驱动个数
        /// </summary>
        /// <param name="number"></param>
        public void get_camer_number(ref int number)
        {
            List<IDeviceInfo> li = Enumerator.EnumerateDevices();
            number = li.Count;
        }
        #endregion

        #region 关闭相机
        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <param name="IDa"></param>
        /// <returns></returns>
        public bool close_camer(IDaHua IDa)
        {
            bool ok = false;
            try
            {
                if (IDa.Dev == null)
                {
                    throw new InvalidOperationException("Device is invalid");
                }

                IDa.Dev.ShutdownGrab();

                IDa.Dev.Close();
                ok = true;
            }
            catch (Exception exception)
            {
                Catcher.Show(exception);
            }
            ok = true;
            return ok;
        }
        #endregion

        #region   设置相机触发模式
        /// <summary>
        /// 设置相机触发模式
        /// </summary>
        /// <param name="IDa"></param>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public bool set_trigger(IDaHua IDa, string TriggerSource /*TriggerSourceEnum trigger*/)
        {
            bool ok = false;
            /* 打开Software Trigger */
            // IDa.Dev.TriggerSet.Open(TriggerSourceEnum.Software);
            IDa.Dev.TriggerSet.Open(TriggerSource);
            Save_DaHua_ShuJu(IDa);
            ok = true;
            return ok;
        }
        #endregion

        #region    显示数据
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="IDaHua">数据接口</param>
        /// <param name="control">控件</param>
        /// <returns></returns>
        public bool show_DaHua_ShuJu(IDaHua IDaHua, Control.ControlCollection control)
        {
            bool ok = false;
            try
            {
                foreach (Control con in control)
                {
                    string name = con.Name;
                    if ((con is ComboBox) || (con is TextBox))
                    {
                        switch (name)
                        {
                            case "TriggerSourceenum":

                                con.Text = IDaHua.TriggerSourceenum;

                                break;

                            case "Gainraw":
                                con.Text = IDaHua.Gainraw.ToString();
                                break;
                            case "CamerIndx1":
                                con.Text = IDaHua.CamerIndx1.ToString();
                                break;
                            case "Exposuretime":
                                con.Text = IDaHua.Exposuretime.ToString();
                                break;

                            default:
                                break;
                        }
                    }

                    if (con.Controls.Count > 0)
                    {
                        show_DaHua_ShuJu(IDaHua, con.Controls);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.ToString());
            }

            ok = true;
            return ok;
        }
        #endregion

        #region  加载相机配置
        /// <summary>
        /// 加载相机配置
        /// </summary>
        /// <param name="IDa">相机参数</param>
        /// <param name="camer_number">加载第几个相机配置</param>
        void load_DaHua_ShuJu(IDaHua IDa, int camer_number)
        {

            string filename = "Camer" + camer_number.ToString();
            IniLibrary.IniTool inifiles = new IniLibrary.IniTool(ref filename, "DaHua", null);
            if (File.Exists(inifiles.FileName_Path1))
            {
                IDa.CamerIndx1 = Convert.ToInt16(inifiles.ReadString(IDa.ToString(), "CamerIndx1", IDa.CamerIndx1.ToString()));
                IDa.TriggerSourceenum = inifiles.ReadString(IDa.ToString(), "TriggerSourceenum", IDa.TriggerSourceenum);
                IDa.Exposuretime = Convert.ToDouble(inifiles.ReadString(IDa.ToString(), "Exposuretime", IDa.Exposuretime.ToString()));
                IDa.Gainraw = Convert.ToDouble(inifiles.ReadString(IDa.ToString(), "Gainraw", IDa.Gainraw.ToString()));
            }
            else
            {
                inifiles.WriteString(IDa.ToString(), "CamerIndx1", camer_number.ToString());
                inifiles.WriteString(IDa.ToString(), "TriggerSourceenum", IDa.TriggerSourceenum);
                inifiles.WriteString(IDa.ToString(), "Exposuretime", IDa.Exposuretime.ToString());
                inifiles.WriteString(IDa.ToString(), "Gainraw", IDa.Gainraw.ToString());
            }
        }

        #endregion

        #region  保存驱动数据
        /// <summary>
        /// 保存驱动数据
        /// </summary>
        /// <param name="IDaHua">数据</param>
        /// <returns></returns>
        public bool Save_DaHua_ShuJu(IDaHua IDaHua)
        {
            bool ok = false;
            string filename = "Camer" + IDaHua.CamerIndx1.ToString();
            IniLibrary.IniTool inifiles = new IniLibrary.IniTool(ref filename, "DaHua", null);
            inifiles.WriteString(IDaHua.ToString(), "CamerIndx1", IDaHua.CamerIndx1.ToString());
            inifiles.WriteString(IDaHua.ToString(), "TriggerSourceenum", IDaHua.TriggerSourceenum);
            inifiles.WriteString(IDaHua.ToString(), "Exposuretime", IDaHua.Exposuretime.ToString());
            inifiles.WriteString(IDaHua.ToString(), "Gainraw", IDaHua.Gainraw.ToString());
            ok = true;
            return ok;
        }


        #endregion

    }
    #endregion
}
