using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// ストリームが切断したことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class DisconnectionInfo : StreamingMessage
    {
        /// <summary>
        /// このプロパティは常に列挙子：StreamingMessageType.Disconnectを返します。
        /// </summary>
        public override StreamingMessageType MessageType => StreamingMessageType.Disconnect;
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// ステータスコードを取得します。
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; private set; }
        /// <summary>
        /// 切断されたストリームの名前を取得します。
        /// </summary>
        [DataMember(Name = "stream_name")]
        public string StreamName { get; private set; }
        /// <summary>
        /// 切断理由を説明する文字列を取得します。
        /// </summary>
        [DataMember(Name = "reason")]
        public string Reason { get; private set; }

    }
}
