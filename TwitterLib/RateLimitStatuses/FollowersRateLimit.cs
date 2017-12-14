using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// FollowersカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class FollowersRateLimit
    {
        /// <summary>
        /// /followers/idsの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/followers/ids")]
        public RateLimitStatus Ids { get; private set; }
        /// <summary>
        /// /followers/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/followers/list")]
        public RateLimitStatus List { get; private set; }
    }
}
