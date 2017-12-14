using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// FriendshipsカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class FriendshipRateLimit
    {
        /// <summary>
        /// /friendships/outgoingの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friendshios/outgoing")]
        public RateLimitStatus Outgoing { get; private set; }
        /// <summary>
        /// /friendships/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friendships/list")]
        public RateLimitStatus List { get; private set; }
        /// <summary>
        /// /friendships/no_retweets/idsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friendships/no_retweets/ids")]
        public RateLimitStatus NoRetweetsIds { get; private set; }
        /// <summary>
        /// /friendships/lookupの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friendships/lookup")]
        public RateLimitStatus Lookup { get; private set; }
        /// <summary>
        /// /friendships/incomingの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friendships/incoming")]
        public RateLimitStatus Incoming { get; private set; }
        /// <summary>
        /// /friendships/showの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friendships/show")]
        public RateLimitStatus Show { get; private set; }
    }
}
