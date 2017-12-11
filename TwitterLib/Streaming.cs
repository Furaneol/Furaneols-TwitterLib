using System;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace TwitterLib
{
    public partial class Twitter
    {
        List<StreamingControl> streamings;
        StreamingApiEventHandler streamingCallback;
        /// <summary>
        /// ストリーミングデータを受信した際に発生するイベントです。
        /// </summary>
        public event StreamingApiEventHandler ReceivedStreamingData
        {
            add { streamingCallback += value; }
            remove { streamingCallback -= value; }
        }

        public void StartUserStream()
        {

        }
    }
    /// <summary>
    /// Streaming APIにおけるデータの開始、受信および終了を制御するオブジェクトです。
    /// </summary>
    internal class StreamingControl
    {
        bool used, disposed;
        HttpWebRequest request;
        Action<string> readLine;
        /// <summary>
        /// 制御オブジェクトを作成します。
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="req"></param>
        public StreamingControl(Twitter parent, HttpWebRequest req)
        {
            request = req;
            used = false;
            disposed = false;
        }
        /// <summary>
        /// 制御オブジェクトのデストラクタです。
        /// </summary>
        ~StreamingControl()
        {
            request.Abort();
        }
        /// <summary>
        /// ストリーミング通信を開始します。
        /// </summary>
        public void Start()
        {
            if (used)
                throw new InvalidOperationException("Startメソッドを二度使用する事はできません。");
            request.BeginGetResponse(ProcessResponce, null);
            used = true;
        }
        /// <summary>
        /// 1行分のデータを受信した時に発生するイベントです。
        /// </summary>
        public event Action<string> ReadLine
        {
            add { readLine += value; }
            remove { readLine -= value; }
        }

        private void ProcessResponce(IAsyncResult ar)
        {
            try
            {
                using (HttpWebResponse res = (HttpWebResponse)request.EndGetResponse(ar))
                using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                {
                    string read;
                    while ((read = reader.ReadLine()) != null)
                    {
                        readLine(read);
                    }
                }
            }
            catch (WebException wex)
            {
                throw new TwitterException(wex);
            }
        }
    }
}
