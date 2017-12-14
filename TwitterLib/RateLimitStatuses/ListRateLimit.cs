using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// ListカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class ListRateLimit
    {
        /// <summary>
        /// /lists/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/list")]
        public RateLimitStatus List { get; private set; }
        /// <summary>
        /// /lists/membershipsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/memberships")]
        public RateLimitStatus Memberships { get; private set; }
        /// <summary>
        /// /lists/subscribers/showの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/subscribers/show")]
        public RateLimitStatus SubscribersShow { get; private set; }
        /// <summary>
        /// /lists/membersの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/members")]
        public RateLimitStatus Members { get; private set; }
        /// <summary>
        /// /lists/subscriptionsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/subscriptions")]
        public RateLimitStatus Subscriptions { get; private set; }
        /// <summary>
        /// /lists/showの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/show")]
        public RateLimitStatus Show { get; private set; }
        /// <summary>
        /// /lists/ownershipsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/ownerships")]
        public RateLimitStatus Ownerships { get; private set; }
        /// <summary>
        /// /lists/subscribersの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/subscribers")]
        public RateLimitStatus Subscribers { get; private set; }
        /// <summary>
        /// /lists/members/showの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/members/show")]
        public RateLimitStatus MembersShow { get; private set; }
        /// <summary>
        /// /lists/statusesの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/lists/statuses")]
        public RateLimitStatus Statuses { get; private set; }
    }
}
