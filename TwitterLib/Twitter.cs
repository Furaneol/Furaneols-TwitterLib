using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net;

namespace TwitterLib
{
    public class Twitter
    {
        const string acceptString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-._~";
        /// <summary>
        /// Twitter用のURLエンコードメソッドです。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string UrlEncode(string value)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < value.Length; i++)
            {
                bool isSurrogate = i < value.Length - 1 && Char.IsSurrogatePair(value[i], value[i + 1]);
                string s = value.Substring(i, isSurrogate ? 2 : 1);
                if (s.Length == 1 && acceptString.IndexOf(s) >= 0)
                {
                    builder.Append(s);
                }
                else
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(s);
                    foreach (byte data in buffer)
                    {
                        builder.Append("%" + data.ToString("X2"));
                    }
                }
                if (isSurrogate)
                    i++;
            }
            return builder.ToString();
        }

    }
}
