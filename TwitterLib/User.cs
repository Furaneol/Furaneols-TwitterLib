using System;
using System.Runtime.Serialization;
using System.Drawing;
using TwitterLib.Entities;

namespace TwitterLib
{
    /// <summary>
    /// ユーザー情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public partial class User : ApiResponce
    {
        /// <summary>
        /// IDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong UserID { get; private set; }
        /// <summary>
        /// IDを文字列として取得します。
        /// </summary>
        [DataMember(Name = "id_str")]
        public string UserStringID { get; private set; }
        /// <summary>
        /// 名前を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        /// <summary>
        /// スクリーン名を取得します。
        /// </summary>
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; private set; }
        /// <summary>
        /// 現在地として設定された文字列を取得します。
        /// </summary>
        [DataMember(Name = "location")]
        public string Location { get; private set; }
        /// <summary>
        /// ホームページとして設定された文字列を取得します。
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; private set; }
        /// <summary>
        /// プロフィール文を取得します。
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; private set; }
        /// <summary>
        /// 非公開アカウントであるかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "protected")]
        public bool Protected { get; private set; }
        /// <summary>
        /// 認証済みアカウントであるかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "verified")]
        public bool Verified { get; private set; }
        /// <summary>
        /// フォロワー数を取得します。
        /// </summary>
        [DataMember(Name = "followers_count")]
        public int FollowersCount { get; private set; }
        /// <summary>
        /// フォロー数を取得します。
        /// </summary>
        [DataMember(Name = "friends_count")]
        public int FollowingCount { get; private set; }
        /// <summary>
        /// メンバーになっているリストの数を取得します。
        /// </summary>
        [DataMember(Name = "listed_count")]
        public int ListedCount { get; private set; }
        /// <summary>
        /// いいねしたツイートの数を取得します。
        /// </summary>
        [DataMember(Name = "favourites_count")]
        public int FavouritesCount { get; private set; }
        /// <summary>
        /// ツイート数を取得します。
        /// </summary>
        [DataMember(Name = "statuses_count")]
        public int StatusesCount { get; private set; }
#pragma warning disable IDE0051
        [DataMember(Name = "created_at")]
        private string created_at
        {
            get { return CreatedAt.ToString(); }
            set { CreatedAt = Twitter.ParseDateTime(value); }
        }
#pragma warning restore IDE0051
        /// <summary>
        /// アカウントの作成日を取得します。
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        /// <summary>
        /// プロフィールのヘッダー画像が格納されているURLを取得します。
        /// </summary>
        [DataMember(Name = "profile_banner_url")]
        public string ProfileBannerUrl { get; private set; }
        /// <summary>
        /// アイコン画像が格納されているURLを取得します。
        /// </summary>
        [DataMember(Name = "profile_image_url_https")]
        public string IconImageUrl { get; private set; }
        /// <summary>
        /// プロフィールが未変更であるかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "default_profile")]
        public bool IsDefaultProfile { get; private set; }
        /// <summary>
        /// 初期アイコンを使用しているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "default_profile_image")]
        public bool IsDefaultProfileImage { get; private set; }
        /// <summary>
        /// 表示が保留されている国の一覧を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "withheld_in_countries")]
        public string WithheldInCountries { get; private set; }
        /// <summary>
        /// 表示保留の範囲を示す文字列を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "withheld_scope")]
        public string WithheldScope { get; private set; }
        /// <summary>
        /// 最後に投稿したツイートを取得します。このフィールドはリクエスト時の指定によって取得されない事があります。
        /// </summary>
        [DataMember(Name ="status")]
        public Tweet Status { get; private set; }
        /// <summary>
        /// プロフィールに含まれるメタ情報を取得します。このフィールドはリクエスト時の指定によって取得されない事があります。
        /// </summary>
        [DataMember(IsRequired = false, Name = "entities")]
        public Entity Entities { get; private set; }
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }
    }
}
