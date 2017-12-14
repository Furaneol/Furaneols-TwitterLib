using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// StatusesカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class StatusRateLimit
    {
        /// <summary>
        /// /statuses/retweeters/idsの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/retweeters/ids")]
        public RateLimitStatus RetweeterIds { get; private set; }
        /// <summary>
        /// /statuses/retweets_of_meの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/retweets_of_me")]
        public RateLimitStatus RetweetsOfMe { get; private set; }
        /// <summary>
        /// /statuses/home_timelineの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/home_timeline")]
        public RateLimitStatus HomeTimeline { get; private set; }
        /// <summary>
        /// /statuses/show/:idの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/show/:id")]
        public RateLimitStatus ShowId { get; private set; }
        /// <summary>
        /// /statuses/user_timelineの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/user_timeline")]
        public RateLimitStatus UserTimeline { get; private set; }
        /// <summary>
        /// /statises/friendsの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/friends")]
        public RateLimitStatus Friends { get; private set; }
        /// <summary>
        /// /statuses/retweets/:idの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/statuses/retweets/:id")]
        public RateLimitStatus RetweetsId { get; private set; }
        /// <summary>
        /// /statuses/mentions_timelineの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/mentions_timeline")]
        public RateLimitStatus MentionsTimeline { get; private set; }
        /// <summary>
        /// /statuses/oembedの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/oembed")]
        public RateLimitStatus Oembed { get; private set; }
        /// <summary>
        /// /statuses/lookupの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/statuses/lookup")]
        public RateLimitStatus Lookup { get; private set; }
    }
}
