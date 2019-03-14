using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.Text;
using System.IO;

namespace VersionConfigLibrary
{
    public class XmlDataCfgMgr<T> where T : class
    {

        private static string _Dir = @"Config\";

        private static string fileNamePath = "";

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
        private XmlDataCfgMgr()
        {

        }

        private static Lazy<XmlDataCfgMgr<T>> _Lazy = new Lazy<XmlDataCfgMgr<T>>(() =>
        {
            return new XmlDataCfgMgr<T>();
        }, true);

        public static T GetV(ref T def)
        {
            return def = _Lazy.Value.Get();
        }

        public T Get()
        {
            return Deserializer() as T;
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SaveV(T obj)
        {
            return _Lazy.Value.Save(obj);
        }

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
        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Save(T obj)
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
    }
}