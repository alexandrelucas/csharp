using System;
using System.Net;
using System.Drawing;
using System.IO;

namespace CSBTE
{
   public class Functions
    {
       public enum GameModes
       {
           ORIGINAL =0,
           NONE = 0,
           TD = 1,
           DM = 2,
           ZB =3,
           ZBS = 4,
           ZBU = 5,
           HMS = 6,
           GHOST = 7,
           GD = 8,
           DR = 9,
           ZE = 10,
           ZB3 = 11,
           BASIC = 12

       }
       public void SetGameMode(string gameMode, string amxPath)
       {
           string[] addonsFiles = Directory.GetFiles(amxPath);
           try
           {
               foreach (string currentFile in addonsFiles)
               {
                   if (currentFile.Contains("plugins-") && !currentFile.Contains("plugins-" + gameMode))
                   {
                       string getEndOfFile = currentFile.Substring(currentFile.LastIndexOf("-") + 1);
                       RenameFile(currentFile, "disabled-" + getEndOfFile);

                   }
                   if(currentFile.Contains("disabled-" + gameMode))
                   {
                       RenameFile(currentFile,"plugins-" + gameMode + ".ini");
                   }
               }
           }
           catch(Exception ex)
           {
               throw new Exception(ex.Message);
           }
       }
       public static bool CheckInternetConnection()
       {
           WebRequest req = WebRequest.Create("http://www.google.com");
           WebResponse resp;
           try
           {
               resp = req.GetResponse();
               resp.Close();
               req = null;
               return true;
           }
           catch
           {
               req = null;
               return false;
           }
       }
       public static Image ImageFromWeb(string url)
       {
           WebClient wc = new WebClient();
           byte[] imgbytes = wc.DownloadData(url);
           MemoryStream imageStream = new MemoryStream(imgbytes);
           imageStream.Close();
           return Image.FromStream(imageStream);
       }
       public void RenameFile(string file, string rename)
       {
           string dir = file.Substring(0, file.LastIndexOf("\\") + 1);
           string newfile = dir + rename;
           File.Move(file, newfile);
       }
       
    }
}
