using System.Runtime.Serialization;
using TwitterLib.StreamingEvents;
using System.Net;
using System;

namespace TwitterLib
{
    /// <summary>
    /// ストリーミングメッセージの内容を判別する為の汎用デシリアライザです。
    /// </summary>
    [DataContract]
    internal class StreamingContract
    {
        [DataMember(IsRequired = false, Name = "delete")]
        public TweetDeleteInfo Delete { get; private set; }

        [DataMember(IsRequired = false, Name = "scrub_geo")]
        public ScrubGeoInfo ScrubGeo { get; private set; }

        [DataMember(IsRequired = false, Name = "limit")]
        public SpeedLimitInfo Limit { get; private set; }

        [DataMember(IsRequired = false, Name = "status_withheld")]
        public StatusWithheldInfo StatusWithheld { get; private set; }

        [DataMember(IsRequired = false, Name = "user_withheld")]
        public UserWithheldInfo UserWithheld { get; private set; }

        [DataMember(IsRequired = false, Name = "disconnect")]
        public DisconnectionInfo Disconnection { get; private set; }

        [DataMember(IsRequired = false, Name = "warning")]
        public WarningInfo Warning { get; private set; }

        [DataMember(IsRequired = false, Name = "events")]
        public string EventName { get; private set; }

        public void SetParent(Twitter parent)
        {
            if (Delete != null)
                Delete.Parent = parent;
            if (ScrubGeo != null)
                ScrubGeo.Parent = parent;
            if (Limit != null)
                Limit.Parent = parent;
            if (StatusWithheld != null)
                StatusWithheld.Parent = parent;
            if (UserWithheld != null)
                UserWithheld.Parent = parent;
            if (Disconnection != null)
                Disconnection.Parent = parent;
            if (Warning != null)
                Warning.Parent = parent;
        }
    }
    /// <summary>
    /// Twitter Streaming APIの応答イベントハンドラです。
    /// </summary>
    /// <param name="message">応答メッセージ</param>
    public delegate void StreamingApiEventHandler(StreamingMessage message);
}
