using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic.Devices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
namespace LibraryOwl.FileStream
{
    public class iBytes
    {
       
        private ImageCodecInfo GetImageEncoder(string type)
        {

            foreach (ImageCodecInfo i in ImageCodecInfo.GetImageEncoders())
            {
                if (i.MimeType == type) return i;
            }
            return null;
        }
        //Save a Array Collection of multiples images in bitmap and saves in single file.
        public void SaveImage(List<Image> Images, string fileName)
        {
            EncoderParameters encparams = new EncoderParameters(1);
            encparams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
            Images[0].Save(fileName, GetImageEncoder("image/tiff"), encparams);
            for (int i = 1; i < Images.Count; i++)
            {
                encparams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
                Images[0].SaveAdd(Images[i], encparams);
            }
            encparams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
            Images[0].SaveAdd(encparams);
        }
        //Get Array collection from single file.
        public List<Image> GetImageFrames(string fileName)
        {
            Image img = Image.FromFile(fileName);
            List<Image> lst = new List<Image>();
            if (img.GetFrameCount(FrameDimension.Page) > 1)
            {
                for (int h = 0; h < img.GetFrameCount(FrameDimension.Page); h++)
                {
                    img.SelectActiveFrame(FrameDimension.Page, h);
                    Bitmap temp = new Bitmap(img.Width, img.Height);
                    Graphics gRead = Graphics.FromImage(temp);
                    gRead.InterpolationMode = InterpolationMode.NearestNeighbor;
                    gRead.DrawImageUnscaled(img, 0, 0);
                    gRead.Dispose();
                    lst.Add(temp);
                }

            }
            else
            {
                lst.Add(img);
            }
            return lst;
        }
        //Convert image to bytes (used by sql servers)
        public byte[] ConvertImageFileToBytes(string ImageFilePath)
        {
            byte[] _tempByte = null;

            if (string.IsNullOrEmpty(ImageFilePath)) throw new ArgumentNullException("Image File Name cannot be null or empty", "ImageFilePath");

            try
            {
                var _fileInfo = new System.IO.FileInfo(ImageFilePath);
                var _NumBytes = _fileInfo.Length;
                var _Fstream = new System.IO.FileStream(ImageFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                var _BinaryReader = new System.IO.BinaryReader(_Fstream);
                _tempByte = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes));
                _fileInfo = null;
                _Fstream.Close();
                _Fstream.Dispose();
                _BinaryReader.Close();

                return _tempByte;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public System.IO.MemoryStream ConvertBytesToMemoryStream(byte[] ImageData)
        {
            try
            {
                if (ImageData == null) throw new ArgumentException("Image Binary Data Cannot be Null or Empty", "ImageData");

                return new System.IO.MemoryStream(ImageData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public System.IO.MemoryStream ConvertImageFileToMemoryStream(string ImageFilePath)
        {
            if (string.IsNullOrEmpty(ImageFilePath)) throw new ArgumentNullException("Image File Name cannot be null or empty", "ImageFilePath");

            return ConvertBytesToMemoryStream(ConvertImageFileToBytes(ImageFilePath));
        }
    }
}
