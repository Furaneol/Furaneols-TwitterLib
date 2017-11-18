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
        /// ツイートの識別番号を取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; internal set; }
        /// <summary>
        /// ツイートの識別番号を文字列として取得します。
        /// </summary>
        [DataMember(Name ="id_str")]
        public string StringID { get; internal set; }
        /// <summary>
        /// ツイートを投稿したアプリケーションの情報を示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "source")]
        public string Source { get; internal set; }
        /// <summary>
        /// ツイートの切り捨てが発生しているかどうかを取得します。
        /// </summary>
        [DataMember(Name = "truncated")]
        public bool Truncated { get; internal set; }
        /// <summary>
        /// 返信先のツイートIDを取得します。このツイートが返信でない場合はnullを返します。
        /// </summary>
        [DataMember(Name = "in_reply_to_status_id")]
        public ulong? InReplyToStatusID { get; internal set; }
        /// <summary>
        /// 返信先のツイートIDを文字列として取得します。このツイートが返信でない場合はnullを返します。
        /// </summary>
        [DataMember(Name ="in_reply_to_status_id_str")]
        public string InReplyToStatusStringID { get; internal set; }
        /// <summary>
        /// 返信先のユーザーIDを取得します。このツイートが返信でない場合はnullを返します。
        /// </summary>
        [DataMember(Name ="in_reply_to_user_id")]
        public ulong? InReplyToUserID { get; internal set; }
        /// <summary>
        /// 返信先のユーザーIDを文字列として取得します。このツイートが返信でない場合はnullを返します。
        /// </summary>
        [DataMember(Name = "in_reply_to_user_id_str")]
        public string InReplyToUserStringID { get; internal set; }
        /// <summary>
        /// 投稿したユーザーの情報を取得します。
        /// </summary>
        [DataMember(Name ="user")]
        public User User { get; internal set; }
        /// <summary>
        /// 投稿した位置の情報を取得します。
        /// </summary>
        [DataMember(Name = "coordinates")]
        public Coordinate Coordinate { get; internal set; }
    }
}
