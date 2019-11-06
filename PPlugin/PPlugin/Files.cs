using System;
using System.IO;

namespace PPlugin
{
    public class Files
    {
        public static string GetText(string path)
        {
            string data = "";

            try
            {
                data = File.ReadAllText($"info/{path}");
            }
            catch
            {
                File.WriteAllText($"info/{path}", data);
            }

            return data;
        }

        public static void SetText(string path, string data)
        {
            File.WriteAllText($"info/{path}", data);
        }
    }
}
