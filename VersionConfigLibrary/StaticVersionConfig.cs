using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;



namespace VersionConfigLibrary
{
    public static class StaticVersionConfig
    {
        #region  全局变量
        #region  数据接口
        /// <summary>
        /// 数据接口
        /// </summary>
        static IVersionConfig _iVer;
        #endregion

        #region    检测数据接口线程
        /// <summary>
        /// 一定时间间隔内触发事件处理
        /// </summary>
        static System.Threading.Timer checkTimer = null;

        /// <summary>
        /// 时间间隔到了后，回调的方法
        /// </summary>
        static TimerCallback timerCallBack;

        /// <summary>
        /// 触发
        /// </summary>
        static AutoResetEvent autoEvent;
        #endregion

        #region   数据检测器
        /// <summary>
        /// 数据检测器
        /// </summary>
        static Check_VersionConfig _checkVersionConfig = null;
        #endregion
        #endregion

        #region  属性

        #region  匹配文件数据
        /// <summary>
        /// 匹配文件数据
        /// </summary>
        internal static IVersionConfig IVer
        {
            get
            {
                if (_iVer == null)
                {
                    Set_Get_VersionConfig _setGetVersionConfig = new Set_Get_VersionConfig();
                    VersionConfig Version_;
                    _setGetVersionConfig.fanXuLeiHua<VersionConfig>(out Version_, System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "VersionConfig.config");
                    _iVer = Version_;
                }
                return StaticVersionConfig._iVer;
            }
            set { StaticVersionConfig._iVer = value; }
        }
        #endregion

        #region     数据检测器
        /// <summary>
        /// 数据检测器
        /// </summary>
        internal static Check_VersionConfig CheckVersionConfig
        {
            get
            {
                if (_checkVersionConfig == null)
                {
                    StaticVersionConfig._checkVersionConfig = new Check_VersionConfig();
                }
                return StaticVersionConfig._checkVersionConfig;
            }

            set { StaticVersionConfig._checkVersionConfig = value; }
        }
        #endregion

        #endregion

        #region  初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="period">检测的时间间隔</param>
        /// <returns></returns>
        public static bool initCheckVersionConfig(int period)
        {
            if (checkTimer != null)
                return true;

            int period_ = 6000 * 10;
            bool ok = false;

            autoEvent = new AutoResetEvent(false);
            timerCallBack = new TimerCallback(CallbackTask);

            if (period > 0)
            {
                period_ = period;
            }

            checkTimer = new System.Threading.Timer(timerCallBack, autoEvent, 1000, period_);
            ok = true;
            return ok;
        }
        #endregion

        #region   停止检测配置文件
        /// <summary>
        /// 停止检测配置文件
        /// </summary>
        /// <returns></returns>
        public static bool stopCheckVersionConfig()
        {
            if (checkTimer == null)
                return true;

            bool ok = false;
            checkTimer.Dispose();
            checkTimer = null;
            ok = true;
            return ok;
        }
        #endregion

        #region 回调方法
        /// <summary>
        /// 回调方法，检测配置文件
        /// </summary>
        /// <param name="stateInfo"></param>
        private static void CallbackTask(Object stateInfo)
        {
            #region   检测下文件是否存在
            if (CheckVersionConfig.CheckConfigFolderExit() == false)
            {
                MessageBox.Show("软件的匹配文件不存在，请联系厂家");
                Environment.Exit(0);
            }
            #endregion

            #region   检测是否存在试用期
            tryOut_enum tryOuy_ = CheckVersionConfig.CheckTryOut(IVer);
            switch (tryOuy_)
            {
                case tryOut_enum.noTryOut:

                    break;
                case tryOut_enum.outOfDate:
                    MessageBox.Show("软件的试用期过期，已经启动强制停止软件，请联系厂家");
                    force_enum force_ = CheckVersionConfig.CheckForce(IVer);

                    switch (force_)
                    {
                        case force_enum.expireForce:
                            Environment.Exit(0);
                            break;
                        case force_enum.startForce:

                            break;
                        case force_enum.stopForce:
                            break;
                    }

                    break;
                case tryOut_enum.tryOutDuring:

                    break;

                default:

                    break;
            }

            #endregion
        }
        #endregion
        
        #region     设置工具是否启动

        public static void Set_Tool_Start_Stop()
        {
 
        }
        #endregion
    }
}
