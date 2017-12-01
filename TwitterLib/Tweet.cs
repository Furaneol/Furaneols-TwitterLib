using System;
using System.Runtime.Serialization;
using TwitterLib.Entities;

namespace TwitterLib
{
    /// <summary>
    /// ツイートオブジェクトのデシリアライズ用中間クラスです。
    /// </summary>
    [DataContract]
    public class Tweet : ApiResponce
    {
        [DataMember(Name = "created_at")]
        internal string CreatedAt_raw
        {
            get { return CreatedAt.ToString(); }
            set { CreatedAt = Twitter.ParseDateTime(value); }
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
        [DataMember(Name = "id_str")]
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
        [DataMember(Name = "in_reply_to_status_id_str")]
        public string InReplyToStatusStringID { get; internal set; }
        /// <summary>
        /// 返信先のユーザーIDを取得します。このツイートが返信でない場合はnullを返します。
        /// </summary>
        [DataMember(Name = "in_reply_to_user_id")]
        public ulong? InReplyToUserID { get; internal set; }
        /// <summary>
        /// 返信先のユーザーIDを文字列として取得します。このツイートが返信でない場合はnullを返します。
        /// </summary>
        [DataMember(Name = "in_reply_to_user_id_str")]
        public string InReplyToUserStringID { get; internal set; }
        /// <summary>
        /// 投稿したユーザーの情報を取得します。
        /// </summary>
        [DataMember(Name = "user")]
        public User User { get; internal set; }
        /// <summary>
        /// 投稿時点の詳細な位置情報を取得します。
        /// </summary>
        [DataMember(Name = "coordinates")]
        public Coordinate Coordinate { get; internal set; }
        /// <summary>
        /// 投稿時点の位置情報を取得します。
        /// </summary>
        [DataMember(Name = "place")]
        public Place Place { get; internal set; }
        /// <summary>
        /// ツイートが埋め込まれているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "is_quote_status")]
        public bool IsQuoteStatus { get; internal set; }
        /// <summary>
        /// 埋め込みツイートを取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "quoted_status")]
        public Tweet QuotedStatus { get; internal set; }
        /// <summary>
        /// リツイート元のツイートを取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "retweeted_status")]
        public Tweet RetweetedStatus { get; internal set; }
        /// <summary>
        /// 他のユーザーに埋め込みリツイートされた回数を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "quote_count")]
        public int QuoteCount { get; internal set; }
        /// <summary>
        /// このツイートへの返信件数を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "reply_count")]
        public int ReplyCount { get; internal set; }
        /// <summary>
        /// リツイートされた回数を取得します。
        /// </summary>
        [DataMember(Name = "retweet_count")]
        public int RetweetCount { get; internal set; }
        /// <summary>
        /// いいねされた回数を取得します。
        /// </summary>
        [DataMember(Name = "favorite_count")]
        public int FavoriteCount { get; internal set; }
        /// <summary>
        /// ツイートに埋め込まれているコンテンツの情報を取得します。
        /// </summary>
        [DataMember(Name = "entities")]
        public Entity Entities { get; internal set; }
        /// <summary>
        /// 現在のユーザーがこのツイートをいいねしているかどうかを取得します。
        /// </summary>
        [DataMember(Name = "favorited")]
        public bool Favorited { get; internal set; }
        /// <summary>
        /// 現在のユーザーががこのツイートをリツイートしているかどうかを取得します。
        /// </summary>
        [DataMember(Name = "retweeted")]
        public bool Retweeted { get; internal set; }
        /// <summary>
        /// 注意して扱うべきコンテンツが含まれているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "possibly_sensitive")]
        public bool? PossiblySensitive { get; internal set; }
        /// <summary>
        /// 使用している言語をBCP 47コードの文字列として取得します。
        /// </summary>
        [DataMember(Name = "lang")]
        public string Language { get; internal set; }
        /// <summary>
        /// ツイートがDMCAの苦情により保留されているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "withheld_copyright")]
        public bool WithheldCopyright { get; internal set; }
        /// <summary>
        /// このツイートの表示を保留している国の一覧を取得します。(XX:すべての国,XY:DMCAによる保留)
        /// </summary>
        [DataMember(IsRequired = false, Name = "withheld_in_countries")]
        public string[] WithheldCountry { get; internal set; }

        Twitter parent;
        public override Twitter Parent
        {
            get { return parent; }
            internal set
            {
                parent = value;
                if (User != null)
                    User.Parent = value;
            }
        }
    }
}
