using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net;

namespace TwitterLib
{
    public partial class Twitter
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
        /// <summary>
        /// OAuth認証用のConsumer Keyを取得または設定します。
        /// </summary>
        public string ConsumerKey { get; set; }
        /// <summary>
        /// OAuth認証用のConsumer Secretを取得または設定します。
        /// </summary>
        public string ConsumerSecret { get; set; }
        /// <summary>
        /// OAuth認証用のAccess Tokenを取得または設定します。
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// OAuth認証用のAccess Token Secretを取得または設定します。
        /// </summary>
        public string AccessTokenSecret { get; set; }
        /// <summary>
        /// OAuth2認証用のBearer Tokenを取得または設定します。
        /// </summary>
        public string BearerToken { get; set; }


    }
}
