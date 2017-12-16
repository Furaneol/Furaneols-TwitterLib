using System;
using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// Twitterにおけるリストの情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public partial class List
    {
        /// <summary>
        /// リストの識別番号を取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; private set; }
        /// <summary>
        /// リストの名前を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        /// <summary>
        /// リストの場所をhttps://twitter.com/を基点とした相対パスとして取得します。
        /// </summary>
        [DataMember(Name = "uri")]
        public string Uri { get; private set; }
        /// <summary>
        /// リストを保存しているユーザーの数を取得します。
        /// </summary>
        [DataMember(Name ="subscriber_count")]
        public int SubscriberCount { get; private set; }
        /// <summary>
        /// リストに登録しているユーザーの数を取得します。
        /// </summary>
        [DataMember(Name ="member_count")]
        public int MemberCount { get; private set; }
        /// <summary>
        /// 公開状態を示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "mode")]
        public string Mode { get; private set; }
        /// <summary>
        /// リストの説明文を取得します。
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; private set; }
        /// <summary>
        /// リストのスラッグを取得します。
        /// </summary>
        [DataMember(Name ="slug")]
        public string Slug { get; private set; }
        /// <summary>
        /// リストの完全名を取得します。
        /// </summary>
        [DataMember(Name = "full_name")]
        public string FullName { get; private set; }

        [DataMember(Name = "created_at")]
        private string createdAt { get { return CreatedAt.ToString(); } set { CreatedAt = Twitter.ParseDateTime(value); } }
        /// <summary>
        /// リストの作成日を取得します。
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        /// <summary>
        /// リストをフォローしているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name="following")]
        public bool Following { get; private set; }
        /// <summary>
        /// リストを作成したユーザーの情報を取得します。
        /// </summary>
        [DataMember(Name = "user")]
        public User CreateUser { get; private set; }
    }
}
