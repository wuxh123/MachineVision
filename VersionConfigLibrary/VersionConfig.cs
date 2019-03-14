using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace VersionConfigLibrary
{
    #region  配置文件数据
    /// <summary>
    ///软件版本配置文件类 
    /// </summary>
    [Serializable]
    public class VersionConfig : IVersionConfig
    {
        #region   软件的使用版本
        /// <summary>
        /// 软件的使用版本
        /// </summary>
        private string _use_VersionConfig = "";
        #endregion

        #region  项目 客户
        /// <summary>
        /// 客户
        /// </summary>
        private string _client_VersionConfig = "";

        /// <summary>
        /// 项目
        /// </summary>
        private string _project_VersionConfig = "";
        #endregion

        #region   试用期
        /// <summary>
        /// 是否启动试用期
        /// </summary>
        private bool _exitTryOut_VersionConfig = false;

        /// <summary>
        /// 开始试用的日期
        /// </summary>
        private string _tryOutDateStart_VersionConfig = "";

        /// <summary>
        /// 试用期当前时间
        /// </summary>
        private string _tryOutDateCurrendt_VersionConfig = "";

        /// <summary>
        /// 截止日期
        /// </summary>
        private string _tryOutDateStop_VersionConfig = "";


        #endregion

        #region   强制停止
        /// <summary>
        /// 是否存在强制停止
        /// </summary>
        private bool _exitForceStop = false;

        /// <summary>
        /// 强制停止的日期
        /// </summary>
        private string _forceStopDate_VersionConfig = "";
        #endregion

        #region   可以使用工具的许可标志

        #region   是否存在工具许可标志
        /// <summary>
        /// 是否存在工具许可标志
        /// </summary>
        private bool _exit_Tool = true;

        #endregion

        #region  系统检测标志
        /// <summary>
        /// 系统检测标志
        /// </summary>
        private bool detection_bool = true;

        #endregion

        #region   取图标志
        /// <summary>
        /// 取图标志
        /// </summary>
        private bool acquire_bool = true;

        #endregion

        #region  模板匹配标志
        /// <summary>
        /// 模板匹配标志
        /// </summary>
        private bool Template_bool = true;

        #endregion

        #region 放射 定位标志
        /// <summary>
        /// 放射 定位标志
        /// </summary>
        private bool Rect_bool = true;

        #endregion

        #region  标定标志
        /// <summary>
        /// 标定标志
        /// </summary>
        private bool Calibration_bool = true;

        #endregion

        #region  二维码标志
        /// <summary>
        /// 二维码标志
        /// </summary>
        private bool DataCode_bool = true;

        #endregion

        #region  拟合圆标志
        /// <summary>
        /// 拟合圆标志
        /// </summary>
        private bool Circle_bool = true;

        #endregion

        #region  拟合边标志
        /// <summary>
        /// 拟合边标志
        /// </summary>
        private bool Line_bool = true;

        #endregion

        #region  ocr标志
        /// <summary>
        /// ocr标志
        /// </summary>
        private bool OCR_bool = true;

        #endregion

        #region  ocv标志
        /// <summary>
        /// ocv标志
        /// </summary>
        private bool OCV_bool = true;

        #endregion

        #endregion

        #region  属性

        #region  软件的使用版本
        /// <summary>
        /// 软件的使用版本
        /// </summary>
        public string Use_VersionConfig
        {
            get { return _use_VersionConfig; }
            set { _use_VersionConfig = value; }
        }
        #endregion

        #region  客户  项目
        /// <summary>
        /// 客户
        /// </summary>
        public string Client_VersionConfig
        {
            get { return _client_VersionConfig; }
            set { _client_VersionConfig = value; }
        }

        /// <summary>
        /// 项目
        /// </summary>
        public string Project_VersionConfig
        {
            get { return _project_VersionConfig; }
            set { _project_VersionConfig = value; }
        }
        #endregion

        #region  试用期
        /// <summary>
        /// 是否启动试用期
        /// </summary>
        public bool ExitTryOut_VersionConfig
        {
            get { return _exitTryOut_VersionConfig; }
            set { _exitTryOut_VersionConfig = value; }
        }

        /// <summary>
        /// 开始试用的日期
        /// </summary>
        public string TryOutDateStart_VersionConfig
        {
            get { return _tryOutDateStart_VersionConfig; }
            set { _tryOutDateStart_VersionConfig = value; }
        }

        /// <summary>
        /// 试用期当前时间
        /// </summary>
        public string TryOutDateCurrendt_VersionConfig
        {
            get { return _tryOutDateCurrendt_VersionConfig; }
            set { _tryOutDateCurrendt_VersionConfig = value; }
        }

        /// <summary>
        /// 试用的时间长短
        /// </summary>
        public string TryOutDateStop_VersionConfig
        {
            get { return _tryOutDateStop_VersionConfig; }
            set { _tryOutDateStop_VersionConfig = value; }
        }
        #endregion

        #region  强制停止
        /// <summary>
        /// 是否存在强制停止
        /// </summary>
        public bool ExitForceStop
        {
            get { return _exitForceStop; }
            set { _exitForceStop = value; }
        }

        /// <summary>
        /// 强制停止的日期
        /// </summary>
        public string ForceStopDate_VersionConfig
        {
            get { return _forceStopDate_VersionConfig; }
            set { _forceStopDate_VersionConfig = value; }
        }
        #endregion

        #region  可以使用工具的许可标志

        #region  是否存在工具许可标志
        /// <summary>
        /// 是否存在工具许可标志
        /// </summary>
        public bool Exit_Tool
        {
            get { return _exit_Tool; }
            set { _exit_Tool = value; }
        }
        #endregion

        #region   系统检测标志
        /// <summary>
        /// 系统检测标志
        /// </summary>
        public bool Detection_bool
        {
            get { return detection_bool; }
            set { detection_bool = value; }
        }
        #endregion

        #region  取图标志
        /// <summary>
        /// 取图标志
        /// </summary>
        public bool Acquire_bool
        {
            get { return acquire_bool; }
            set { acquire_bool = value; }
        }
        #endregion

        #region   模板匹配标志
        /// <summary>
        /// 模板匹配标志
        /// </summary>
        public bool Template_bool1
        {
            get { return Template_bool; }
            set { Template_bool = value; }
        }
        #endregion

        #region   放射定位标志
        /// <summary>
        /// 放射 定位标志
        /// </summary>
        public bool Rect_bool1
        {
            get { return Rect_bool; }
            set { Rect_bool = value; }
        }
        #endregion

        #region   标定标志
        /// <summary>
        /// 标定标志
        /// </summary>
        public bool Calibration_bool1
        {
            get { return Calibration_bool; }
            set { Calibration_bool = value; }
        }
        #endregion

        #region  二维码标志
        /// <summary>
        /// 二维码标志
        /// </summary>
        public bool DataCode_bool1
        {
            get { return DataCode_bool; }
            set { DataCode_bool = value; }
        }
        #endregion

        #region   拟合圆标志
        /// <summary>
        /// 拟合圆标志
        /// </summary>
        public bool Circle_bool1
        {
            get { return Circle_bool; }
            set { Circle_bool = value; }
        }
        #endregion

        #region   拟合边标志
        /// <summary>
        /// 拟合边标志
        /// </summary>
        public bool Line_bool1
        {
            get { return Line_bool; }
            set { Line_bool = value; }
        }
        #endregion

        #region  ocr标志
        /// <summary>
        /// ocr标志
        /// </summary>
        public bool OCR_bool1
        {
            get { return OCR_bool; }
            set { OCR_bool = value; }
        }
        #endregion

        #region   ocv标志
        /// <summary>
        /// ocv标志
        /// </summary>
        public bool OCV_bool1
        {
            get { return OCV_bool; }
            set { OCV_bool = value; }
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion

    #region  枚举工具
    /// <summary>
    /// 枚举工具
    /// </summary>
    public enum tool_enum
    {
        #region     是否存在工具许可标志
        /// <summary>
        /// 是否存在工具许可标志
        /// </summary>
        Exit_Tool,
        #endregion

        #region  系统检测标志
        /// <summary>
        /// 系统检测标志
        /// </summary>
        Detection_bool,
        #endregion

        #region   取图标志
        /// <summary>
        /// 取图标志
        /// </summary>
        Acquire_bool,
        #endregion

        #region   模板匹配标志
        /// <summary>
        /// 模板匹配标志
        /// </summary>
        Template_bool,
        #endregion

        #region   放射 定位标志
        /// <summary>
        /// 放射 定位标志
        /// </summary>
        Rect_bool,
        #endregion

        #region    标定标志
        /// <summary>
        /// 标定标志
        /// </summary>
        Calibration_bool,
        #endregion

        #region   二维码标志
        /// <summary>
        /// 二维码标志
        /// </summary>
        DataCode_bool,
        #endregion

        #region   拟合圆标志
        /// <summary>
        /// 拟合圆标志
        /// </summary>
        Circle_bool,
        #endregion

        #region    拟合边标志
        /// <summary>
        /// 拟合边标志
        /// </summary>
        Line_bool,
        #endregion

        #region   ocr标志
        /// <summary>
        ///  ocr标志
        /// </summary>
        OCR_bool,
        #endregion

        #region  ocv标志
        /// <summary>
        /// ocv标志
        /// </summary>
        OCV_bool
        #endregion

    }

    #endregion

    #region  枚举试用期
    /// <summary>
    /// 枚举试用期
    /// </summary>
    public enum tryOut_enum
    {
        /// <summary>
        /// 没有试用期
        /// </summary>
        noTryOut,
        /// <summary>
        /// 试用期
        /// </summary>
        tryOutDuring,
        /// <summary>
        /// 过期
        /// </summary>
        outOfDate,
    }
    #endregion

    #region   强制停止枚举
    /// <summary>
    /// 强制停止枚举
    /// </summary>
    public enum force_enum
    {
        /// <summary>
        /// 强制停止启动
        /// </summary>
        startForce,
        /// <summary>
        /// 强制停止没有启动
        /// </summary>
        stopForce,
        /// <summary>
        /// 强制停止到期
        /// </summary>
        expireForce
    }
    #endregion

    #region  数据接口
    /// <summary>
    /// 数据接口
    /// </summary>
    public interface IVersionConfig
    {
        #region  属性

        #region  软件的使用版本
        /// <summary>
        /// 软件的使用版本
        /// </summary>
        string Use_VersionConfig
        {
            get;
            set;
        }
        #endregion

        #region  客户  项目
        /// <summary>
        /// 客户
        /// </summary>
        string Client_VersionConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 项目
        /// </summary>
        string Project_VersionConfig
        {
            get;
            set;
        }
        #endregion

        #region  试用期
        /// <summary>
        /// 是否启动试用期
        /// </summary>
        bool ExitTryOut_VersionConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 开始试用的日期
        /// </summary>
        string TryOutDateStart_VersionConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 试用期当前时间
        /// </summary>
        string TryOutDateCurrendt_VersionConfig
        {
            get;
            set;
        }

        /// <summary>
        /// 试用的时间长短
        /// </summary>
        string TryOutDateStop_VersionConfig
        {
            get;
            set;
        }
        #endregion

        #region  强制停止
        /// <summary>
        /// 是否存在强制停止
        /// </summary>
        bool ExitForceStop
        {
            get;
            set;
        }

        /// <summary>
        /// 强制停止的日期
        /// </summary>
        string ForceStopDate_VersionConfig
        {
            get;
            set;
        }
        #endregion

        #region  可以使用工具的许可标志

        #region  是否存在工具许可标志
        /// <summary>
        /// 是否存在工具许可标志
        /// </summary>
        bool Exit_Tool
        {
            get;
            set;
        }
        #endregion

        #region   系统检测标志
        /// <summary>
        /// 系统检测标志
        /// </summary>
        bool Detection_bool
        {
            get;
            set;
        }
        #endregion

        #region  取图标志
        /// <summary>
        /// 取图标志
        /// </summary>
        bool Acquire_bool
        {
            get;
            set;
        }
        #endregion

        #region   模板匹配标志
        /// <summary>
        /// 模板匹配标志
        /// </summary>
        bool Template_bool1
        {
            get;
            set;
        }
        #endregion

        #region   放射 定位标志
        /// <summary>
        /// 放射 定位标志
        /// </summary>
        bool Rect_bool1
        {
            get;
            set;
        }
        #endregion

        #region   标定标志
        /// <summary>
        /// 标定标志
        /// </summary>
        bool Calibration_bool1
        {
            get;
            set;
        }
        #endregion

        #region  二维码标志
        /// <summary>
        /// 二维码标志
        /// </summary>
        bool DataCode_bool1
        {
            get;
            set;
        }
        #endregion

        #region   拟合圆标志
        /// <summary>
        /// 拟合圆标志
        /// </summary>
        bool Circle_bool1
        {
            get;
            set;
        }
        #endregion

        #region   拟合边标志
        /// <summary>
        /// 拟合边标志
        /// </summary>
        bool Line_bool1
        {
            get;
            set;
        }
        #endregion

        #region  ocr标志
        /// <summary>
        /// ocr标志
        /// </summary>
        bool OCR_bool1
        {
            get;
            set;
        }
        #endregion

        #region   ocv标志
        /// <summary>
        /// ocv标志
        /// </summary>
        bool OCV_bool1
        {
            get;
            set;
        }
        #endregion
        #endregion
        #endregion
    }
    #endregion

    #region  数据设置器
    /// <summary>
    /// 数据设置器
    /// </summary>
    public class Set_Get_VersionConfig
    {
        #region  软件使用版本
        #region   设置软件的使用版本
        /// <summary>
        /// 设置软件的使用版本
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="_use_VersionConfig"></param>
        public void Set_use_VersionConfig(IVersionConfig IVer_, string _use_VersionConfig)
        {
            if (_use_VersionConfig != null)
            {
                IVer_.Use_VersionConfig = _use_VersionConfig;
            }
        }
        #endregion

        #region  获取软件的使用版本
        /// <summary>
        /// 获取软件的使用版本
        /// </summary>
        /// <param name="IVer_"></param>
        /// <returns></returns>
        public string Get_use_VersionConfig(IVersionConfig IVer_)
        {
            return IVer_.Use_VersionConfig;
        }
        #endregion
        #endregion

        #region  项目  客户
        /// <summary>
        /// 项目  客户
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="_client_VersionConfig"></param>
        /// <param name="_project_VersionConfig"></param>
        public void Set_client_project(IVersionConfig IVer_, string _client_VersionConfig, string _project_VersionConfig)
        {
            if (_client_VersionConfig != null)
            {
                IVer_.Client_VersionConfig = _client_VersionConfig;
            }

            if (_project_VersionConfig != null)
            {
                IVer_.Project_VersionConfig = _project_VersionConfig;
            }

        }

        /// <summary>
        /// 项目  客户
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="_client_VersionConfig"></param>
        /// <param name="_project_VersionConfig"></param>
        public void Get_client_project(IVersionConfig IVer_, ref string _client_VersionConfig, ref string _project_VersionConfig)
        {
            _client_VersionConfig = IVer_.Client_VersionConfig;
            _project_VersionConfig = IVer_.Project_VersionConfig;
        }

        #endregion

        #region  试用期
        /// <summary>
        /// 试用期
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="_exitTryOut_VersionConfig"></param>
        /// <param name="tryOutDateStart_VersionConfig_"></param>
        /// <param name="tryOutDateStop_VersionConfig_"></param>
        public void Set_tryOut(IVersionConfig IVer_, bool _exitTryOut_VersionConfig, string tryOutDateStart_VersionConfig_, string tryOutDateStop_VersionConfig_)
        {
            IVer_.ExitTryOut_VersionConfig = _exitTryOut_VersionConfig;

            if (tryOutDateStart_VersionConfig_ != null)
            {
                IVer_.TryOutDateStart_VersionConfig = tryOutDateStart_VersionConfig_;
                IVer_.TryOutDateCurrendt_VersionConfig = tryOutDateStart_VersionConfig_;
            }

            if (tryOutDateStop_VersionConfig_ != null)
            {
                IVer_.TryOutDateStop_VersionConfig = tryOutDateStop_VersionConfig_;
            }
        }

        /// <summary>
        /// 试用期
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="_exitTryOut_VersionConfig"></param>
        /// <param name="tryOutDateStart_VersionConfig_"></param>
        /// <param name="tryOutDateStop_VersionConfig_"></param>
        public void Get_tryOut(IVersionConfig IVer_, ref bool _exitTryOut_VersionConfig, ref string tryOutDateStart_VersionConfig_, ref string tryOutDateCurrendt_VersionConfig_, ref string tryOutDateStop_VersionConfig_)
        {
            _exitTryOut_VersionConfig = IVer_.ExitTryOut_VersionConfig;
            tryOutDateStart_VersionConfig_ = IVer_.TryOutDateStart_VersionConfig;
            tryOutDateCurrendt_VersionConfig_ = IVer_.TryOutDateCurrendt_VersionConfig;
            tryOutDateStop_VersionConfig_ = IVer_.TryOutDateStop_VersionConfig;
        }
        #endregion

        #region   强制停止
        /// <summary>
        /// 强制停止
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="_exitForceStop"></param>
        /// <param name="_forceStopDate_VersionConfig"></param>
        public void Set_Force(IVersionConfig IVer_, bool _exitForceStop, string _forceStopDate_VersionConfig)
        {
            IVer_.ExitForceStop = _exitForceStop;
            IVer_.ForceStopDate_VersionConfig = _forceStopDate_VersionConfig;
        }


        /// <summary>
        /// 强制停止
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="_exitForceStop"></param>
        /// <param name="_forceStopDate_VersionConfig"></param>
        public void Get_Force(IVersionConfig IVer_, ref bool _exitForceStop, ref string _forceStopDate_VersionConfig)
        {
            _exitForceStop = IVer_.ExitForceStop;
            _forceStopDate_VersionConfig = IVer_.ForceStopDate_VersionConfig;
        }
        #endregion

        #region  使用工具标志
        /// <summary>
        /// 使用工具标志
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="tool_name_"></param>
        /// <param name="use_bool"></param>
        public void Set_tool_bool(IVersionConfig IVer_, tool_enum tool_name_, ref bool use_bool)
        {
            switch (tool_name_)
            {
                #region  存在工具使用标志
                case tool_enum.Exit_Tool:
                    IVer_.Exit_Tool = use_bool;
                    break;
                #endregion

                #region  系统检测标志
                case tool_enum.Detection_bool:
                    IVer_.Detection_bool = use_bool;
                    break;
                #endregion

                #region  取图标志
                case tool_enum.Acquire_bool:
                    IVer_.Acquire_bool = use_bool;
                    break;
                #endregion

                #region  模板匹配标志
                case tool_enum.Template_bool:
                    IVer_.Template_bool1 = use_bool;
                    break;
                #endregion

                #region   拟合圆标志
                case tool_enum.Circle_bool:
                    IVer_.Circle_bool1 = use_bool;
                    break;
                #endregion

                #region   拟合线标志
                case tool_enum.Line_bool:
                    IVer_.Line_bool1 = use_bool;
                    break;
                #endregion

                #region  ocr标志
                case tool_enum.OCR_bool:
                    IVer_.OCR_bool1 = use_bool;
                    break;
                #endregion

                #region  ocv标志

                case tool_enum.OCV_bool:
                    IVer_.OCV_bool1 = use_bool;
                    break;
                #endregion

                #region  放射 定位标志
                case tool_enum.Rect_bool:
                    IVer_.Rect_bool1 = use_bool;
                    break;
                #endregion

                #region   二维码标志
                case tool_enum.DataCode_bool:
                    IVer_.DataCode_bool1 = use_bool;
                    break;
                #endregion

                #region  标定标志
                case tool_enum.Calibration_bool:
                    IVer_.Calibration_bool1 = use_bool;
                    break;
                #endregion

                #region  默认处理
                default:
                    break;
                #endregion
            }
        }

        /// <summary>
        /// 使用工具标志
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="tool_name_"></param>
        /// <returns></returns>
        public bool Get_tool_bool(IVersionConfig IVer_, tool_enum tool_name_)
        {
            switch (tool_name_)
            {
                #region  是否存在工具许可标志
                case tool_enum.Exit_Tool:
                    return IVer_.Exit_Tool;
                #endregion

                #region   系统检测标志
                case tool_enum.Detection_bool:
                    return IVer_.Detection_bool;
                #endregion

                #region   取图标志
                case tool_enum.Acquire_bool:
                    return IVer_.Acquire_bool;
                #endregion

                #region  标定标志
                case tool_enum.Calibration_bool:
                    return IVer_.Calibration_bool1;
                #endregion

                #region   拟合圆标志
                case tool_enum.Circle_bool:
                    return IVer_.Circle_bool1;
                #endregion

                #region  拟合线标志
                case tool_enum.Line_bool:
                    return IVer_.Line_bool1;
                #endregion

                #region   OCR工具标志
                case tool_enum.OCR_bool:
                    return IVer_.OCR_bool1;
                #endregion

                #region   OCV工具标志
                case tool_enum.OCV_bool:
                    return IVer_.OCV_bool1;
                #endregion

                #region   放射定位标志
                case tool_enum.Rect_bool:
                    return IVer_.Rect_bool1;
                #endregion

                #region  模板匹配标志
                case tool_enum.Template_bool:
                    return IVer_.Template_bool1;
                #endregion

                #region  二维码读取标志
                case tool_enum.DataCode_bool:
                    return IVer_.DataCode_bool1;
                #endregion

                #region  默认返回
                default:
                    return true;
                #endregion
            }
        }
        #endregion

        #region  序列化

        /// <summary>
        /// 序列话一个类
        /// </summary>
        /// <typeparam name="T">要序列话的类</typeparam>
        /// <param name="lei">传入的类</param>
        /// <param name="lvjing">保存那个文件夹的路径</param>
        /// <param name="name">文件名,带后缀，不带\\</param>
        /// <returns>返回真，ok</returns>
        public bool XuLeiHua<T>(T lei, string lvjing, string name)
        {
            bool ok = false;
            T temp = lei;
            FileStream fs = new FileStream(lvjing + @"\" + name, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, temp);
            fs.Close(); ok = true;
            return ok;
        }

        /// <summary>
        /// 序列话一个类
        /// </summary>
        /// <typeparam name="T">要序列话的类</typeparam>
        /// <param name="lei">传入的类</param>
        /// <param name="lvjing">文件的路径,包含文件名</param>
        /// <returns></returns>
        public bool XuLeiHua<T>(T lei, string lvjing)
        {
            bool ok = false;
            T temp = lei;
            FileStream fs = new FileStream(lvjing, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, temp);
            fs.Close(); ok = true;
            return ok;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">传入的类型</typeparam>
        /// <param name="lei">反序列后输出的类</param>
        /// <param name="lvjing">要反序列的文件路径</param>
        /// <returns>返回真，反序列成功</returns>
        public bool fanXuLeiHua<T>(out T lei, string lvjing)
        {
            bool ok = false;
            T temp;
            FileStream fs = new FileStream(lvjing, FileMode.Open, FileAccess.Read, FileShare.Read);

            BinaryFormatter bf = new BinaryFormatter();
            temp = (T)bf.Deserialize(fs);
            fs.Flush();
            fs.Close();
            lei = temp;
            ok = true;
            return ok;
        }

        #endregion

        #region   显示接口参数
        /// <summary>
        /// 显示接口参数
        /// </summary>
        /// <param name="IVer_"></param>
        /// <param name="control"></param>
        public void Set_ShowParameter(IVersionConfig IVer_, Control.ControlCollection control)
        {
            foreach (Control con in control)
            {
                string name = con.Name;
                if ((con is ComboBox) || (con is TextBox) || (con is RichTextBox) || (con is Label) || (con is CheckBox))
                {
                    switch (name)
                    {
                        #region  软件的版本
                        case "Use_VersionConfig":
                            con.Text = IVer_.Use_VersionConfig;
                            break;
                        #endregion

                        #region   客户  项目
                        case "Client_VersionConfig":
                            con.Text = IVer_.Client_VersionConfig;
                            break;

                        case "Project_VersionConfig":
                            con.Text = IVer_.Project_VersionConfig;
                            break;
                        #endregion

                        #region   试用期
                        case "ExitTryOut_VersionConfig":
                            ((CheckBox)con).Checked = IVer_.ExitTryOut_VersionConfig;
                            break;

                        case "TryOutDateStart_VersionConfig":
                            con.Text = IVer_.TryOutDateStart_VersionConfig;
                            break;

                        case "TryOutDateCurrendt_VersionConfig":
                            con.Text = IVer_.TryOutDateStart_VersionConfig;
                            break;

                        case "TryOutDateStop_VersionConfig":
                            con.Text = IVer_.TryOutDateStop_VersionConfig;
                            break;
                        #endregion

                        #region   强制停止
                        case "ExitForceStop":
                            ((CheckBox)con).Checked = IVer_.ExitForceStop;
                            break;

                        case "ForceStopDate_VersionConfig":
                            con.Text = IVer_.ForceStopDate_VersionConfig;
                            break;
                        #endregion

                        #region  可以使用工具的许可标志

                        #region   判断是否启动工具许可标志
                        case "Exit_Tool":
                            ((CheckBox)con).Checked = IVer_.Exit_Tool;
                            break;
                        #endregion

                        #region  系统检测
                        case "Detection_bool":
                            ((CheckBox)con).Checked = IVer_.Detection_bool;
                            break;
                        #endregion

                        #region  取图标志
                        case "Acquire_bool":
                            ((CheckBox)con).Checked = IVer_.Acquire_bool;
                            break;
                        #endregion

                        #region  模板匹配
                        case "Template_bool1":
                            ((CheckBox)con).Checked = IVer_.Template_bool1;
                            break;
                        #endregion

                        #region   放射定位
                        case "Rect_bool1":
                            ((CheckBox)con).Checked = IVer_.Rect_bool1;
                            break;
                        #endregion

                        #region   标定标志
                        case "Calibration_bool1":
                            ((CheckBox)con).Checked = IVer_.Calibration_bool1;
                            break;
                        #endregion

                        #region  二维码标志
                        case "DataCode_bool1":
                            ((CheckBox)con).Checked = IVer_.DataCode_bool1;
                            break;
                        #endregion

                        #region  拟合圆标志
                        case "Circle_bool1":
                            ((CheckBox)con).Checked = IVer_.Circle_bool1;
                            break;
                        #endregion

                        #region 拟合线标志
                        case "Line_bool1":
                            ((CheckBox)con).Checked = IVer_.Line_bool1;
                            break;
                        #endregion

                        #region  ocr标志
                        case "OCR_bool1":
                            ((CheckBox)con).Checked = IVer_.OCR_bool1;
                            break;
                        #endregion

                        #region   ocv标志
                        case "OCV_bool1":
                            ((CheckBox)con).Checked = IVer_.OCV_bool1;
                            break;
                        #endregion

                        #endregion

                        #region  默认处理
                        default:

                            break;
                        #endregion
                    }
                }

                if (con.Controls.Count > 0)
                {
                    Set_ShowParameter(IVer_, con.Controls);
                }


            }
        }
        #endregion
    }
    #endregion

    #region   数据检测器
    /// <summary>
    /// 数据检测器
    /// </summary>
    internal class Check_VersionConfig
    {
        #region  检测是否存在配置文件
        /// <summary>
        ///检测匹配文件是否存在 
        /// </summary>
        /// <returns></returns>
        internal bool CheckConfigFolderExit()
        {
            bool ok = false;
            ok = File.Exists(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "VersionConfig.config");
            return ok;
        }
        #endregion

        #region   检测试用期是否到期
        /// <summary>
        /// 检测试用期是否到期
        /// </summary>
        /// <param name="IVer_"></param>
        /// <returns></returns>
        internal tryOut_enum CheckTryOut(IVersionConfig IVer_)
        {
            tryOut_enum tryOut_ = tryOut_enum.noTryOut;
            if (IVer_.ExitTryOut_VersionConfig == true)
            {
                DateTime stratDate = DateTime.Parse(IVer_.TryOutDateStart_VersionConfig);

                DateTime currentDate = DateTime.Now;

                IVer_.TryOutDateCurrendt_VersionConfig = currentDate.ToString("yyyy-MM-dd");

                DateTime stopDate = DateTime.Parse(IVer_.TryOutDateStop_VersionConfig);

                if (((stratDate == currentDate) || (stratDate < currentDate)) && (currentDate < stopDate))
                {
                    tryOut_ = tryOut_enum.tryOutDuring;
                }
                else
                {
                    tryOut_ = tryOut_enum.outOfDate;
                }
            }
            return tryOut_;
        }

        #endregion

        #region  检测是否需要强制停止
        /// <summary>
        /// 检测是否需要强制停止
        /// </summary>
        /// <param name="IVer_"></param>
        /// <returns></returns>
        internal force_enum CheckForce(IVersionConfig IVer_)
        {
            force_enum force_ = force_enum.stopForce;

            if (IVer_.ExitForceStop == true)
            {
                force_ = force_enum.startForce;

                DateTime dt1 = DateTime.Parse(IVer_.ForceStopDate_VersionConfig);

                if (DateTime.Now > dt1)
                {
                    force_ = force_enum.expireForce;
                }
            }

            return force_;
        }

        #endregion
    }
    #endregion

}
