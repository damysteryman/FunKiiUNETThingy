using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.IO;

namespace FunKiiUNETThingy
{
    public static class Utils
    {
        /// <summary>
        /// Method that gets a JSON text as string and turns it into a dynamic object
        /// </summary>
        /// <param name="jsonString">The actual JSON formatted text</param>
        /// <returns>dynamic object with data from JSON</returns>
        public static dynamic GetJsonObject(string jsonString)
        {
            dynamic json = JsonConvert.DeserializeObject<dynamic>(jsonString);
            return json;
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static byte[] GetByteArrayFromHexString(string hexString)
        {
            SoapHexBinary shb = SoapHexBinary.Parse(hexString);
            return shb.Value;
        }

        public static UInt16 ToUInt16(this byte[] byteArray)
        {
            return BitConverter.ToUInt16(byteArray.FixEndianness(), 0);
        }

        public static UInt32 ToUInt32(this byte[] byteArray)
        {
            return BitConverter.ToUInt32(byteArray.FixEndianness(), 0);
        }

        public static UInt64 ToUInt64(this byte[] byteArray)
        {
            return BitConverter.ToUInt64(byteArray.FixEndianness(), 0);
        }

        public static byte[] FixEndianness(this byte[] byteArray)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(byteArray);

            return byteArray;
        }

        public static string SanitizeFileName(this string fileName)
        {
            char[] badChars = System.IO.Path.GetInvalidFileNameChars();

            for (int i = 0; i < badChars.Length; i++)
                fileName = fileName.Replace(badChars[i], '_');
            
            return fileName;
        }


        public static string GetByteSuffix(int power, bool IEC)
        {
            string baseStr = "B";
            if (IEC)
                baseStr = "iB";

            switch (power)
            {
                case (0):
                default:
                    return "B";

                case (1):
                    return "K" + baseStr;

                case (2):
                    return "M" + baseStr;

                case (3):
                    return "G" + baseStr;

                case (4):
                    return "T" + baseStr;
            }
        }

        public static string ConvertByteToText(this double byteNum, bool IEC = false)
        {
            string suffix = "B";

            int baseNum = 1000;
            if (IEC)
                baseNum = 1024;

            for (int i = 3; i > 0; i--)
            {
                if (byteNum.CompareTo(Math.Pow(baseNum, i)) == 1)
                {
                    byteNum = byteNum / Math.Pow(baseNum, i);
                    return byteNum.ToString("N2") + " " + GetByteSuffix(i, IEC);
                }
            }
            return byteNum.ToString() + " " + suffix;
        }

        //public static string ConvertByteToText2(this double byteNum)
        //{
        //    string suffix = "B";
        //    for (int i = 3; i > 0; i--)
        //    {
        //        if (byteNum.CompareTo(Math.Pow(1000, i)) == 1)
        //        {
        //            byteNum = byteNum / Math.Pow(1000, i);
        //            return byteNum.ToString("N2") + " " + GetByteSuffix(i);
        //        }
        //    }
        //    return byteNum.ToString() + " " + suffix;
        //}

        public static long GetFileLength(this string filePath)
        {
            FileInfo fi = new FileInfo(filePath);

            return fi.Length;
        }
    }
}
