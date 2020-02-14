using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.ComponentModel;
using System.Drawing;
namespace LibraryOwl.Network
{
	class Web
	{
        //This Will send a package to google server and checks if is online
        public static bool CheckConnection()
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
        //Converts a web image to local stream image
        public static Image GetImageWeb(string Url)
        {
            WebClient wc = new WebClient();
            byte[] imgbytes = wc.DownloadData(Url);
            System.IO.MemoryStream imgstream = new System.IO.MemoryStream(imgbytes);
            imgstream.Close();
            return Bitmap.FromStream(imgstream);
            
        }
	}
}
