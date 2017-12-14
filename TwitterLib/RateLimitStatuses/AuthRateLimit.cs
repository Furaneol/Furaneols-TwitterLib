using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// AuthカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class AuthRateLimit
    {
        /// <summary>
        /// /auth/csrf_tokenの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/auth/csrf_token")]
        public RateLimitStatus CsrfToken { get; private set; }
    }
}
