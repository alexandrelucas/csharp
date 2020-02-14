using System;
using System.Text;
using System.Security.Cryptography;
using CSBTE;


namespace CSBTE
{
    public class Cryptography
    {
        private static TripleDESCryptoServiceProvider TripleDES = new TripleDESCryptoServiceProvider();
        private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
        private static UTF8Encoding utf8 = new UTF8Encoding();

        //Encryption key
        private const string key = "c0rujINhA";
        /// <summary>
        /// Calculates the MD5 Hash
        /// </summary>
        /// <param name="value">Key</param>
        public static byte[] MD5Hash(string value)
        {
            //Converts the key to a byte array
            byte[] byteArray = ASCIIEncoding.UTF8.GetBytes(value);
            return MD5.ComputeHash(byteArray);
        }
        /// <summary>
        /// Encrypts a string based on a key
        /// </summary>
        /// <param name="StringToEncrypt">String to encrypt</param>
        public string Encrypt(string StringToEncrypt)
        {
            try
            {
                // Set the key and cipher (which in this case is Electronic
                // Codebook, or individual for each block encryption) 
                TripleDES.Key = Cryptography.MD5Hash(key);
                TripleDES.Mode = CipherMode.ECB;
                //Converts the String to bytes and encrypts
                byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(StringToEncrypt);
                return Convert.ToBase64String(TripleDES.CreateEncryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));
            }
            catch (Exception ex)
            {
                return String.Empty;
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Decrypts a string based on a key 
        /// </summary>
        /// <param name="encryptedString">String to decrypt</param>
        /// <returns></returns>
        public string Decrypt(string encryptedString)
        {
            try
            {
                // Definition of the key and cipher

                if (encryptedString == string.Empty)
                    return string.Empty;
                TripleDES.Key = Cryptography.MD5Hash(key);
                TripleDES.Mode = CipherMode.ECB;

                // Converts the encrypted string to bytes and decrypts 
                byte[] Buffer = Convert.FromBase64String(encryptedString);
                return ASCIIEncoding.ASCII.GetString(TripleDES.CreateDecryptor().TransformFinalBlock(Buffer, 0, Buffer.Length));


            }
            catch (Exception ex)
            {
                return string.Empty;
                throw new Exception(ex.Message);

            }
        }
        /// <summary>
        /// Calculates the MD5 Hashcode of a File
        /// </summary>
        /// <param name="PathName"></param>
        /// <returns></returns>
        public static string GetMD5FromFile(string PathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbyteHashValue;
            System.IO.FileStream oFileStream = null;

            try
            {
                oFileStream = System.IO.File.Open(PathName, System.IO.FileMode.Open);
                arrbyteHashValue = MD5.ComputeHash(oFileStream);
                oFileStream.Close();

                strHashData = System.BitConverter.ToString(arrbyteHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex) { return null; throw new Exception(ex.Message); }
            return (strResult);
        }
        /// <summary>
        ///  generates a SHA1 hash of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GenerateSHA1Hash(string str)
        {
            SHA1 hasher = SHA1.Create();
            StringBuilder gerarString = new StringBuilder();
            byte[] array = StringUtil.StringToByte(str);
            array = hasher.ComputeHash(array);

            foreach (byte item in array)
            {
                gerarString.Append(item.ToString("x2"));
            }
            return gerarString.ToString().ToLower();
        }

    }
}
