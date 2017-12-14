using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// ApplicationカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class ApplicationRateLimit
    {
        /// <summary>
        /// /application/rate_limit_statusの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/application/rate_limit_status")]
        public RateLimitStatus RateLimitStatus { get; private set; }
    }
}
