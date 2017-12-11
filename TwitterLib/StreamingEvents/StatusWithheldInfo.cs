using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// ツイートの閲覧が制限されたことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class StatusWithheldInfo:StreamingMessage
    {
        /// <summary>
        /// 制限されたツイートのIDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; private set; }
        /// <summary>
        /// 当該ツイートを投稿したユーザーのIDを取得します。
        /// </summary>
        [DataMember(Name = "user_id")]
        public ulong UserID { get; private set; }
        /// <summary>
        /// 閲覧制限を行った国を示すコードの一覧を取得します。
        /// </summary>
        [DataMember(Name = "withheld_in_countries")]
        public string[] Countries { get; private set; }

        public override StreamingMessageType MessageType => StreamingMessageType.WithheldStatus;

        public override Twitter Parent { get; internal set; }
    }
}
