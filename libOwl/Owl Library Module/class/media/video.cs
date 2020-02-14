using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOwl.Media
{
	public class PlayVideo
	{
        [System.Runtime.InteropServices.DllImport("winmm.dll")]
        static extern Int32 mciSendString(string command, StringBuilder buffer, int bufferSize, IntPtr hwndCallback);
        //Vars
        string _path;
        IntPtr _Handle;

        public PlayVideo(string FilePath, IntPtr Handle)
        {
            _path = FilePath;
            _Handle = Handle;
            mciSendString(string.Format("open \"{0}\" Type mpegvideo alias MyVideo1", FilePath), null, 0, IntPtr.Zero);
            mciSendString(string.Format("window MyVideo1 handle {0}", _Handle.ToString()), null, 0, IntPtr.Zero);
        }

        public void Play()
        {
            mciSendString("seek MyVideo1 to 0", null, 0, IntPtr.Zero);
            mciSendString("play MyVideo1", null, 0, IntPtr.Zero);
        }

        public void Pause()
        {
            mciSendString("pause MyVideo1", null, 0, IntPtr.Zero);
        }
        public void Close()
        {
            mciSendString("close MyVideo1", null, 0, IntPtr.Zero);
        }
        public void Stop()
        {
            mciSendString("stop MyVideo1", null, 0, IntPtr.Zero);    
        }
        public StringBuilder Length()
        {
            StringBuilder mssg = new StringBuilder(255);
            int i = mciSendString("set MyVideo1 time format ms", null, 0, IntPtr.Zero);
            int j = mciSendString("status MyVideo1 length", mssg, mssg.Capacity, IntPtr.Zero);
            return mssg;
        }
	}
}
