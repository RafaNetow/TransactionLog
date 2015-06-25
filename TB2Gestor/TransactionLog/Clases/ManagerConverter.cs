using System;
using System.Globalization;
using System.Text;

namespace TransactionLog.Clases
{
    public class ManagerConverter
    {
        public string ByteArrayToString(byte[] buffer)
        {
            StringBuilder hex = new StringBuilder(buffer.Length * 2);
            foreach (byte b in buffer)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public string InvertHexadecimal(string hex)
        {
            string convertedHex = "";
            int i = hex.Length;
            while (i > 0)
            {
                convertedHex = convertedHex + hex[i - 2] + hex[i - 1];
                i = i - 2;
            }

            return convertedHex;
        }

        public UInt32 HexToInt(string hexString)
        {
            uint intVal = UInt32.Parse(hexString, NumberStyles.AllowHexSpecifier);
            return intVal;
        }

        public Char HexToChar(string hexString)
        {
            int num = int.Parse(hexString, NumberStyles.AllowHexSpecifier);
            Char charVal = (Char)num;
            return charVal;
        }

        public Double HexToFloat(string hexString)
        {
            double result = 0.0;
            foreach (char c in hexString)
            {
                double val = (double)Convert.ToInt32(c.ToString(), 16);
                result = result * 16.0 + val;
            }
            return result;
        }

        public UInt64 HexToBigInt(string hexString) 
        {
            var bigIntVal = UInt64.Parse(hexString, NumberStyles.AllowHexSpecifier);
            return bigIntVal;
        }

        public Byte HexToTinyInt(string hexString) 
        {
            var tinyIntVal = Byte.Parse(hexString, NumberStyles.AllowHexSpecifier);
            return tinyIntVal;
        }

        public Decimal HexToDecimal(string hexString)
        {
            var decimalVal = long.Parse(hexString, NumberStyles.AllowHexSpecifier);
            return Convert.ToDecimal(decimalVal);
        }

        public string HexToMoney(string hexString)//8
        {
            var moneyVal = Int64.Parse(hexString, NumberStyles.AllowHexSpecifier);
            var convertToMoney = Convert.ToDouble(moneyVal / 10000);
            string convert = convertToMoney.ToString();
            string partInt = convert.Substring(0, convert.Length - 2);
            string partDecimal = convert.Substring(convert.Length - 2, 2);
            return partInt + "." + partDecimal;
        }

        public string HexToVarChar(string hexString)
        {
            return hexString;
        }

        public DateTime HexToDateTime(string hexString)
        {


            long decValue = long.Parse(hexString, NumberStyles.HexNumber);
            DateTime dt = new DateTime(decValue);
            return dt;

           

            //return theActualDate;
        }

        public DateTime HexToSmallDateTime(string hexString)//4
        {
           


            long decValue = long.Parse(hexString, NumberStyles.HexNumber);
            DateTime dt = new DateTime(decValue);
            return dt;
        }

        public Single HexToReal(string hexString) //4
        {
            byte[] raw = new byte[hexString.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[raw.Length - i - 1] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            float f = BitConverter.ToSingle(raw, 0);
            return f;
        }

        public Boolean HexToBit(string hexString)
        {
            int convert = Int32.Parse(hexString, NumberStyles.HexNumber);
            if (convert == 1)
                return true;
            return false;
        } 
    }
}