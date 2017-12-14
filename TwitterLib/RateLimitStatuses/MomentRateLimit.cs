using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// MomentカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class MomentRateLimit
    {
        /// <summary>
        /// /moments/permissionsの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/moments/permissions")]
        public RateLimitStatus Permissions { get; private set; }
    }
}
