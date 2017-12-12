using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// 配信されなかったツイートが存在する事を示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class SpeedLimitInfo : StreamingMessage
    {
        /// <summary>
        /// このプロパティは常に列挙子：StreamingMessageType.Limitを返します。
        /// </summary>
        public override StreamingMessageType MessageType => StreamingMessageType.Limit;
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 接続開始から現在までに配信されなかったツイートの数を取得します。
        /// </summary>
        [DataMember(Name = "track")]
        public int Track { get; private set; }
    }
}
