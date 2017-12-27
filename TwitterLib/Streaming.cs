using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using TwitterLib.StreamingEvents;
using System.Runtime.Serialization.Json;

namespace TwitterLib
{
    public partial class Twitter
    {
        static readonly DataContractJsonSerializer streamingPrimary = new DataContractJsonSerializer(typeof(StreamingContract));
        static readonly DataContractJsonSerializer streamingNoTargetEvent = new DataContractJsonSerializer(typeof(EventInfo));
        static readonly DataContractJsonSerializer streamingTweetTargetEvent = new DataContractJsonSerializer(typeof(TweetEventInfo));
        static readonly DataContractJsonSerializer streamingListTargetEvent = new DataContractJsonSerializer(typeof(ListEventInfo));
        static readonly DataContractJsonSerializer streamingTweet = new DataContractJsonSerializer(typeof(Tweet));
        StreamingApiEventHandler streamingCallback;
        Action streamingEndCallback;
        HttpWebRequest streamingRequest;
        /// <summary>
        /// ストリーミングデータを受信した際に発生するイベントです。
        /// </summary>
        public event StreamingApiEventHandler ReceivedStreamingData
        {
            add { streamingCallback += value; }
            remove { streamingCallback -= value; }
        }
        /// <summary>
        /// ストリーミング通信の終了処理が完了した際に発生するイベントです。
        /// </summary>
        public event Action StreamingDisconnected
        {
            add { streamingEndCallback += value; }
            remove { streamingEndCallback -= value; }
        }
        /// <summary>
        /// ユーザーストリームの読み込みを開始します。
        /// </summary>
        /// <param name="option">開始オプション</param>
        public void StartUserStream(StreamingStartArguments option)
        {
            lock (this)
            {
                SortedDictionary<string, string> args = option.CreateArgument();
                HttpWebRequest req = OAuth.CreateOAuthRequest("GET", "https://userstream.twitter.com/1.1/user.json", ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret, args, UrlEncode);
                if (streamingRequest != null)
                    streamingRequest.Abort();
                streamingRequest = req;
                req.BeginGetResponse(StreamingReceiveCallback, req);
            }
        }
        /// <summary>
        /// フィルターストリームの読み込みを開始します。
        /// </summary>
        /// <param name="option"></param>
        public void StartFilterStream(StreamingStartArguments option)
        {
            lock (this)
            {
                SortedDictionary<string, string> args = option.CreateArgument();
                HttpWebRequest req = OAuth.CreateOAuthRequest("POST", "https://stream.twitter.com/1.1/statuses/filter.json", ConsumerKey, ConsumerSecret, AccessToken, AccessTokenSecret, args, UrlEncode);
                if (streamingRequest != null)
                    streamingRequest.Abort();
                streamingRequest = req;
                req.BeginGetResponse(StreamingReceiveCallback, req);
            }
        }
        /// <summary>
        /// ストリーミングを終了します。
        /// </summary>
        public void AbortStream()
        {
            lock (this)
            {
                if (streamingRequest != null)
                {
                    streamingRequest.Abort();
                    streamingRequest = null;
                }
            }
        }
        /// <summary>
        /// ストリーミングAPIが実行中であるかどうかを示す値を取得します。
        /// </summary>
        public bool IsReceivingStream => streamingRequest != null;

        private void StreamingReceiveCallback(IAsyncResult ar)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)ar.AsyncState;
                if (streamingRequest != req)
                {
                    req.Abort();
                    return;
                }
                using (HttpWebResponse res = (HttpWebResponse)req.EndGetResponse(ar))
                using (StreamReader reader = new StreamReader(res.GetResponseStream()))
                {
                    string read;
                    while ((read = reader.ReadLine()) != null)
                    {
                        if (read.Length == 0)
                        {
                            streamingCallback(new KeepAlive() { Parent = this });
                            continue;
                        }
                        using (MemoryStream ms = new MemoryStream())
                        using (StreamWriter writer = new StreamWriter(ms))
                        {
                            writer.Write(read);
                            ms.Seek(0, SeekOrigin.Begin);
                            #region Messages
                            StreamingContract contract = (StreamingContract)streamingPrimary.ReadObject(ms);
                            contract.SetParent(this);
                            if (contract.Delete != null)
                            {
                                streamingCallback(contract.Delete);
                                continue;
                            }
                            if (contract.Disconnection != null)
                            {
                                streamingCallback(contract.Disconnection);
                                continue;
                            }
                            if (contract.Limit != null)
                            {
                                streamingCallback(contract.Limit);
                                continue;
                            }
                            if (contract.ScrubGeo != null)
                            {
                                streamingCallback(contract.ScrubGeo);
                                continue;
                            }
                            if (contract.StatusWithheld != null)
                            {
                                streamingCallback(contract.StatusWithheld);
                                continue;
                            }
                            if (contract.UserWithheld != null)
                            {
                                streamingCallback(contract.UserWithheld);
                                continue;
                            }
                            if (contract.Warning != null)
                            {
                                streamingCallback(contract.Warning);
                                continue;
                            }
                            #endregion
                            #region Events
                            if (contract.EventName != null)
                            {
                                DataContractJsonSerializer serializer = streamingNoTargetEvent;
                                switch (contract.EventName)
                                {
                                    case "favorite":
                                        serializer = streamingTweetTargetEvent;
                                        break;
                                    case "unfavorite":
                                        serializer = streamingTweetTargetEvent;
                                        break;
                                    case "list_created":
                                        serializer = streamingListTargetEvent;
                                        break;
                                    case "list_destroyed":
                                        serializer = streamingListTargetEvent;
                                        break;
                                    case "list_updated":
                                        serializer = streamingListTargetEvent;
                                        break;
                                    case "list_member_added":
                                        serializer = streamingListTargetEvent;
                                        break;
                                    case "list_member_removed":
                                        serializer = streamingListTargetEvent;
                                        break;
                                    case "list_user_subscribed":
                                        serializer = streamingListTargetEvent;
                                        break;
                                    case "list_user_unsubscribed":
                                        serializer = streamingListTargetEvent;
                                        break;
                                    case "quoted_tweet":
                                        serializer = streamingTweetTargetEvent;
                                        break;
                                }
                                EventInfo eRead = (EventInfo)serializer.ReadObject(ms);
                                eRead.Parent = this;
                                streamingCallback(eRead);
                                continue;
                            }
                            #endregion
                            #region Tweet
                            Tweet tweet = (Tweet)streamingTweet.ReadObject(ms);
                            tweet.Parent = this;
                            streamingCallback(tweet);
                            #endregion
                            #region Unknown
                            streamingCallback(new UnknownMessage(this, read));
                            #endregion
                        }
                    }
                }
            }
            catch (WebException wex)
            {
                if (wex.Status == WebExceptionStatus.RequestCanceled)
                    return;
                throw new TwitterException(wex);
            }
            finally
            {
                streamingRequest = null;
                streamingEndCallback();
            }
        }
    }
}
