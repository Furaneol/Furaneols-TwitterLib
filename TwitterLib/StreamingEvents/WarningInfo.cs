using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// ストリームから警告を受けていることを示すオブジェクトです。
    /// </summary>
    [DataContract]
    public class WarningInfo : StreamingMessage
    {
        /// <summary>
        /// このプロパティは常に列挙子：StreamingMessageType.Warningsを返します。
        /// </summary>
        public override StreamingMessageType MessageType => StreamingMessageType.Warnings;
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 状態を示すコード文字列を取得します。
        /// </summary>
        [DataMember(Name = "code")]
        public string Code { get; private set; }
        /// <summary>
        /// メッセージを取得します。
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; private set; }
    }
}
