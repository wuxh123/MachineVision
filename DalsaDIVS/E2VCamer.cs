#define BUGED
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using PvDotNet;




namespace E2VCamer
{
    #region  E2V相机驱动数据
    /// <summary>
    /// E2V相机驱动数据
    /// </summary>
    public class E2VCamer_ShuJu : IE2VCamer_ShuJu
   {
       #region     全局变量

       #region  相机驱动
       /// <summary>
       /// 相机驱动
       /// </summary>
       private PvDevice _mDevice = null;

       /// <summary>
       /// 相机流
       /// </summary>
       private PvStream _mStream = null;
     
       /// <summary>
       /// 
       /// </summary>
       private PvPipeline _mPipeline = null;
     
       #endregion

       #region  Display thread
       /// <summary>
       ///  Display thread
        /// </summary>
       private PvDisplayThread _mDisplayThread = null;
      
       #endregion

       #region   Acquisition state manager
       /// <summary>
       /// Acquisition state manager
        /// </summary>
       private PvAcquisitionStateManager _mAcquisitionManager = null;
       #endregion

      
       #endregion

       #region 属性
       /// <summary>
       /// 相机驱动
       /// </summary>
       public PvDevice MDevice
       {
           get { return _mDevice; }
           set { _mDevice = value; }
       }

       /// <summary>
       /// 相机流
       /// </summary>
       public PvStream MStream
       {
           get { return _mStream; }
           set { _mStream = value; }
       }

       /// <summary>
       /// 
       /// </summary>
       public PvPipeline MPipeline
       {
           get { return _mPipeline; }
           set { _mPipeline = value; }
       }

       /// <summary>
       ///  Display thread
       /// </summary>
       public PvDisplayThread MDisplayThread
       {
           get { return _mDisplayThread; }
           set { _mDisplayThread = value; }
       }

       /// <summary>
       /// Acquisition state manager
       /// </summary>
       public PvAcquisitionStateManager MAcquisitionManager
       {
           get { return _mAcquisitionManager; }
           set { _mAcquisitionManager = value; }
       }


       #endregion

       #region   构造函数
       /// <summary>
        /// 构造函数
        /// </summary>
       public E2VCamer_ShuJu()
       {
           _mDisplayThread = new PvDisplayThread();
       }

       #endregion

       #region  软件触发相机
       /// <summary>
        /// 软件触发相机
        /// </summary>
        /// <returns></returns>
       public bool TriggerCamer()
       {
           bool ok = false;
           this.MDevice.Parameters.ExecuteCommand("software");
           ok = true;
           return ok;

       }

       #endregion

       #region  开始取图
        /// <summary>
        /// 开始取图
        /// </summary>
        /// <returns></returns>
       public bool startAcquire()
       {
           bool ok = false;

           try
           {
               // Get payload size
               UInt32 lPayloadSize = lPayloadSize = MDevice.PayloadSize;

               // Propagate to pipeline to make sure buffers are big enough
               MPipeline.BufferSize = lPayloadSize;

               // Reset pipeline
               MPipeline.Reset();

               // Reset stream statistics
               PvGenCommand lResetStats = MStream.Parameters.GetCommand("Reset");
               lResetStats.Execute();

               // Reset display thread stats (mostly frames displayed per seconds)
               MDisplayThread.ResetStatistics();

               // Use acquisition manager to send the acquisition start command to the device
               MAcquisitionManager.Start();

               // Single source application, for simplicity we start all configured camera bridges
               //for (int i = 0; i < MCameraBridgeManager.BridgeCount; i++)
               //{
               //    PvCameraBridge lBridge = mCameraBridgeManager.GetBridge(i);
               //    if ((lBridge != null) &&
               //        (lBridge.IsConnected))
               //    {
               //        lBridge.StartAcquisition();
               //    }
               //}

               ok = true;
           }
           catch(Exception ex)
           {
               MessageBox.Show("相机打开取图出错");
           }
           return ok;
       }
       #endregion

       #region  停止取图
        /// <summary>
        /// 停止取图
        /// </summary>
        /// <returns></returns>
       public bool stopAcqurie()
       {
           bool ok = false;

           try
           {
               #region  无用代码
               //// Single source application, for simplicity we stop all configured camera bridges
               //for (int i = 0; i < mCameraBridgeManager.BridgeCount; i++)
               //{
               //    PvCameraBridge lBridge = mCameraBridgeManager.GetBridge(i);
               //    if ((lBridge != null) &&
               //        (lBridge.IsConnected))
               //    {
               //        lBridge.StopAcquisition();
               //    }
               //}
               #endregion

               // Use acquisition manager to send the acquisition stop command to the device
               MAcquisitionManager.Stop();

               ok = true;
           }
           catch(Exception ex)
           {
               MessageBox.Show("相机停止取图出错");
           }
           return ok;

       }
       #endregion

   }
    #endregion

    #region  E2V相机数据接口
    /// <summary>
    /// E2V相机数据接口
    /// </summary>
   public interface IE2VCamer_ShuJu   
   {
       #region 属性

       /// <summary>
       /// 相机驱动
       /// </summary>
       PvDevice MDevice
       {
           get;
           set;
       }

       /// <summary>
       /// 相机流
       /// </summary>
       PvStream MStream
       {
           get;
           set;
       }

       /// <summary>
       /// 
       /// </summary>
       PvPipeline MPipeline
       {
           get;
           set;
       }

       /// <summary>
       ///  Display thread
       /// </summary>
       PvDisplayThread MDisplayThread
       {
           get;
           set;
       }

       /// <summary>
       /// Acquisition state manager
       /// </summary>
       PvAcquisitionStateManager MAcquisitionManager
       {
           get;
           set;
       }



       #endregion

       #region  开始取图
       /// <summary>
       /// 开始取图
       /// </summary>
       /// <returns></returns>
        bool startAcquire();
       #endregion

       #region  停止取图
       /// <summary>
       /// 停止取图
       /// </summary>
       /// <returns></returns>
       bool stopAcqurie();
       #endregion

       #region  软件触发相机
       /// <summary>
       /// 软件触发相机
       /// </summary>
       /// <returns></returns>
       bool TriggerCamer();
       #endregion
   }
    #endregion
    
    #region   E2V相机驱动设置
    /// <summary>
    /// E2V相机驱动设置
    /// </summary>
    public class Set_E2VCamer
   {
       #region  全局变量

       #region  查找相机驱动的工具
       /// <summary>
       /// 查找相机驱动的工具
       /// </summary>
       PvDotNet.PvSystem _pv ;
       #endregion

       #region  相机个数
       /// <summary>
       /// 相机个数
       /// </summary>
       uint _countCamer = 0;
     
       #endregion

       #endregion

       #region  属性
       /// <summary>
       /// 相机个数
       /// </summary>
       public uint CountCamer
       {
           get { return _countCamer; }
           set { _countCamer = value; }
       }
       #endregion

       #region  构造函数
       /// <summary>
       /// 构造函数
       /// </summary>
       public Set_E2VCamer()
       {
           _pv = new PvSystem();
          _pv.Find();//查找相机
          this._countCamer = _pv.DeviceCount;//获取相机个数
       }
       #endregion
       
       #region  连接相机
    /// <summary>
    /// 连接相机
    /// </summary>
    /// <param name="Cam_">相机数据接口</param>
    /// <param name="i">连接第几个相机</param>
    /// <param name="disConnectCam_">相机丢失回调事件</param>
    /// <param name="CamerCallBack_">相机取图回调函数</param>
    /// <returns></returns>
       public bool SetConnectCamer(IE2VCamer_ShuJu Cam_,uint i,OnLinkDisconnectedHandler disConnectCam_,OnBufferDisplay CamerCallBack_)
       {
           bool ok = false;
           try
           {
               if (this._countCamer > 0 && this._countCamer > i && this.Set_Disconnect(Cam_))
               {
                   #region  无用代码
                   //try
                   //{
                   //    // Create and connect the device controller based on the selected device
                   //    mDevice = PvDevice.CreateAndConnect(aDI);

                   //    // Create and open stream
                   //    mStream = PvStream.CreateAndOpen(aDI);

                   //    // GigE Vision specific connection steps
                   //    if (aDI.Type == PvDeviceInfoType.GEV)
                   //    {
                   //        PvDeviceGEV lDeviceGEV = mDevice as PvDeviceGEV;
                   //        PvStreamGEV lStreamGEV = mStream as PvStreamGEV;

                   //        // Negotiate packet size
                   //        lDeviceGEV.NegotiatePacketSize();

                   //        // Set stream destination to our stream object
                   //        lDeviceGEV.SetStreamDestination(lStreamGEV.LocalIPAddress, lStreamGEV.LocalPort);
                   //    }

                   //    // Create pipeline - requires stream
                   //    mPipeline = new PvPipeline(mStream);
                   //}
                   //catch (PvException ex)
                   //{
                   //    // Failure at some point, display and abort
                   //    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                   //    Disconnect();

                   //    return;
                   //}

                   //// Register to all events of the parameters in the device's node map
                   //foreach (PvGenParameter lParameter in mDevice.Parameters)
                   //{
                   //    lParameter.OnParameterUpdate += new OnParameterUpdateHandler(OnParameterChanged);
                   //}

                   //// Connect link disconnection handler
                   //mDevice.OnLinkDisconnected += new OnLinkDisconnectedHandler(OnLinkDisconnected);

                   //// Update device attributes
                   //UpdateAttributes(aDI);

                   //// Fill acquisition mode combo box
                   //modeComboBox.Items.Clear();
                   //PvGenEnum lMode = mDevice.Parameters.GetEnum("AcquisitionMode");
                   //if (lMode != null)
                   //{
                   //    foreach (PvGenEnumEntry lEntry in lMode)
                   //    {
                   //        if (lEntry.IsAvailable)
                   //        {
                   //            int lIndex = modeComboBox.Items.Add(lEntry.ValueString);
                   //            if (lEntry.ValueInt == lMode.ValueInt)
                   //            {
                   //                modeComboBox.SelectedIndex = lIndex;
                   //            }
                   //        }
                   //    }
                   //}
                   #endregion

                   PvDeviceInfo aDI = this._pv.GetDeviceInfo(i);

                   Thread.Sleep(800);

                   PvDeviceInfoGEV lDeviceInfoGEV = aDI as PvDeviceInfoGEV;

                   if (lDeviceInfoGEV != null)//这一段代码不能小否则出错
                   {
                       string lMACAddress = lDeviceInfoGEV.MACAddress;
                       string lIPAddress = lDeviceInfoGEV.IPAddress;
                   }
                   
                   Cam_.MDevice = PvDevice.CreateAndConnect(aDI);
                   Cam_.MStream = PvStream.CreateAndOpen(aDI);

                   if (aDI.Type == PvDeviceInfoType.GEV)
                   {
                       PvDeviceGEV lDeviceGEV = Cam_.MDevice as PvDeviceGEV;
                       PvStreamGEV lStreamGEV = Cam_.MStream as PvStreamGEV;

                       // Negotiate packet size
                       lDeviceGEV.NegotiatePacketSize();

                       // Set stream destination to our stream object
                       lDeviceGEV.SetStreamDestination(lStreamGEV.LocalIPAddress, lStreamGEV.LocalPort);
                   }

                   // Create pipeline - requires stream
                   Cam_.MPipeline = new PvPipeline(Cam_.MStream);

                   if (disConnectCam_ != null)
                   {
                       // Connect link disconnection handler
                       Cam_.MDevice.OnLinkDisconnected += new OnLinkDisconnectedHandler(disConnectCam_);
                   }

                   if (CamerCallBack_ != null)
                   {
                       Cam_.MDisplayThread.OnBufferDisplay +=new OnBufferDisplay(CamerCallBack_) ;
                   }

                   Set_StartStreaming(Cam_);

                   ok = true;
               }
           }
           catch(Exception ex)
           {
               MessageBox.Show("相机绑定出错:"+ex.Message);
           }

           return ok;

       }
       #endregion

       #region  断开相机驱动的连接
       /// <summary>
       /// 断开相机驱动的连接
       /// </summary>
       /// <param name="IE2VCamer_"></param>
       /// <returns></returns>
       public bool Set_Disconnect(IE2VCamer_ShuJu IE2VCamer_)
       {
           bool ok = false;
           try
           { 
               //停止相机流
               if (Set_StopStreaming(IE2VCamer_))
               {
                   #region  无用代码
                   //if (mCameraBridgeManager != null)
                   //{
                   //    mCameraBridgeManager.Close();
                   //    mCameraBridgeManager.Dispose();
                   //    mCameraBridgeManager = null;
                   //}
                   //if (mPipeline != null)
                   //{
                   //    mPipeline.Dispose();
                   //    mPipeline = null;
                   //}
                   //if (mStream != null)
                   //{
                   //    mStream.Close();
                   //    mStream.Dispose();
                   //    mStream = null;
                   //}
                   //if (mDevice != null)
                   //{
                   //    if (mDevice.IsConnected)
                   //    {
                   //        // Disconnect events.
                   //        mDevice.OnLinkDisconnected -= new OnLinkDisconnectedHandler(OnLinkDisconnected);
                   //        foreach (PvGenParameter lP in mDevice.Parameters)
                   //        {
                   //            lP.OnParameterUpdate -= new OnParameterUpdateHandler(OnParameterChanged);
                   //        }
                   //        mDevice.Disconnect();
                   //        mDevice.Dispose();
                   //        mDevice = null;
                   //    }
                   //}
                   #endregion
                   if (IE2VCamer_.MPipeline != null)
                   {
                       IE2VCamer_.MPipeline.Dispose();
                       IE2VCamer_.MPipeline = null;
                   }
                   if (IE2VCamer_.MStream != null)
                   {
                       IE2VCamer_.MStream.Close();
                       IE2VCamer_.MStream.Dispose();
                       IE2VCamer_.MStream = null;
                   }
                   if (IE2VCamer_.MDevice != null)
                   {
                       if (IE2VCamer_.MDevice.IsConnected)
                       {
                          // IE2VCamer_.MDevice.OnLinkDisconnected = null;
                           IE2VCamer_.MDevice.Disconnect();
                           IE2VCamer_.MDevice.Dispose();
                           IE2VCamer_.MDevice = null;
                       }
                   }
                   ok = true;
               }
               else
               {
                   return ok;
               }


           }
           catch(Exception ex)
           {
               MessageBox.Show("断开相机驱动出错:" + ex.Message);
           }

           ok = true;
           return ok;
       }



       /// <summary>
       /// 断开相机驱动的连接
       /// </summary>
       /// <param name="IE2VCamer_"></param>
       /// <returns></returns>
       public bool Set_Disconnect(IE2VCamer_ShuJu IE2VCamer_, OnLinkDisconnectedHandler disConnectCam_)
       {
           bool ok = false;
           try
           {
               //停止相机流
               if (Set_StopStreaming(IE2VCamer_))
               {
                   #region  无用代码
                   //if (mCameraBridgeManager != null)
                   //{
                   //    mCameraBridgeManager.Close();
                   //    mCameraBridgeManager.Dispose();
                   //    mCameraBridgeManager = null;
                   //}
                   //if (mPipeline != null)
                   //{
                   //    mPipeline.Dispose();
                   //    mPipeline = null;
                   //}
                   //if (mStream != null)
                   //{
                   //    mStream.Close();
                   //    mStream.Dispose();
                   //    mStream = null;
                   //}
                   //if (mDevice != null)
                   //{
                   //    if (mDevice.IsConnected)
                   //    {
                   //        // Disconnect events.
                   //        mDevice.OnLinkDisconnected -= new OnLinkDisconnectedHandler(OnLinkDisconnected);
                   //        foreach (PvGenParameter lP in mDevice.Parameters)
                   //        {
                   //            lP.OnParameterUpdate -= new OnParameterUpdateHandler(OnParameterChanged);
                   //        }
                   //        mDevice.Disconnect();
                   //        mDevice.Dispose();
                   //        mDevice = null;
                   //    }
                   //}
                   #endregion
                 
                   
                   if (IE2VCamer_.MPipeline != null)
                   {
                       IE2VCamer_.MPipeline.Dispose();
                       IE2VCamer_.MPipeline = null;
                   }
                   if (IE2VCamer_.MStream != null)
                   {
                       IE2VCamer_.MStream.Close();
                       IE2VCamer_.MStream.Dispose();
                       IE2VCamer_.MStream = null;
                   }

                   if (IE2VCamer_.MDevice != null)
                   {
                       if (IE2VCamer_.MDevice.IsConnected)
                       {
                           IE2VCamer_.MDevice.OnLinkDisconnected-=new OnLinkDisconnectedHandler(disConnectCam_);
                           IE2VCamer_.MDevice.Disconnect();
                           IE2VCamer_.MDevice.Dispose();
                           IE2VCamer_.MDevice = null;
                       }
                   }
                   ok = true;
               }
               else
               {
                   return ok;
               }


           }
           catch (Exception ex)
           {
               MessageBox.Show("断开相机驱动出错:" + ex.Message);
           }

           ok = true;
           return ok;
       }


       #endregion
       
       #region  停止相机流
       /// <summary>
       /// 停止相机流
       /// </summary>
       /// <param name="IE2VCamer_"></param>
       /// <returns></returns>
       public bool Set_StopStreaming(IE2VCamer_ShuJu IE2VCamer_)
       {
           bool ok = false;
           #region  无用代码
           //if (!mDisplayThread.IsRunning)
           //{
           //    return;
           //}
           //// Status control is configured in StartStreaming, must release 
           //// resources in StopStreaming
           //statusControl.Stream = null;
           //statusControl.DisplayThread = null;
           //// Stop display thread
           //mDisplayThread.Stop(false);
           //// Release acquisition manager
           //mAcquisitionManager.Dispose();
           //mAcquisitionManager = null;
           //// Stop pipeline
           //if (mPipeline.IsStarted)
           //{
           //    mPipeline.Stop();
           //}
           //// Wait on display thread
           //mDisplayThread.WaitComplete();
#endregion
           try
           {
               if (!IE2VCamer_.MDisplayThread.IsRunning)
               {
                   return true;
               }

               IE2VCamer_.MDisplayThread.Stop(false);

               IE2VCamer_.MAcquisitionManager.Dispose();
               IE2VCamer_.MAcquisitionManager = null;

               // Stop display thread
            
               if (IE2VCamer_.MPipeline.IsStarted)
               {
                   IE2VCamer_.MPipeline.Stop();
               }

               IE2VCamer_.MDisplayThread.WaitComplete();
               ok = true;
           }
           catch(Exception ex)
           {
               MessageBox.Show("相机停止流出错:" + ex.Message);
           }
           return ok;

       }
       #endregion

       #region  开始相机流
       /// <summary>
       /// 开始相机流
       /// </summary>
       /// <param name="IE2VCamer_"></param>
       /// <returns></returns>
       public bool Set_StartStreaming(IE2VCamer_ShuJu IE2VCamer_)
       {
           bool ok = false;

           #region 无用代码
           //// Configure status control
           //statusControl.Stream = mStream;
           //statusControl.DisplayThread = mDisplayThread;
           //// Start threads
           //mDisplayThread.Start(mPipeline, mDevice.Parameters);
           //mDisplayThread.Priority = PvThreadPriority.AboveNormal;
           //// Configure acquisition state manager
           //mAcquisitionManager = new PvAcquisitionStateManager(mDevice, mStream);
           //mAcquisitionManager.OnAcquisitionStateChanged += new OnAcquisitionStateChanged(OnAcquisitionStateChanged);
           //// Start pipeline
           //mPipeline.Start();
           #endregion

           IE2VCamer_.MDisplayThread.Start(IE2VCamer_.MPipeline, IE2VCamer_.MDevice.Parameters);
           IE2VCamer_.MDisplayThread.Priority = PvThreadPriority.AboveNormal;
           IE2VCamer_.MAcquisitionManager = new PvAcquisitionStateManager(IE2VCamer_.MDevice);
           IE2VCamer_.MPipeline.Start();
           ok = true;
           return ok;
       }

       #endregion

       #region  设置相机曝光
       /// <summary>
       /// 设置相机曝光
       /// </summary>
       /// <returns></returns>
       public bool Set_Exposure(IE2VCamer_ShuJu IE2VCamer_, string baoGuang_)
       {
           bool ok = false;
           try
           {
               double num_=Convert.ToDouble(baoGuang_);
               IE2VCamer_.MDevice.Parameters.SetFloatValue("ExposureTime_us", num_);
               ok = true;
           }
           catch(Exception ex)
           {
               MessageBox.Show("设置相机曝光出错");
           }
           return ok;
       }
       #endregion

       #region  无用代码
       //#region   设置相机增益
       ///// <summary>
       ///// 设置相机增益
       ///// </summary>
       ///// <returns></returns>
       //public bool Set_Gain(IE2VCamer_ShuJu IE2VCamer_, string zengYi_)
       //{
       //    bool ok = false;

       //    try
       //    {
       //        double num_ = Convert.ToDouble(zengYi_);
       //        IE2VCamer_.MDevice.Parameters.SetFloatValue("Gain", num_);
       //        ok = true;
       //    }
       //    catch(Exception ex)
       //    {
       //        MessageBox.Show("设置相机增益出错");
       //    }
       //        return ok;
       //}
       //#endregion
       #endregion

       #region  设置触发模式
       /// <summary>
       /// 设置触发模式
       /// </summary>
       /// <param name="IE2VCamer_"></param>
       /// <returns></returns>
       public bool Set_Trigger(IE2VCamer_ShuJu IE2VCamer_,string strTrigger)
       {
           bool ok = false;
           try
           {
               PvGenEnum lMode =IE2VCamer_.MDevice.Parameters.GetEnum("AcquisitionMode");
               lMode.ValueString = strTrigger;
           }
           catch(Exception ex)
           {
               MessageBox.Show("设置触发模式出错:" + ex.Message);
           }

           ok = true;
           return ok;
       }

       #endregion
      
        #region  无用代码
       //#region  设置相机的分配屏
       // /// <summary>
       // /// 设置相机的分配屏
       // /// </summary>
       // /// <returns></returns>
       //public bool Set_sheZhiXiangJiDeFenPeiPing(IE2VCamer_ShuJu IE2VCamer_,string rescalerMultiplier,string rescalerDivider,bool rescalerEnable)
       //{
       //    bool ok = false;
       //    try
       //    {
       //        if (rescalerMultiplier != null)
       //        {
       //            PvGenEnum lMode = IE2VCamer_.MStream.Parameters.GetEnum("RescalerMultiplier");
       //            //lMode.ValueInt = Convert.ToInt32(rescalerMulitplier);
                  
       //            IE2VCamer_.MDevice.Parameters.SetFloatValue("RescalerMultiplier", Convert.ToDouble(rescalerMultiplier));
                  
       //        }
       //        if (rescalerDivider != null)
       //        {

       //            IE2VCamer_.MStream.Parameters.SetFloatValue("RescalerDivider", Convert.ToDouble(rescalerDivider));
                  
            
               
       //        }

       //        if (rescalerEnable != null)
       //        {
       //            PvGenEnum lMode = IE2VCamer_.MDevice.Parameters.GetEnum("RescalerEnable");

       //            if (rescalerEnable)
       //            {
       //                lMode.ValueString = "true";
       //            }
       //            else
       //            {
       //                lMode.ValueString = "false";
       //            }
       //        }
       //        ok = true;
       //    }
       //    catch(Exception ex)
       //    {
       //        MessageBox.Show("设置分配屏失败:"+ex.Message);
       //    }
       //    return ok;
       //}

       //#endregion
       #endregion

   }
    #endregion
}
