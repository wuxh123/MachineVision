using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace LogClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class LogManager
    {
        private static string logPath = string.Empty;
       
        /// <summary>
        /// 保存日志的文件夹
        /// </summary>
        public static string LogPath
        {
            get
            {
                if (logPath == string.Empty)
                {
                    logPath = AppDomain.CurrentDomain.BaseDirectory + @"log\";
                }
                return logPath;
            }
            set { logPath = value; }
        }

        private static string logFielPrefix = string.Empty;
       
        /// <summary>
        /// 日志文件前缀
        /// </summary>
        public static string LogFielPrefix
        {
            get { return logFielPrefix; }
            set { logFielPrefix = value; }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(string logFile, string msg)
        {
            try
            {
                #region 确保目录存在
                DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(LogPath + LogFielPrefix + logFile + " " +
                    DateTime.Now.ToString("yyyyMMdd") + ".Log"));
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

                System.IO.StreamWriter sw = System.IO.File.AppendText(
                    LogPath + LogFielPrefix + logFile + " " +
                    DateTime.Now.ToString("yyyyMMdd") + ".Log"
                    );
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ") + msg);
                sw.Close();
            }
            catch
            {
                throw new Exception("日志读写失败");
            }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(LogFile logFile, string msg)
        {
            WriteLog(logFile.ToString(), msg);
        }
    }

    /// <summary>
    /// 日志类型
    /// </summary>
    public enum LogFile
    {
        Trace,
        Warning,
        Error,
        SQL,
        MES,
        Sys
    }
}
