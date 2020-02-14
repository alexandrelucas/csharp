using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace LibraryOwl.FileStream
{

    public class GetProfileString
    {
        string path;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        
        public GetProfileString(string FilePath)
        {
            path = FilePath;
            if (!System.IO.File.Exists(path)) throw new Exception(String.Format("File not found: {0}", path));
        }
        public void WriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }
        public string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();

        }
    }
    public class FileUsage
    {
        //Computer myComputer = new Computer(); //deprecapted uses only in vb.net
        
        public void LogToFile(string Text, string File)
        {
            using (StreamWriter sw = System.IO.File.AppendText(File))
            {
                string data = string.Empty;
                data = string.Format("{0} - {1}\n", DateTime.Now, Text);
                sw.WriteLine(data);
                
                //Closes stream
                sw.Close();
            }
        }
        
        public string GetPropertyString(string Key, string File)
        {
            try
            {
                Dictionary<string,string> data = new Dictionary<string, string>();
                foreach (string row in System.IO.File.ReadAllLines(File))
                {
                    data.Add(row.Split('=')[0], string.Join("=", row.Split('=').Skip(1).ToArray()));
                }
                return data[Key].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static Dictionary<string, string> GetProperties(string path)
        {
            string fileData = "";
            using (StreamReader sr = new StreamReader(path))
            {
                fileData = sr.ReadToEnd().Replace("\r", "");

                //Closes stream
                sr.Close();
            }
            Dictionary<string, string> Properties = new Dictionary<string, string>();
            string[] kvp;
            string[] records = fileData.Split("\n".ToCharArray());
            foreach (string record in records)
            {
                kvp = record.Split("=".ToCharArray());
                Properties.Add(kvp[0], kvp[1]);
            }
            return Properties;
        }
    }
    public class FileConfig
    {
        public static string GetScriptFromFile(string key, string file)
        {
            string _file = System.IO.File.ReadAllText(file);
            String pattern = String.Format("(?<=-{0}=)[^;\n]*", key);
            return Regex.Match(_file, pattern).Value;
        }
        public static string GetValue(string key, string file)
        {
            string[] lines = System.IO.File.ReadAllLines(file);
            string result = null;
            foreach (string currentLine in lines)
            {
                if (currentLine.StartsWith(key))
                {
                    result = currentLine.Replace(key, "");
                    result = result.Replace("\"", "");
                    break;
                }
            }
            return result;
        }
        public static void WriteValue(string key, string value, string file)
        {
            string getext = file.Substring(file.LastIndexOf('.'));
            string tmp = file.Replace(getext, ".tmp");
            using (var sr = new StreamReader(file))
            using (var wr = new StreamWriter(tmp))
            {
                bool bExistsKey = false;
                string line = string.Empty;
                while (null != (line = sr.ReadLine()))
                {

                    if (line.StartsWith(key))
                    {
                        line = String.Format("{0} \"{1}\"", key, value);
                        bExistsKey = true;
                    }
                    wr.WriteLine(line);

                }
                if (!bExistsKey) wr.WriteLine(String.Format("{0} \"{1}\"", key, value));
                sr.Close();
                wr.Close();
            }
            File.Delete(file);
            File.Move(tmp, file);
        }
    }
    public class DirectoryUsage
    {
        public static void CopyAllFilesFromDirectory(string SourceDir, string TargetDir)
        {
            System.IO.Directory.CreateDirectory(TargetDir);

            foreach (var File in Directory.GetFiles(SourceDir))
                System.IO.File.Copy(File, Path.Combine(TargetDir, Path.GetFileName(File)));
            foreach (var directory in Directory.GetDirectories(SourceDir))
                CopyAllFilesFromDirectory(directory, Path.Combine(TargetDir, Path.GetFileName(directory)));
        }
    }
}
