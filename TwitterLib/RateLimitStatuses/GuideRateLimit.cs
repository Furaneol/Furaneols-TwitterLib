using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// GuideカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class GuideRateLimit
    {
        /// <summary>
        /// /guideの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/guide")]
        public RateLimitStatus Guide { get; private set; }
    }
}
