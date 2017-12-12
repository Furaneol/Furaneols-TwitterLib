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
        public int? UtcOffset { get; private set; }
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
        [DataMember(Name = "profile_background_tile")]
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
        private string profileLinkColor
        {
            get { return ProfileLinkColor.R.ToString("x2") + ProfileLinkColor.G.ToString("x2") + ProfileLinkColor.B.ToString("x2"); }
            set { ProfileLinkColor = Twitter.ParseColor(value); }
        }
        /// <summary>
        /// プロフィール上のリンクの色を取得します。
        /// </summary>
        public Color ProfileLinkColor { get; private set; }

        [DataMember(Name = "profile_sidebar_border_color")]
        private string profileSidebarBorderColor
        {
            get { return ProfileSidebarBorderColor.R.ToString("x2") + ProfileSidebarBorderColor.G.ToString("x2") + ProfileSidebarBorderColor.B.ToString("x2"); }
            set { ProfileSidebarBorderColor = Twitter.ParseColor(value); }
        }
        /// <summary>
        /// プロフィールのサイドバーにおける境界線の色を取得します。
        /// </summary>
        public Color ProfileSidebarBorderColor { get; private set; }

        [DataMember(Name = "profile_sidebar_fill_color")]
        private string profileSidebarFillColor
        {
            get { return string.Format("{0:x2}{1:x2}{2:x2}", ProfileSidebarFillColor.R, ProfileSidebarFillColor.G, ProfileSidebarFillColor.B); }
            set { ProfileSidebarFillColor = Twitter.ParseColor(value); }
        }
        /// <summary>
        /// プロフィールのサイドバーにおける塗りつぶし色を取得します。
        /// </summary>
        public Color ProfileSidebarFillColor { get; private set; }

        [DataMember(Name = "profile_text_color")]
        private string profileTextColor
        {
            get { return string.Format("{0:x2}{1:x2}{2:x2}", ProfileTextColor.R, ProfileTextColor.G, ProfileTextColor.B); }
            set { ProfileTextColor = Twitter.ParseColor(value); }
        }
        /// <summary>
        /// プロフィールのテキスト色を取得します。
        /// </summary>
        public Color ProfileTextColor { get; private set; }
        /// <summary>
        /// プロフィールで背景画像を使用しているかどうかを示す値を取得します。
        /// </summary>
        [DataMember(Name = "profile_use_background_image")]
        public bool ProfileUseBackgroundImage { get; private set; }
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
        [DataMember(IsRequired =false,Name ="status")]
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
