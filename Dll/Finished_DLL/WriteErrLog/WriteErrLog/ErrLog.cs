using System;
using System.IO;
using System.Windows.Forms;

namespace WriteErrLog
{
    public class ErrLog
    {
        private static object LockObj = new object();
        public static void Add(Exception ex)
        {
            lock (LockObj)
            {
                string DirPath = Application.StartupPath + "\\ERRLOG\\";
                string FilePath = DirPath + "Err_" + DateTime.Today.ToString("yyyyMMdd") + ".log";

                string temp;

                DateTime NowDate = DateTime.Now;
                string Date = NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");

                DirectoryInfo di = new DirectoryInfo(DirPath);
                FileInfo fi = new FileInfo(FilePath);

                try
                {
                    if (di.Exists != true) Directory.CreateDirectory(DirPath);

                    if (fi.Exists != true)
                    {
                        using (StreamWriter sw = new StreamWriter(FilePath))
                        {
                            Console.WriteLine("에러 작성됨");
                            temp = string.Format("[{0}] : {1}", Date, ex.Message.ToString());
                            sw.WriteLine(temp);
                            sw.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(FilePath))
                        {
                            Console.WriteLine("에러 작성됨");
                            temp = string.Format("[{0}] : {1}", Date, ex.Message.ToString());
                            sw.WriteLine(temp);
                            sw.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        public static void Add(string 내용)
        {
            lock (LockObj)
            {
                string DirPath = Application.StartupPath + "\\ERRLOG\\";
                string FilePath = DirPath + "Err_" + DateTime.Today.ToString("yyyyMMdd") + ".log";

                string temp;

                DateTime NowDate = DateTime.Now;
                string Date = NowDate.ToString("yyyy-MM-dd HH:mm:ss") + ":" + NowDate.Millisecond.ToString("000");

                DirectoryInfo di = new DirectoryInfo(DirPath);
                FileInfo fi = new FileInfo(FilePath);

                try
                {
                    if (di.Exists != true) Directory.CreateDirectory(DirPath);

                    if (fi.Exists != true)
                    {
                        using (StreamWriter sw = new StreamWriter(FilePath))
                        {
                            Console.WriteLine("에러 작성됨");
                            temp = string.Format("[{0}] : {1}", Date, 내용);
                            sw.WriteLine(temp);
                            sw.Close();
                        }
                    }
                    else
                    {
                        using (StreamWriter sw = File.AppendText(FilePath))
                        {
                            Console.WriteLine("에러 작성됨");
                            temp = string.Format("[{0}] : {1}", Date, 내용);
                            sw.WriteLine(temp);
                            sw.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
