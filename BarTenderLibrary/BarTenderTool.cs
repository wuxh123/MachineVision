using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BarTender;
using IniLibrary;
using System.IO;
using System.Windows.Forms;



namespace BarTenderLibrary
{
    #region 外部委托
    /// <summary>
    /// 委托
    /// </summary>
    public delegate void BartenderPrintFinsihDel();
    #endregion

    #region  bartender 工具
    /// <summary>
    /// BarTender工具
    /// </summary>
    public class BarTenderTool : IDisposable, IBarTenderTool
    {
        #region   委托，事件
        /// <summary>
        /// 打印委托
        /// </summary>
        delegate void BartenderPrintDel();
        /// <summary>
        /// 打印事件
        /// </summary>
        event BartenderPrintDel BartenderPrintEvent;

        /// <summary>
        /// 打印完后出发的事件
        /// </summary>
        public event BartenderPrintFinsihDel FinishPrint;
        #endregion

        #region    bartender程序
        /// <summary>
        ///  bartender程序
        /// </summary>
        BarTender.Application btApp;
        #endregion

        #region   打印文件btw的路径
        /// <summary>
        ///  打印文件btw的路径
        /// </summary>
        string pathFileName = null;
        #endregion

        #region  设置同序列打印的份数
        /// <summary>
        /// 设置同序列打印的份数
        /// </summary>
        int IdenticalCopiesOfLabel = 0;
        #endregion

        #region  设置需要打印的序列数
        /// <summary>
        /// 设置需要打印的序列数
        /// </summary>
        int NumberSerializedLabels = 0;
        #endregion

        #region  打印的格式
        /// <summary>
        /// 打印的格式
        /// </summary>
        BarTender.Format btFormat = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public BarTenderTool()
        {
            btApp = new BarTender.Application();

            BartenderPrintEvent += BartenderPrint;
        }
        #endregion

        #region  属性
        /// <summary>
        /// 打印文件btw的路径
        /// </summary>
        public string PathFileName
        {
            get
            {
                if (pathFileName == null)
                {
                    pathFileName = System.Windows.Forms.Application.StartupPath + "\\Bartender\\TRAY_LABEL.btw";
                }
                return pathFileName;
            }
            set { pathFileName = value; }
        }


        /// <summary>
        /// 设置同序列打印的份数
        /// </summary>
        public int IdenticalCopiesOfLabel1
        {
            get
            {
                if (IdenticalCopiesOfLabel == 0)
                {
                    IdenticalCopiesOfLabel = 1;
                }
                return IdenticalCopiesOfLabel;
            }
            set { IdenticalCopiesOfLabel = value; }
        }

        /// <summary>
        /// 设置需要打印的序列数
        /// </summary>
        public int NumberSerializedLabels1
        {
            get
            {
                if (NumberSerializedLabels == 0)
                {
                    NumberSerializedLabels = 1;
                }
                return NumberSerializedLabels;
            }
            set { NumberSerializedLabels = value; }
        }


        /// <summary>
        /// 打印的格式
        /// </summary>
        public BarTender.Format BtFormat
        {
            get
            {
                if (btFormat == null)
                {
                    btFormat = btApp.Formats.Open(PathFileName, false, "");
                    btFormat.PrintSetup.IdenticalCopiesOfLabel = IdenticalCopiesOfLabel1;  //设置同序列打印的份数
                    btFormat.PrintSetup.NumberSerializedLabels = NumberSerializedLabels1;  //设置需要打印的序列数  
                }
                return btFormat;
            }
            set { btFormat = value; }
        }

        #endregion

        #region   触发打印
        /// <summary>
        /// 触发打印
        /// </summary>
        public void TriggerPrint()
        {
            if (BartenderPrintEvent != null)
            {
                BartenderPrintEvent();
            }
        }
        #endregion

        #region   打印
        /// <summary>
        /// 打印
        /// </summary>
        void BartenderPrint()
        {
            BtFormat.PrintOut(false, false); //第二个false设置打印时是否跳出打印属性

            if (FinishPrint != null)
            {
                FinishPrint();
            }
        }
        #endregion

        #region   释放资源
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (btFormat != null)
            {
                btFormat.Close(); //退出时是否保存标签
                btFormat = null;
            }

            if (btApp != null)
            {
                btApp = null;
            }
        }
        #endregion
    }
    #endregion

    #region   bartender接口
    /// <summary>
    ///  bartender接口
    /// </summary>
    public interface IBarTenderTool
    {
        #region  属性
        /// <summary>
        /// 打印文件btw的路径
        /// </summary>
        string PathFileName
        {
            get
          ;
            set;
        }


        /// <summary>
        /// 设置同序列打印的份数
        /// </summary>
        int IdenticalCopiesOfLabel1
        {
            get
          ;
            set;
        }

        /// <summary>
        /// 设置需要打印的序列数
        /// </summary>
        int NumberSerializedLabels1
        {
            get
           ;
            set;
        }


        /// <summary>
        /// 打印的格式
        /// </summary>
        BarTender.Format BtFormat
        {
            get
           ;
            set;
        }

        #endregion

        #region   触发打印
        /// <summary>
        /// 触发打印
        /// </summary>
        void TriggerPrint();
        #endregion

        #region
        /// <summary>
        /// 打印完后出发的事件
        /// </summary>
        event BartenderPrintFinsihDel FinishPrint;
        #endregion

    }
    #endregion

    #region  设置bartender
    /// <summary>
    /// 设置bartender数据类
    /// </summary>
    public class SetBartender
    {
        #region   加载配置
        /// <summary>
        /// 加载bartender配置
        /// </summary>
        /// <param name="ba">传入修改的数据</param>
        /// <returns></returns>
        public bool LoadBartenderIniConfig(IBarTenderTool ba)
        {
            bool ok = false;

            string filename = "BartenderConfig";
            IniLibrary.IniTool initool = new IniTool(ref filename, "BartenderConfig", null);

            if (File.Exists(initool.FileName_Path1))
            {
                ba.IdenticalCopiesOfLabel1 = Convert.ToInt32(initool.ReadString(ba.ToString(), "IdenticalCopiesOfLabel1", "1"));
                ba.NumberSerializedLabels1 = Convert.ToInt32(initool.ReadString(ba.ToString(), "NumberSerializedLabels1", "1"));
                ba.PathFileName = initool.ReadString(ba.ToString(), "PathFileName", ba.PathFileName);
            }
            else
            {
                initool.WriteString(ba.ToString(), "IdenticalCopiesOfLabel1", ba.IdenticalCopiesOfLabel1.ToString());
                initool.WriteString(ba.ToString(), "NumberSerializedLabels1", ba.NumberSerializedLabels1.ToString());
                initool.WriteString(ba.ToString(), "PathFileName", ba.PathFileName);
            }
            ok = true;
            return ok;
        }

        #endregion

        #region   保存bartender配置
        /// <summary>
        /// 保存bartender配置
        /// </summary>
        /// <param name="ba"></param>
        /// <returns></returns>
        public bool SaveBatenderIniConfig(IBarTenderTool ba)
        {
            bool ok = false;
            string filename = "BartenderConfig";
            IniLibrary.IniTool initool = new IniTool(ref filename, "BartenderConfig", null);
            initool.WriteString(ba.ToString(), "IdenticalCopiesOfLabel1", ba.IdenticalCopiesOfLabel1.ToString());
            initool.WriteString(ba.ToString(), "NumberSerializedLabels1", ba.NumberSerializedLabels1.ToString());
            initool.WriteString(ba.ToString(), "PathFileName", ba.PathFileName);
            ok = true;
            return ok;
        }


        #endregion

        #region   bartender修改配置
        /// <summary>
        /// bartender修改配置
        /// </summary>
        /// <param name="IBartender">传入的数据</param>
        /// <param name="pathFileName">数据为null时表示不设置</param>
        /// <param name="IdenticalCopiesOfLabel">数据为null时表示不设置</param>
        /// <param name="NumberSerializedLabels">数据为null时表示不设置</param>
        /// <returns></returns>
        public bool SetBartenderConfig(IBarTenderTool IBartender, string pathFileName, string IdenticalCopiesOfLabel, string NumberSerializedLabels)
        {
            bool ok = false;
            if (pathFileName != null)
            {
                IBartender.PathFileName = pathFileName;
            }

            if (IdenticalCopiesOfLabel != null)
            {
                IBartender.IdenticalCopiesOfLabel1 = Convert.ToInt32(IdenticalCopiesOfLabel);
            }

            if (NumberSerializedLabels != null)
            {
                IBartender.NumberSerializedLabels1 = Convert.ToInt32(NumberSerializedLabels);
            }

            ok = true;
            return ok;
        }


        #endregion

        #region  输出显示配置
        /// <summary>
        /// 输出bartender显示配置
        /// </summary>
        /// <param name="ba"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public bool ShowBartenderConfig(IBarTenderTool ba, Control.ControlCollection control)
        {
            bool ok = false;

            try
            {
                foreach (Control con in control)
                {
                    string name = con.Name;
                    if ((con is ComboBox) || (con is TextBox) || (con is Label))
                    {
                        switch (name)
                        {
                            case "IdenticalCopiesOfLabel1":

                                con.Text = ba.IdenticalCopiesOfLabel1.ToString();

                                break;

                            case "NumberSerializedLabels1":
                                con.Text = ba.NumberSerializedLabels1.ToString();
                                break;
                            case "PathFileName":
                                con.Text = ba.PathFileName;
                                break;
                            default:
                                break;
                        }
                    }

                    if (con.Controls.Count > 0)
                    {
                        ShowBartenderConfig(ba, con.Controls);
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
    }
    #endregion

    #region   静态bartender打印工具
    /// <summary>
    /// 静态bartender打印工具
    /// </summary>
    public static class StaticBartenderTool
    {
        #region  静态bartender工具接口 
        /// <summary>
        /// 静态bartender工具接口
        /// </summary>
        private static IBarTenderTool _IBar = null;
        #endregion 

        #region  静态bartender工具接口
        /// <summary>
        /// 静态bartender工具接口
        /// </summary>
        public static IBarTenderTool IBar1
        {
            get {
                if(_IBar == null)
                {
                
                    _IBar = new BarTenderLibrary.BarTenderTool();
                    SetBartender Set_ = new SetBartender();
                    Set_.LoadBartenderIniConfig(_IBar);
                
                }                
                return StaticBartenderTool._IBar; }
            set { StaticBartenderTool._IBar = value; }
        }
        #endregion 

        #region   打印的次数
        /// <summary>
        /// 打印的次数
        /// </summary>
        static int BartenderPrintNumber = 1;
     
        /// <summary>
        /// 打印的次数
        /// </summary>
        public static int BartenderPrintNumber1
        {
            get
            {
                if (BartenderPrintNumber < 0)
                {
                    BartenderPrintNumber = 0;
                }
                return BartenderPrintNumber;
            }
            set { BartenderPrintNumber = value; }
        }
        #endregion
    }
    #endregion
}
