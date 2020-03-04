using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    static class JsonHelper
    {


        /// <summary>
        ///     将我们的json保存到路径
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="json"></param>
        public static void SaveMyJson(string Path, string json, string filename)
        {
            using (FileStream fs = new FileStream(string.Format("{0}\\{1}.json", Path, filename), FileMode.Create))
            {
                //写入
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(json);
                }

            }
        }

        /// <summary>
        ///     IO读取本地json
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public  static string GetMyJson(string filePath, string fileName)
        {
            using (FileStream fsRead = new FileStream(string.Format("{0}\\{1}.json", filePath, fileName), FileMode.Open))
            {
                //读取加转换
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                return System.Text.Encoding.UTF8.GetString(heByte);
            }
        }
    }
}
