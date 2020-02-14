using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryOwl.Text
{
	public class String
	{
        public enum Content
        {
            Random = 0,
            Numbers,
            Letters
        }
        public enum Casing
        {
            Random = 0,
            LowLetters,
            UppLetters
        }
        //Generate a random string
        public static string GenerateString(int length, Content content, Casing casing)
        {
            //For Generating a random
            Random r = new Random();
            Random r1 = new Random();
            //Random r2 = null;

            //string Generated
            string gString = string.Empty;

            string LowAlph = "abcdefghijklmnopqrstuvwxyz";
            string UppAlph = LowAlph.ToUpper();

            string AddLetter = null;


            while (!(gString.Length == length))
            {
                switch (casing)
                {
                    case Casing.Random:
                        switch (r.Next(0, 2))
                        {
                            case 0:
                                AddLetter = LowAlph.Substring(r1.Next(0, 25), 1);
                                break;
                            case 1:
                                AddLetter = UppAlph.Substring(r1.Next(0, 25), 1);
                                break;
                        }
                        break;
                    case Casing.UppLetters:
                        AddLetter = UppAlph.Substring(r1.Next(0, 25), 1);
                        break;
                    case Casing.LowLetters:
                        AddLetter = LowAlph.Substring(r1.Next(0, 25), 1);
                        break;
                }
                switch (content)
                {
                    case Content.Random:
                        switch (r.Next(0, 2))
                        {
                            case 0:
                                gString += AddLetter;
                                break;
                            case 1:
                                gString += r1.Next(0, 9);

                                break;
                        }
                        break;
                    case Content.Numbers:
                        gString += r1.Next(0, 9);
                        break;
                    case Content.Letters:
                        gString += AddLetter;
                        break;
                }
            }
            return gString;
        }
        public static byte[] StringToByte(string str)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(str);
        }
        //Get ASCII Char
        public static char Chr(int cod)
        {
            return (char)cod;
        }
        //Get ASCII Code
        public static int ASCII(string str)
        {
            return (int)(Convert.ToChar(str));
        }
        public static string UppercaseFirst(string str)
        {
            if (string.IsNullOrEmpty(str)) return string.Empty;
            char[] a = str.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
	}
}
