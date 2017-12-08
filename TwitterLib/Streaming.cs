using System.Runtime.Serialization;
using TwitterLib.StreamingEvents;

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
        public DisconnectionInfo disconnection { get; private set; }

        [DataMember(IsRequired = false, Name = "warning")]
        public WarningInfo warning { get; private set; }

        [DataMember(IsRequired = false, Name = "events")]
        public string EventName { get; private set; }
    }
}
