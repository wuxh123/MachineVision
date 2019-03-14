using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace XmlLibrary
{
    /// <summary>
    /// xml工具类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class XmlDataCfgMgr<T> where T : class
    {
        #region  全局变量
        /// <summary>
        /// 文件夹
        /// </summary>
        private static string _Dir = @"Config\";

        /// <summary>
        /// 文件的路径
        /// </summary>
        private static string fileNamePath = "";

        /// <summary>
        /// 文件的名称
        /// </summary>
        public static string FileName
        {
            get
            {
                var t = typeof(T);
                while (t.IsGenericType)
                {
                    var a = t.GetGenericArguments();
                    if (a.Length > 0) t = a[0];

                }

                if (Path.IsPathRooted(fileNamePath))
                {
                    return fileNamePath;
                }
                else
                {
                    //这里,_Dir清明不要有/或\
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _Dir + t.FullName + ".xml");
                }
            }

            set
            {
                fileNamePath = value;
            }


        }
        #endregion

        #region  构造函数
        /// <summary>
        /// 
        /// </summary>
        private XmlDataCfgMgr()
        {

        }
        #endregion

        #region  延时编译
        /// <summary>
        /// 
        /// </summary>
        private static Lazy<XmlDataCfgMgr<T>> _Lazy = new Lazy<XmlDataCfgMgr<T>>(() =>
        {
            return new XmlDataCfgMgr<T>();
        }, true);
        #endregion

        #region  加载配置文件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T GetV(ref T def)
        {
            return def = _Lazy.Value.Get();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Get()
        {
            return Deserializer() as T;
        }
        #endregion

        #region  保存配置文件  
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SaveV(T obj)
        {
            return _Lazy.Value.Save(obj);
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        string Save(T obj)
        {
            //执行xml序列化
            var type = typeof(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, obj);
            }
            #region 确保目录存在
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(FileName));
            var dir = dirInfo;
            Stack<DirectoryInfo> needCreatedDirs = new Stack<DirectoryInfo>();
            while (!dir.Exists)
            {
                needCreatedDirs.Push(dir);
                dir = dir.Parent;
            }
            while (needCreatedDirs.Count > 0)
            {
                needCreatedDirs.Pop().Create();
            }
            #endregion

            File.WriteAllText(FileName, sb.ToString());
            return sb.ToString();
        }
        #endregion

        #region  序列类成xml
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private T Deserializer()
        {
            T obj = null;
            try
            {
                var xml = LoadContent().Trim();
                if (string.IsNullOrEmpty(xml)) return null;
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                using (var sr = new StringReader(xml))
                {
                    obj = serializer.Deserialize(sr) as T;
                }
            }
            catch { }

            return obj;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string LoadContent()
        {
            if (!File.Exists(FileName))
            {
                return string.Empty;
            }
            try
            {
                var content = File.ReadAllText(FileName);
                return content;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

    }
}