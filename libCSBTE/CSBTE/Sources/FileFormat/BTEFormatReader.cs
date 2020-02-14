using System;
using System.IO;
using System.Collections.Generic;

namespace CSBTE.FileFormat
{
    public class BTEFormatReader
    {
        private string[] parms;
        private string filePath;
        private List<Line> lines = new List<Line>();
        public int Count { get { return lines.Count; } }

        //Constructor
        public BTEFormatReader(string file, string[] parms)
        {
            this.parms = parms;
            this.filePath = file;
            ReadFile();
        }

        private void ReadFile()
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                string strLine;
                string[] values = new string[4096];

                while ((line = sr.ReadLine()) != null)
                {
                    Line cururentLine = new Line();
                    if (line.StartsWith(";")) continue;
                    strLine = line;
                    strLine = line.Replace(Environment.NewLine, "");
                    for (int i = 0; i < parms.Length; i++)
                    {
                        if (i == 0)
                        {
                            strLine = strLine.Replace(parms[0], "");
                        }
                        strLine = strLine.Replace(parms[i], ",");
                    }
                    values = strLine.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        //Remove []
                        string currentParameter = parms[i].Replace("[",""); 
                        currentParameter = currentParameter.Replace("]", "");
                        //Add
                        cururentLine.AddParameter(currentParameter, values[i]);
                    }
                    lines.Add(cururentLine);
                }
            }
        }
        public Line this[int index]
        {
            get
            {
                return lines[index];
            }
        }
    }
    public class Line
    {
        private Dictionary<string, string> row = new Dictionary<string, string>();

        public string this[string key]
        {
            get
            {
                try
                {
                    return row[key].ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
        public void AddParameter(string parameter, string value)
        {
            row.Add(parameter, value);
        }
        public int ParameterCount
        {
            get
            {
                return row.Count;
            }
        }
        public void ClearAllParameters()
        {
            row.Clear();
        }
        public void RemoveParamter(string parameter)
        {
            row.Remove(parameter);
        }
    }
}