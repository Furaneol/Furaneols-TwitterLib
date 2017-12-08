using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// ツイートが削除されたことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class TweetDeleteInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.TweetDeleted;
        public override Twitter Parent { get; internal set; }
        #region private class
        [DataContract]
        class StatusNode
        {
            [DataMember(Name = "id")]
            public ulong ID { get; private set; }
            [DataMember(Name = "user_id")]
            public ulong UserID { get; private set; }
        }
        #endregion
        [DataMember(Name = "status")]
        private StatusNode status { get; set; }
        /// <summary>
        /// 削除されたツイートのIDを取得します。
        /// </summary>
        public ulong ID { get => status?.ID ?? 0; }
        /// <summary>
        /// 削除されたツイートを投稿したユーザーのIDを取得します。
        /// </summary>
        public ulong UserID { get => status?.UserID ?? 0; }
    }
}
