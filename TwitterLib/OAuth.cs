using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace TwitterLib
{
    internal delegate string StringEncodeHandler(string value);
    internal static class OAuth
    {
        static readonly char[] urlQuerySplitter = new char[] { '?', '&' };
        static readonly char[] urlQueryKeyValueSplitter = new char[] { '=' };

        #region ParameterName
        const string headerName = "Authorization";
        const string paramName_consumerKey = "oauth_consumer_key";
        const string paramName_nonce = "oauth_nonce";
        const string paramName_signature = "oauth_signature";
        const string paramName_signatureMethod = "oauth_signature_method";
        const string paramValue_signatureMethod = "HMAC-SHA1";
        const string paramName_timestamp = "oauth_timestamp";
        const string paramName_token = "oauth_token";
        const string paramName_version = "oauth_version";
        const string paramValue_version = "1.0";
        static readonly DateTime timeStampBase = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        static readonly string headerFormat;
        #endregion

        static OAuth()
        {
            headerFormat = "OAuth " + paramName_consumerKey + "=\"{0}\", "
                + paramName_nonce + "=\"{1}\", "
                + paramName_signature + "=\"{2}\", "
                + paramName_signatureMethod + "=\"" + paramValue_signatureMethod + "\", "
                + paramName_timestamp + "=\"{3}\", "
                + paramName_token + "=\"{4}\", "
                + paramName_version + "=\"" + paramValue_version + "\"";
        }

        private static string CreateNonce()
        {
            byte[] nonceBuffer = new byte[32];
            Random rand = new Random();
            for (int i = 0; i < nonceBuffer.Length; i++)
            {
                nonceBuffer[i] = (byte)rand.Next(0, 256);
            }
            return Convert.ToBase64String(nonceBuffer);
        }

        private static string CreateSignature(string method, string url, string consumerSecret, string accessTokenSecret, SortedDictionary<string, string> dictionary, StringEncodeHandler urlEncode)
        {
            Uri uri = new Uri(url);
            string baseString = method + "&" + urlEncode(uri.Query.Length > 0 ? url.Replace(uri.Query, "") : url) + "&";
            string paramString = "";
            foreach (string key in dictionary.Keys)
            {
                if (paramString.Length > 0)
                    paramString += "&";
                paramString += key + "=" + urlEncode(dictionary[key]);
            }
            baseString += urlEncode(paramString);
            byte[] baseByte = Encoding.ASCII.GetBytes(baseString);
            string hashKey = consumerSecret + "&" + accessTokenSecret;
            HMACSHA1 sha1 = new HMACSHA1(Encoding.ASCII.GetBytes(hashKey));
            byte[] hash = sha1.ComputeHash(baseByte);
            return urlEncode(Convert.ToBase64String(hash));
        }
        /// <summary>
        /// OAuth認証用のHttpWebRequestを生成します。
        /// </summary>
        /// <param name="httpMethod">HTTPリクエストメソッド(GET/POST)</param>
        /// <param name="url">リクエストURL</param>
        /// <param name="consumerKey">API提供元から提供されたConsumer Key</param>
        /// <param name="consumerSecret">API提供元から提供されたConsumer Secret</param>
        /// <param name="accessToken">API提供元から提供されたAccess Token</param>
        /// <param name="accessTokenSecret">API提供元から提供されたAccess Token Secret</param>
        /// <param name="bodyArgs">リクエストボディーに書き込むパラメーター</param>
        /// <param name="urlEncode">URLエンコードメソッド</param>
        /// <returns></returns>
        internal static HttpWebRequest CreateOAuthRequest(string httpMethod, string url, string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, SortedDictionary<string, string> bodyArgs, StringEncodeHandler urlEncode)
        {
            string nonce = CreateNonce();
            SortedDictionary<string, string> signatureArguments = new SortedDictionary<string, string>();
            TimeSpan span = DateTime.UtcNow - timeStampBase;
            int timestamp = (int)span.TotalSeconds;
            httpMethod = httpMethod.ToUpper();
            #region BodyArgs
            if (bodyArgs != null)
            {
                foreach (string key in bodyArgs.Keys)
                {
                    signatureArguments[key] = bodyArgs[key];
                }
            }
            #endregion
            #region OAuthArguments
            signatureArguments[paramName_consumerKey] = consumerKey;
            signatureArguments[paramName_nonce] = nonce;
            signatureArguments[paramName_signatureMethod] = paramValue_signatureMethod;
            signatureArguments[paramName_timestamp] = timestamp.ToString();
            signatureArguments[paramName_token] = accessToken;
            signatureArguments[paramName_version] = paramValue_version;
            #endregion
            #region URLArguments
            Uri targetUri = new Uri(url);
            if (!string.IsNullOrEmpty(targetUri.Query))
            {
                string[] urlArgs = targetUri.Query.Split(urlQuerySplitter, StringSplitOptions.RemoveEmptyEntries);
                foreach (string urlArg in urlArgs)
                {
                    string[] pair = urlArg.Split(urlQueryKeyValueSplitter, 2, StringSplitOptions.RemoveEmptyEntries);
                    signatureArguments[pair[0]] = pair[1];
                }
            }
            #endregion
            string signature = CreateSignature(httpMethod, url, consumerSecret, accessTokenSecret, signatureArguments, urlEncode);
            nonce = urlEncode(nonce);
            string authorizationValue = string.Format(headerFormat, consumerKey, nonce, signature, timestamp, accessToken);
            #region GET Query
            if (httpMethod == "GET" && bodyArgs != null && bodyArgs.Keys.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string key in bodyArgs.Keys)
                {
                    builder.Append(builder.Length == 0 ? "?" : "&");
                    builder.Append(key);
                    builder.Append("=");
                    builder.Append(bodyArgs[key]);
                }
                url += builder.ToString();
            }
            #endregion
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = httpMethod;
            request.Headers.Add(headerName, authorizationValue);
            request.Accept = "*/*";
            request.ContentType = "application/x-www-form-urlencoded";
            #region POST Body
            if (httpMethod == "POST" && bodyArgs != null && bodyArgs.Keys.Count > 0)
            {
                using (Stream stream = request.GetRequestStream())
                {
                    string writeContent = "";
                    foreach (string key in bodyArgs.Keys)
                    {
                        if (writeContent.Length > 0)
                            writeContent += "&";
                        writeContent += key + "=" + urlEncode(bodyArgs[key]);
                    }
                    byte[] buffer = Encoding.UTF8.GetBytes(writeContent);
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            #endregion
            return request;
        }
    }
}
