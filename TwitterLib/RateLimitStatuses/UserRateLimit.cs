using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// UserカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class UserRateLimit
    {
        /// <summary>
        /// /users/report_spamの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/report_spam")]
        public RateLimitStatus ReportSpam { get; private set; }
        /// <summary>
        /// /users/contributors/pendingの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/contributors/pending")]
        public RateLimitStatus ContributorsPending { get; private set; }
        /// <summary>
        /// /users/show/:idの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/show/:id")]
        public RateLimitStatus ShowId { get; private set; }
        /// <summary>
        /// /users/searchの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/search")]
        public RateLimitStatus Search { get; private set; }
        /// <summary>
        /// /users/suggestions/:slugの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/suggestions/:slug")]
        public RateLimitStatus SuggestionsSlug { get; private set; }
        /// <summary>
        /// /users/contributees/pendingの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/contributees/pending")]
        public RateLimitStatus ContributeesPending { get; private set; }
        /// <summary>
        /// /users/derived_infoの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/derived_info")]
        public RateLimitStatus DerivedInfo { get; private set; }
        /// <summary>
        /// /users/profile_bannerの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/users/profile_banner")]
        public RateLimitStatus ProfileBanner { get; private set; }
        /// <summary>
        /// /users/suggestions/:slug/membersの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/users/suggestions/:slug/members")]
        public RateLimitStatus SuggestionsSlugMembers { get; private set; }
        /// <summary>
        /// /users/lookupの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/users/lookup")]
        public RateLimitStatus Lookup { get; private set; }
        /// <summary>
        /// /users/suggestionsの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/users/suggestions")]
        public RateLimitStatus Suggestions { get; private set; }
    }
}
