using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// 配信されなかったツイートが存在する事を示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class SpeedLimitInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.Limit;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 接続開始から現在までに配信されなかったツイートの数を取得します。
        /// </summary>
        [DataMember(Name = "track")]
        public int Track { get; private set; }
    }
}
