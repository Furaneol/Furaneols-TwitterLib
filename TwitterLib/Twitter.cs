using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;
using System.Globalization;
using System.Drawing;

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
        /// Twitterオリジナル形式の日付文字列を解析します。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static DateTime ParseDateTime(string value)
        {
            return DateTime.ParseExact(value.Insert(23, ":"), "ddd MMM dd HH:mm:ss zzz yyyy", CultureInfo.GetCultureInfo("en-us"));
        }
        /// <summary>
        /// 6文字の16進数文字列から色情報を読み込みます。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static Color ParseColor(string value)
        {
            int c = Convert.ToInt32("ff" + value, 16);
            return Color.FromArgb(c);
        }


        public Twitter()
        {
            AuthenticationMode = TwitterAuthenticationMode.None;
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
        /// <summary>
        /// 認証モードを取得または設定します。
        /// </summary>
        public TwitterAuthenticationMode AuthenticationMode { get; set; }

        private string CreateOAuth2Credential()
        {
            string baseString = UrlEncode(ConsumerKey) + ":" + UrlEncode(ConsumerSecret);
            byte[] buffer = Encoding.UTF8.GetBytes(baseString);
            return Convert.ToBase64String(buffer);
        }
        /// <summary>
        /// 設定されたConsumer KeyおよびConsumer Secretを使用してBearer Tokenを取得します。
        /// </summary>
        /// <exception cref="TwitterException"></exception>
        public void GetBearerToken()
        {
            #region リクエスト生成
            HttpWebRequest req = WebRequest.CreateHttp("https://api.twitter.com/oauth2/token");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            req.Headers.Add("Authorization", "Basic " + CreateOAuth2Credential());
            using (StreamWriter writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write("grant_type=client_credentials");
            }
            #endregion
            #region レスポンス解析
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BearerResponce));
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                {
                    BearerResponce bearer = (BearerResponce)serializer.ReadObject(res.GetResponseStream());
                    BearerToken = bearer.BearerToken;
                }
            }
            catch (WebException wex)
            {
                throw new TwitterException(wex);
            }
            #endregion
        }
        /// <summary>
        /// 使用していたBearer Tokenを無効化します。
        /// </summary>
        /// <exception cref="TwitterException"></exception>
        public void InvalidateBearerToken()
        {
            HttpWebRequest req = WebRequest.CreateHttp("https://api.twitter.com/oauth2/invalidate_token");
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.Headers.Add("Authorization", "Basic " + CreateOAuth2Credential());
            using (StreamWriter writer = new StreamWriter(req.GetRequestStream()))
            {
                writer.Write("access_token=" + BearerToken);
            }
            try
            {
                req.GetResponse();
                BearerToken = null;
            }
            catch (WebException wex)
            {
                throw new TwitterException(wex);
            }
        }
        /// <summary>
        /// ユーザー認証が必要なAPIの利用準備が出来ているかどうかを取得します。
        /// </summary>
        private bool AvailableUserAuthenticationOnlyAPI => !string.IsNullOrWhiteSpace(ConsumerKey) && !string.IsNullOrWhiteSpace(ConsumerSecret) && !string.IsNullOrWhiteSpace(AccessToken) && !string.IsNullOrWhiteSpace(AccessTokenSecret);
        /// <summary>
        /// Application-only Authorizationリクエストの利用準備が出来ているかどうかを取得します。
        /// </summary>
        private bool AvailableApplicationAuthenticationTokenRequest => !string.IsNullOrWhiteSpace(BearerToken);
        /// <summary>
        /// 応答ストリームを取得します。
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="args"></param>
        /// <param name="postResponceAction"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="TwitterException"></exception>
        /// <returns></returns>
        internal object GetOAuthResponce(string method, string url, SortedDictionary<string, string> args, DataContractJsonSerializer serializer)
        {
            HttpWebRequest req;
            if (AuthenticationMode.HasFlag(TwitterAuthenticationMode.UserAuthentication) && AvailableUserAuthenticationOnlyAPI)
            {
                req = OAuth.CreateOAuthRequest(method, url, ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret, args, UrlEncode);
            }
            else if (AuthenticationMode.HasFlag(TwitterAuthenticationMode.ApplicationOnlyAuthentication) && AvailableApplicationAuthenticationTokenRequest)
            {
                req = OAuth.CreateBearerRequest(method, url, BearerToken, args, UrlEncode);
            }
            else
            {
                throw new InvalidOperationException("認証情報が設定されていないか、AuthenticationModeプロパティの値が不適切です。");
            }
            try
            {
                using (HttpWebResponse res = (HttpWebResponse)req.GetResponse())
                using (Stream stream = res.GetResponseStream())
                {
                    return serializer.ReadObject(stream);
                }
            }
            catch (WebException wex)
            {
                throw new TwitterException(wex);
            }
        }
    }
}
