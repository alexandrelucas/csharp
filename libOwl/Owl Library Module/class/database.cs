using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
namespace LibraryOwl.FileStream
{
    public class iniDataReader
    {
        static List<string[]> parseCSV(string Path, string[] lineToReplace)
        {
            List<string[]> parsedData = new List<string[]>();
            using (StreamReader readFile = new StreamReader(Path))
            {
                string line;
                string[] row;
                while ((line = readFile.ReadLine()) != null)
                {
                    if (line.StartsWith(lineToReplace[0]) || line == "" ||  line.EndsWith(lineToReplace[0])) continue; //Select Array_Name[0] to Comment Character
                    line = line.Replace(Environment.NewLine, "");
                    line = line.Replace(",", "");
                    line = line.Replace(lineToReplace[1], ""); //Select Array_Name[1] to Index

                    for (int i = 2; i < lineToReplace.Length; i++)
                    {
                        line = line.Replace(lineToReplace[i], ",");
                    }

                    row = line.Split(',');
                    parsedData.Add(row);
                }
                readFile.Dispose();
                readFile.Close();
            }
            return parsedData;
        }
        public static void CallData(System.Windows.Forms.DataGridView DataGView, string[] LineToReplace, string FilePath)
        {
            List<string[]> DataParse = parseCSV(FilePath, LineToReplace);
            System.Data.DataTable newTable = new System.Data.DataTable();
            foreach (string column in DataParse[0])
            {
                newTable.Columns.Add();
            }
            foreach (string[] row in DataParse)
            {
                newTable.Rows.Add(row);

            }
            DataGView.DataSource = newTable;
        }
        public static void CallData(System.Windows.Forms.DataGridView DataGView, string[] LineToReplace,string FilePath,string[] ColumnsName)
        {
            List<string[]> DataParse = parseCSV(FilePath, LineToReplace);
            System.Data.DataTable newTable = new System.Data.DataTable();
            foreach (string column in DataParse[0])
            {
                newTable.Columns.Add();
            }
            foreach (string[] row in DataParse)
            {
                newTable.Rows.Add(row);

            }
            DataGView.DataSource = newTable;
            //Nominations for the columns
            for (int i = 0; i < ColumnsName.Length; i++)
            {
                DataGView.Columns[i].HeaderCell.Value = ColumnsName[i].ToString();

            }
        }

    }

}
