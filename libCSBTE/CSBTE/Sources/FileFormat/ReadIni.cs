using System;
using System.Text;
using System.Runtime.InteropServices;


namespace CSBTE.FileFormat
{
    public class ReadIni
    {
         string path;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
                 string key, string def, StringBuilder retVal,
            int size, string filePath);

        /// <param name="FilePath">Filename.</param>
        public ReadIni(string FilePath)
        {
            path = FilePath;
            if (!System.IO.File.Exists(path)) throw new Exception(string.Format("File not found: {0}", path));
        }
        /// <summary>
        /// Writes the value in an ini file parameters, saving on Section / Key.
        /// </summary>
        /// <param name="Section">Section name</param>
        /// <param name="Key">Key within the section.</param>
        /// <param name="Value">Value to be inserted.</param>
        public void WriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }
        /// <summary>
        /// Gets a value within a section / key.
        /// </summary>
        /// <param name="Section">Section name.</param>
        /// <param name="Key">Key within the section.</param>
        /// <returns>returns a string.</returns>
        public string ReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp,
                                            255, this.path);
            return temp.ToString();

        }
    }
}
