using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// MutesカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class MuteRateLimit
    {
        /// <summary>
        /// /mutes/users/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/mutes/users/list")]
        public RateLimitStatus UserList { get; private set; }
        /// <summary>
        /// /mutes/users/idsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/mutes/users/ids")]
        public RateLimitStatus UserIds { get; private set; }
    }
}
