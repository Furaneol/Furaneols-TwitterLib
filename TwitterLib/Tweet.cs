using System;
using System.Runtime.Serialization;
using System.Globalization;

namespace TwitterLib
{
    /// <summary>
    /// ツイートオブジェクトのデシリアライズ用中間クラスです。
    /// </summary>
    [DataContract]
    public class Tweet
    {
        
        [DataMember(Name = "created_at")]
        internal string CreatedAt_raw
        {
            get { return CreatedAt.ToString(); }
            set { CreatedAt = DateTime.ParseExact(value.Insert(23, ":"), "ddd MMM dd hh:mm:ss zzz yyyy", CultureInfo.GetCultureInfo("en-us")); }
        }
        /// <summary>
        /// ツイートの投稿時刻を取得します。
        /// </summary>
        public DateTime CreatedAt { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name ="id_str")]
        public string StringID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "source")]
        public string Source { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "truncated")]
        public bool Truncated { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "in_reply_to_status_id")]
        public ulong? InReplyToStatusID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name ="in_reply_to_status_id_str")]
        public string InReplyToStatusStringID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name ="in_reply_to_user_id")]
        public ulong? InReplyToUserID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "in_reply_to_user_id_str")]
        public string InReplyToUserStringID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name ="user")]
        public User User { get; internal set; }
    }
}
