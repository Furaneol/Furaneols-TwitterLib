using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// FriendsカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class FriendsRateLimit
    {
        /// <summary>
        /// /friends/idsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friends/ids")]
        public RateLimitStatus Ids { get; private set; }
        /// <summary>
        /// /friends/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/friends/list")]
        public RateLimitStatus List { get; private set; }
    }
}
