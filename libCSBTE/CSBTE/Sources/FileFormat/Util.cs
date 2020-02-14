using System;
using System.IO;

namespace CSBTE.FileFormat
{
   public class Util
    {
       public static void LogToFile(string txt)
       {
           using (StreamWriter sr = File.AppendText("launcher\\logs.txt"))
           {
               sr.WriteLine(string.Format("[{0}] - {1}", DateTime.Now.ToString("HH:mm:ss tt"), txt));
               sr.Close();
           }
       }
       public static string cfgGetValue(string key, string file)
       {
           string[] lines = System.IO.File.ReadAllLines(file);
           string valuefinal = null;
           foreach (string l in lines)
           {
               if (l.StartsWith(key))
               {
                   valuefinal = l.Replace(key + " ", "");
                   valuefinal = valuefinal.Replace("\"", "");
                   break;
               }
           }
           return valuefinal;
       }
       public static void cfgWriteValue(string key, string value, string file)
       {
           string getext = file.Substring(file.LastIndexOf('.'));
           string tmp = file.Replace(getext, ".tmp");
           using (var sr = new StreamReader(file))
           using (var wr = new StreamWriter(tmp))
           {
               bool check = false;
               string line = string.Empty;
               while (null != (line = sr.ReadLine()))
               {

                   if (line.StartsWith(key))
                   {
                       line = string.Format("{0} \"{1}\"", key, value);
                       check = true;
                   }
                   wr.WriteLine(line);
               }
               if (!check) wr.WriteLine(string.Format("{0} \"{1}\"", key, value));
               sr.Close();
               wr.Close();
           }
           File.Delete(file);
           File.Move(tmp, file);
       }
    }

}
