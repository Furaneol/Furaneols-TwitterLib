using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// 位置情報が削除されたことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class ScrubGeoInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.ScrubGeo;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 位置情報を削除したユーザーIDを取得します。
        /// </summary>
        [DataMember(Name = "user_id")]
        public ulong UserID { get; private set; }
        /// <summary>
        /// 削除の起点となるツイートのIDを取得します。
        /// </summary>
        [DataMember(Name = "up_to_status_id")]
        public ulong UpToStatusID { get; private set; }
    }
}
