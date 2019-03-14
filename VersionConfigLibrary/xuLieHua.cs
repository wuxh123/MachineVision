using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Windows.Forms;


namespace VersionConfigLibrary
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class xuLieHua
    {
        /// <summary>
        /// 判断配置文件名是否在应用程序目录下存在
        /// </summary>
        /// <param name="name">传入的文件名，带后缀名，不带\\</param>
        /// <returns> 返回null文件不存在，返回文件名文件存在</returns>
        public string file_exist(string name)
        {
            string path = name;
            string str = Application.StartupPath + "\\" + name;
            if (!File.Exists(str))
            {
                path = null;
            }
            return path;

        }

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


        ~xuLieHua()
        {

        }


    }
}
