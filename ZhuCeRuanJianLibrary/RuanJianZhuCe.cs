using System;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Windows.Forms;
using XmlLibrary;


namespace ZhuCeRuanJianLibrary
{
    #region  软件注册
    /// <summary>
    ///软件注册 
    /// </summary>
    internal static class RuanJianZhuCe
    {
        #region  全局变量
        /// <summary>
        /// 函数反回标志
        /// </summary>
        static bool Stupids = true;
        /// <summary>
        /// 函数反回标志
        /// </summary>
        static bool Cat = false;
        #endregion

        #region 步骤四: 用户输入注册码注册软件
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="currentCode"></param>
        /// <param name="realCode"></param>
        /// <returns></returns>
        public static bool RegistIt(string currentCode, string realCode)
        {
            if (realCode != "")
            {
                //string ss = realCode.TrimEnd();
                if (currentCode.TrimEnd().Equals(realCode.TrimEnd()))
                {
                    Microsoft.Win32.RegistryKey retkey =
                         Microsoft.Win32.Registry.CurrentUser.
                         OpenSubKey("software", true).CreateSubKey("StupidsCat").
                         CreateSubKey("StupidsCat.ini").
                         CreateSubKey(currentCode.TrimEnd());
                    retkey.SetValue("StupidsCat", "BBC6D58D0953F027760A046D58D52786");

                    retkey = Microsoft.Win32.Registry.LocalMachine.
                        OpenSubKey("software", true).CreateSubKey("StupidsCat").
                         CreateSubKey("StupidsCat.ini").
                         CreateSubKey(currentCode.TrimEnd());
                    retkey.SetValue("StupidsCat", "BBC6D58D0953F027760A046D58D52786");
                    return Stupids;
                }
                else
                {
                    return Cat;
                }
            }
            else { return Cat; }
        }
        #endregion

        #region  判断软件是不是注册了
        /// <summary>
        /// 判断软件是不是注册了
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        public static bool BoolRegist(string temp)
        {
            string[] keynames; bool flag = false;

            Microsoft.Win32.RegistryKey localRegKey = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey userRegKey = Microsoft.Win32.Registry.CurrentUser;
            try
            {
                keynames = localRegKey.OpenSubKey("software\\StupidsCat\\StupidsCat.ini\\" + temp).GetValueNames();
                foreach (string name in keynames)
                {
                    if (name == "StupidsCat")
                    {
                        if (localRegKey.OpenSubKey("software\\StupidsCat\\StupidsCat.ini\\" + temp).GetValue("StupidsCat").ToString() == "BBC6D58D0953F027760A046D58D52786")
                            flag = true;
                    }
                }
                keynames = userRegKey.OpenSubKey("software\\StupidsCat\\StupidsCat.ini\\" + temp).GetValueNames();
                foreach (string name in keynames)
                {
                    if (name == "StupidsCat")
                    {
                        if (flag && userRegKey.OpenSubKey("software\\StupidsCat\\StupidsCat.ini\\" + temp).GetValue("StupidsCat").ToString() == "BBC6D58D0953F027760A046D58D52786")
                            return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                localRegKey.Close();
                userRegKey.Close();
            }
        }
        #endregion
    }
    #endregion

    #region  生成机器码
    /// <summary>
    /// 生成机器码
    /// </summary>
    internal static class ShengChengJiQiMa
    {
        #region  全局变量
        /// <summary>
        /// 函数反回标志
        /// </summary>
        static bool Stupids = true;
        /// <summary>
        /// 函数反回标志
        /// </summary>
        static bool Cat = false;
        #endregion

        #region  步骤一: 获得CUP序列号和硬盘序列号的实现代码如下
        /// <summary>
        /// 获得CUP序列号
        /// </summary>
        /// <returns></returns>
        static string getCpu()
        {
            string strCpu = null;
            ManagementClass myCpu = new ManagementClass("win32_Processor");
            ManagementObjectCollection myCpuConnection = myCpu.GetInstances();
            foreach (ManagementObject myObject in myCpuConnection)
            {
                strCpu = myObject.Properties["Processorid"].Value.ToString();
                break;
            }
            return strCpu;
        }

        /// <summary>
        /// 取得设备硬盘的卷标号
        /// </summary>
        /// <returns></returns>
        static string GetDiskVolumeSerialNumber()
        {
            ManagementClass mc =
                 new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk =
                 new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            return disk.GetPropertyValue("VolumeSerialNumber").ToString();
        }

        #endregion

        #region  步骤二: 收集硬件信息生成机器码
        /// <summary>
        /// 生成机器码
        /// </summary>
        /// <returns></returns>
        public static string CreateCode()
        {
            #region  无用代码
            //string temp = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            //string[] strid = new string[24];//
            //for (int i = 0; i < 24; i++)//把字符赋给数组
            //{
            //    strid[i] = temp.Substring(i, 1);
            //}
            //temp = "";
            ////Random rdid = new Random();
            //for (int i = 0; i < 24; i++)//从数组随机抽取24个字符组成新的字符生成机器三
            //{
            //    //temp += strid[rdid.Next(0, 24)];
            //    temp += strid[i + 3 >= 24 ? 0 : i + 3];
            //}
            #endregion
            return GetMd5(CreateCodeNoMd5());
        }

        /// <summary>
        /// 生成没有加密的机器码
        /// </summary>
        /// <returns></returns>
        static string CreateCodeNoMd5()
        {
            string temp = getCpu() + GetDiskVolumeSerialNumber();//获得24位Cpu和硬盘序列号
            string[] strid = new string[24];//
            for (int i = 0; i < 24; i++)//把字符赋给数组
            {
                strid[i] = temp.Substring(i, 1);
            }
            temp = "";
            //Random rdid = new Random();
            for (int i = 0; i < 24; i++)//从数组随机抽取24个字符组成新的字符生成机器三
            {
                //temp += strid[rdid.Next(0, 24)];
                temp += strid[i + 3 >= 24 ? 0 : i + 3];
            }
            return temp;
        }

        #endregion

        #region  使用MD5加密生成机器码
        /// <summary>
        /// 使用MD5加密生成机器码
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string GetMd5(object text)
        {
            string path = text.ToString();

            MD5CryptoServiceProvider MD5Pro = new MD5CryptoServiceProvider();
            Byte[] buffer = Encoding.GetEncoding("utf-8").GetBytes(text.ToString());
            Byte[] byteResult = MD5Pro.ComputeHash(buffer);

            string md5result = BitConverter.ToString(byteResult).Replace("-", "");
            return md5result;
        }
        #endregion
    }

    #endregion

    #region 生成注册码
    /// <summary>
    /// 生成注册码
    /// </summary>
    public static class ShengChengZhuCeMa
    {
        #region  步骤三: 使用机器码生成软件注册码
        //步骤三: 使用机器码生成软件注册码, 代码如下:
        //使用机器码生成注册码

        /// <summary>
        /// 用于存密钥
        /// </summary>
        static int[] intCode = new int[127];

        /// <summary>
        /// 给数组赋值个小于10的随机数
        /// </summary>
        static void setIntCode()
        {
            #region   无用代码
            //Random ra = new Random();
            //for (int i = 1; i < intCode.Length;i++ )
            //{
            //    intCode[i] = ra.Next(0, 9);
            //}
            #endregion

            for (int i = 1; i < intCode.Length; i++)
            {
                intCode[i] = i + 3 > 9 ? 0 : i + 3;
            }
        }

        /// <summary>
        /// 用于存机器码的Ascii值
        /// </summary>
        static int[] intNumber = new int[25];

        /// <summary>
        /// 存储机器码字
        /// </summary>
        static char[] Charcode = new char[25];

        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <param name="code">机器码</param>
        /// <returns></returns>
        public static string GetCode(string code)
        {
            if (code != "")
            {
                //把机器码存入数组中
                setIntCode();//初始化127位数组
                for (int i = 1; i < Charcode.Length; i++)//把机器码存入数组中
                {
                    Charcode[i] = Convert.ToChar(code.Substring(i - 1, 1));
                }
                for (int j = 1; j < intNumber.Length; j++)//把字符的ASCII值存入一个整数组中。
                {
                    intNumber[j] =
                       intCode[Convert.ToInt32(Charcode[j])] +
                       Convert.ToInt32(Charcode[j]);

                }
                string strAsciiName = null;//用于存储机器码
                for (int j = 1; j < intNumber.Length; j++)
                {
                    //MessageBox.Show((Convert.ToChar(intNumber[j])).ToString());
                    //判断字符ASCII值是否0－9之间

                    if (intNumber[j] >= 48 && intNumber[j] <= 57)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    //判断字符ASCII值是否A－Z之间

                    else if (intNumber[j] >= 65 && intNumber[j] <= 90)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    //判断字符ASCII值是否a－z之间


                    else if (intNumber[j] >= 97 && intNumber[j] <= 122)
                    {
                        strAsciiName += Convert.ToChar(intNumber[j]).ToString();
                    }
                    else//判断字符ASCII值不在以上范围内
                    {
                        if (intNumber[j] > 122)//判断字符ASCII值是否大于z
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] - 10).ToString();
                        }
                        else
                        {
                            strAsciiName += Convert.ToChar(intNumber[j] - 9).ToString();
                        }
                    }
                    //label3.Text = strAsciiName;//得到注册码
                }
                return strAsciiName;
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
    #endregion

    #region  检测软件是不是已经注册
    /// <summary>
    /// 检测软件是不是已经注册
    /// </summary>
    public static class CheckRuanJianShiBuShiZhuCe
    {
        #region   检测软件是不是已经注册
        /// <summary>
        /// 检测软件是不是已经注册
        /// </summary>
        /// <returns></returns>
        public static bool CheckShiFoZhuCe()
        {
            bool ok = false;
            #region   判断注册的配置文件是否存在
            //if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\" + typeof(ZhuCeMaPeiZhiWenJian).FullName + ".xml")))
            if (File.Exists(XmlDataCfgMgr<ZhuCeMaPeiZhiWenJian>.FileName))
            {
                ZhuCeMaPeiZhiWenJian zhu = new ZhuCeMaPeiZhiWenJian();
                /********加载配置文件************/
                XmlLibrary.XmlDataCfgMgr<ZhuCeMaPeiZhiWenJian>.GetV(ref zhu);
                /*******判断注册码是否一样**********/
                switch (RuanJianZhuCe.BoolRegist(zhu.ZhuCeMa))
                {
                    case false:
                        ZhuCeRuanJianLibrary.UI.ZhuCeRuanJianFrm frm = new UI.ZhuCeRuanJianFrm();

                        if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            MessageBox.Show("注册成功");
                            ok = true;
                        }
                        else
                        {
                            MessageBox.Show("注册失败");
                        }
                        break;

                    case true:
                        ok = true;
                        break;

                    default:
                        ok = false;
                        break;
                }
            }
            else
            {
                ZhuCeRuanJianLibrary.UI.ZhuCeRuanJianFrm frm = new UI.ZhuCeRuanJianFrm();

                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("注册成功");
                    ok = true;
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
            #endregion

            if (ok == false)
            {
                Environment.Exit(0);
            }
            return ok;
        }

        #endregion
    }
    #endregion

    #region  注册码配置文件
    /// <summary>
    /// 注册码配置文件
    /// </summary>
    public class ZhuCeMaPeiZhiWenJian
    {
        #region  注册码
        /// <summary>
        /// 注册码
        /// </summary>
        public string ZhuCeMa = "00000";
        #endregion
    }
    #endregion
}
