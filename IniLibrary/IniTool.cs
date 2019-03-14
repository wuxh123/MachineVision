using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.IO;

namespace IniLibrary
{
    /// <summary>
    /// ini工具
    /// </summary>
    public class IniTool
    {
        #region  ini文件名
        /// <summary>
        /// INI文件名
        /// </summary>
        string FileName_Path; //INI文件名的文件夹  
        #endregion

        #region  属性
        /// <summary>
        /// INI文件名
        /// </summary>
        public string FileName_Path1
        {
            get
            {
                return FileName_Path;
            }
        }
        #endregion

        #region API函数声明
        //写INI文件的API函数声明读 
        /// <summary>
        /// 写ini文件
        /// </summary>
        /// <param name="section">章节</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        /// <param name="filePath">文件路劲</param>
        /// <returns>返回真为成功</returns>
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

        /// <summary>
        ///读取ini文件 
        /// </summary>
        /// <param name="section">章节</param>
        /// <param name="key">键</param>
        /// <param name="def">设置没有读取到时返回的值</param>
        /// <param name="retVal">指定一个字串缓冲区，长度至少为Size</param>
        /// <param name="size">指定装载到缓冲区的最大字符数量</param>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化函数
        /// </summary>
        /// <param name="FileName">要创建ini的文件名,输入时不加.ini后缀</param>
        /// <param name="FolderName">要在PathName目录下建立的文件夹，null表示不创建</param>
        /// <param name="PathName">建立ini文件的路劲，null表示采用默认路径</param>
        public IniTool(ref string FileName, string FolderName, string PathName)
        {
            if (PathName == null)
            {
                FileName_Path = AppDomain.CurrentDomain.BaseDirectory;
            }   
            else
            {
                FileName_Path = PathName;
            }

            if (FolderName != null)
            {
                FileName_Path = FileName_Path + FolderName + "\\";

                if (!Directory.Exists(Path.GetDirectoryName(FileName_Path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(FileName_Path));
                }
            }

            FileName_Path = FileName_Path + FileName + ".ini";

            #region 无用代码
            //// 判断文件是否存在  
            //FileInfo fileInfo = new FileInfo(AFileName);
            ////Todo:搞清枚举的用法  
            //if ((!fileInfo.Exists))
            //{ //|| (FileAttributes.Directory in fileInfo.Attributes))  
            //    //文件不存在，建立文件  
            //    System.IO.StreamWriter sw = new System.IO.StreamWriter(AFileName, false, System.Text.Encoding.Default);
            //    try
            //    {
            //        sw.Write("#表格配置档案");
            //        sw.Close();
            //    }
            //    catch
            //    {
            //        throw (new ApplicationException("Ini文件不存在"));
            //    }
            //}
            ////必须是完全路径，不能是相对路径  
            //FileName = fileInfo.FullName;
            #endregion
        }
        #endregion

        #region 写ini文件
        /// <summary>
        /// 写INI文件  
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        /// <param name="Value">值</param>
        public void WriteString(string Section, string Ident, string Value)
        {
            if (!WritePrivateProfileString(Section, Ident, Value, FileName_Path))
            {
                throw (new ApplicationException("写Ini文件出错"));
            }
        }

        /// <summary>
        /// 写Bool 
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        /// <param name="Value">要写入的bool</param>
        public void WriteBool(string Section, string Ident, bool Value)
        {
            WriteString(Section, Ident, Convert.ToString(Value));
        }

        /// <summary>
        /// 写整数  
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        /// <param name="Value">值</param>
        public void WriteInteger(string Section, string Ident, int Value)
        {
            WriteString(Section, Ident, Value.ToString());
        }
        
        #endregion

        #region 读取ini文件
        /// <summary>
        /// 读取INI文件指定  
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        /// <param name="Default">设置读取不成功是返回的值</param>
        /// <returns>成功返回读取到的值</returns>
        public string ReadString(string Section, string Ident, string Default)
        {
            Byte[] Buffer = new Byte[65535];
            int bufLen = GetPrivateProfileString(Section, Ident, Default, Buffer, Buffer.GetUpperBound(0), FileName_Path);
            //必须设定0（系统默认的代码页）的编码方式，否则无法支持中文  
            string s = Encoding.GetEncoding(0).GetString(Buffer);
            s = s.Substring(0, bufLen);
            return s.Trim();
        }

        /// <summary>
        /// 读取整数
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        /// <param name="Default">设置读取不成功时返回的值</param>
        /// <returns>成功返回读取到的值</returns>
        public int ReadInteger(string Section, string Ident, int Default)
        {
            string intStr = ReadString(Section, Ident, Convert.ToString(Default));
            try
            {
                return Convert.ToInt32(intStr);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }


        /// <summary>
        /// 读布尔
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        /// <param name="Default">设置没有读取成功是的返回值</param>
        /// <returns>返回读取成功的值</returns>
        public bool ReadBool(string Section, string Ident, bool Default)
        {
            try
            {
                return Convert.ToBoolean(ReadString(Section, Ident, Convert.ToString(Default)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Default;
            }
        }

        /// <summary>
        /// 从Ini文件中，将指定的Section名称中的所有Ident添加到列表中 
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Idents">键的集合</param>
        public void ReadSection(string Section, StringCollection Idents)
        {
            Byte[] Buffer = new Byte[16384];
            //Idents.Clear();  

            int bufLen = GetPrivateProfileString(Section, null, null, Buffer, Buffer.GetUpperBound(0),
             FileName_Path);
            //对Section进行解析  
            GetStringsFromBuffer(Buffer, bufLen, Idents);
        }

        /// <summary>
        /// 从Ini文件中，读取所有的Sections的名称 
        /// </summary>
        /// <param name="SectionList">要读取的章节列表</param>
        public void ReadSections(StringCollection SectionList)
        {
            //Note:必须得用Bytes来实现，StringBuilder只能取到第一个Section  
            byte[] Buffer = new byte[65535];
            int bufLen = 0;
            bufLen = GetPrivateProfileString(null, null, null, Buffer,
             Buffer.GetUpperBound(0), FileName_Path);
            GetStringsFromBuffer(Buffer, bufLen, SectionList);
        }

        /// <summary>
        /// 读取指定的Section的所有Value到列表中  
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Values">值得集合</param>
        public void ReadSectionValues(string Section, NameValueCollection Values)
        {
            StringCollection KeyList = new StringCollection();
            ReadSection(Section, KeyList);
            Values.Clear();
            foreach (string key in KeyList)
            {
                Values.Add(key, ReadString(Section, key, ""));

            }
        }
        #endregion

        #region    
        private void GetStringsFromBuffer(Byte[] Buffer, int bufLen, StringCollection Strings)
        {
            Strings.Clear();
            if (bufLen != 0)
            {
                int start = 0;
                for (int i = 0; i < bufLen; i++)
                {
                    if ((Buffer[i] == 0) && ((i - start) > 0))
                    {
                        String s = Encoding.GetEncoding(0).GetString(Buffer, start, i - start);
                        Strings.Add(s);
                        start = i + 1;
                    }
                }
            }
        }
        #endregion

        #region 读取指定的Section的所有Value到列表中，
        /**/
        ////读取指定的Section的所有Value到列表中，  
        //public void ReadSectionValues(string Section, NameValueCollection Values,char splitString)  
        //{　 string sectionValue;  
        //　　string[] sectionValueSplit;  
        //　　StringCollection KeyList = new StringCollection();  
        //　　ReadSection(Section, KeyList);  
        //　　Values.Clear();  
        //　　foreach (string key in KeyList)  
        //　　{  
        //　　　　sectionValue=ReadString(Section, key, "");  
        //　　　　sectionValueSplit=sectionValue.Split(splitString);  
        //　　　　Values.Add(key, sectionValueSplit[0].ToString(),sectionValueSplit[1].ToString());  

        //　　}  
        //}  
        //
        #endregion

        #region 清除章节或键
        /// <summary>
        /// 清除某个Section  
        /// </summary>
        /// <param name="Section">章节</param>
        public void EraseSection(string Section)
        {
            //  
            if (!WritePrivateProfileString(Section, null, null, FileName_Path))
            {

                throw (new ApplicationException("无法清除Ini文件中的Section"));
            }
        }
       
        /// <summary>
        /// 删除某个Section下的键 
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        public void DeleteKey(string Section, string Ident)
        {
            WritePrivateProfileString(Section, Ident, null, FileName_Path);
        }
        #endregion

        //Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件  
        //在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile  
        //执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。  

        #region 清空ini文件
        /// <summary>
        /// 清空ini文件
        /// </summary>
        public void UpdateFile()
        {
            WritePrivateProfileString(null, null, null, FileName_Path);
        }
        #endregion

        #region 检测章节是否存在
        //
        /// <summary>
        /// 检查某个Section下的某个键值是否存在  
        /// </summary>
        /// <param name="Section">章节</param>
        /// <param name="Ident">键</param>
        /// <returns>返回真为存在</returns>
        public bool ValueExists(string Section, string Ident)
        {
            //  
            StringCollection Idents = new StringCollection();
            ReadSection(Section, Idents);
            return Idents.IndexOf(Ident) > -1;
        }
        #endregion

        #region 确保资源的释放
        /// <summary>
        /// 确保资源的释放  
        /// </summary>
        ~IniTool()
        {
            UpdateFile();
        }
        #endregion
    }
}
