using System;
using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// Twitter Streaming APIの応答情報である事を示します。
    /// </summary>
    [DataContract]
    public abstract class StreamingMessage : ApiResponce
    {
        /// <summary>
        /// ストリーミングAPIからの応答を識別する値を取得します。
        /// </summary>
        public abstract StreamingMessageType MessageType { get; }
        /// <summary>
        /// 応答があった時刻を取得します。
        /// </summary>
        public DateTime TimeStamp { get; private set; }

        [DataMember(IsRequired = false, Name = "timestamp_ms")]
        private string timeStamp
        {
            get { return (TimeStamp - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString(); }
            set { TimeStamp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(double.Parse(value)); }
        }
    }
}
