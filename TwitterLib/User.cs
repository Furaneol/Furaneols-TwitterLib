using System;
using System.Runtime.Serialization;
using System.Drawing;

namespace TwitterLib
{
    /// <summary>
    /// ユーザー情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class User
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
        [DataMember(Name="url")]
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
        [DataMember(Name = "created_at")]
        private string created_at
        {
            get { return CreatedAt.ToString(); }
            set { CreatedAt = Twitter.ParseDateTime(value); }
        }
        /// <summary>
        /// アカウントの作成日を取得します。
        /// </summary>
        public DateTime CreatedAt { get; private set; }
        /// <summary>
        /// 協定世界時との時差を秒単位で取得します。
        /// </summary>
        [DataMember(Name = "utc_offset")]
        public int UtcOffset { get; private set; }
        /// <summary>
        /// タイムゾーンの名前を取得します。
        /// </summary>
        [DataMember(Name = "time_zone")]
        public string TimeZone { get; private set; }
        /// <summary>
        /// 位置情報を有効にしているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "geo_enabled")]
        public bool GeoEnabled { get; private set; }
        /// <summary>
        /// 使用している言語を示すBCP 47定義コードの値を取得します。
        /// </summary>
        [DataMember(Name = "lang")]
        public string LanguageCode { get; private set; }
        /// <summary>
        /// ライター機能を使用しているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "contributors_enabled")]
        public bool ContributorsEnabled { get; private set; }

        [DataMember(Name = "profile_background_color")]
        private string profileBackgroundColor
        {
            get { return ProfileBackgroundColor.R.ToString("x2") + ProfileBackgroundColor.G.ToString("x2") + ProfileBackgroundColor.B.ToString("x2"); }
            set { ProfileBackgroundColor = Twitter.ParseColor(value); }
        }
        /// <summary>
        /// プロフィールの背景色を取得します。
        /// </summary>
        public Color ProfileBackgroundColor { get; private set; }
        /// <summary>
        /// プロフィールの背景画像が格納されているURLを取得します。
        /// </summary>
        [DataMember(Name = "profile_background_image_url")]
        public string ProfileBackgroundImageUrl { get; private set; }
        /// <summary>
        /// プロフィールの背景画像が格納されているURLを取得します。
        /// </summary>
        [DataMember(Name = "profile_background_image_url_https")]
        public string ProfileBackgroundImageUrlHttps { get; private set; }
        /// <summary>
        /// プロフィールの背景画像をタイル状に敷き詰めて表示するかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name ="profile_background_tile")]
        public bool ProfileBackgroundTile { get; private set; }
        /// <summary>
        /// プロフィールのヘッダー画像が格納されているURLを取得します。
        /// </summary>
        [DataMember(Name = "profile_banner_url")]
        public string ProfileBannerUrl { get; private set; }
        /// <summary>
        /// アイコン画像が格納されているURLを取得します。
        /// </summary>
        [DataMember(Name = "profile_image_url")]
        public string IconImageUrl { get; private set; }
        /// <summary>
        /// アイコン画像が格納されているURLを取得します。
        /// </summary>
        [DataMember(Name = "profile_image_url_https")]
        public string IconImageUrlHttps { get; private set; }

        [DataMember(Name = "profile_link_color")]
        private string profileLinkColor {
            get { return ProfileLinkColor.R.ToString("x2") + ProfileLinkColor.G.ToString("x2") + ProfileLinkColor.B.ToString("x2"); }
            set { ProfileLinkColor = Twitter.ParseColor(value); }
        }
        /// <summary>
        /// リンクの色を取得します。
        /// </summary>
        public Color ProfileLinkColor { get; private set; }
    }
}
