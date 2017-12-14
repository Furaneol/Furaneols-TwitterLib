using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// BlocksカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class BlockRateLimit
    {
        /// <summary>
        /// /blocks/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/blocks/list")]
        public RateLimitStatus List { get; private set; }
        /// <summary>
        /// /blocks/idsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/blocks/ids")]
        public RateLimitStatus Ids { get; private set; }
    }
}
