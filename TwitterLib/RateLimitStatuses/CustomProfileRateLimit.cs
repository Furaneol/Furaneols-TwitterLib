using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// Custom ProfilesカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class CustomProfileRateLimit
    {
        /// <summary>
        /// /custom_profiles/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/custom_profiles/list")]
        public RateLimitStatus List { get; private set; }
        /// <summary>
        /// /custom_profiles/showの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/custom_profiles/show")]
        public RateLimitStatus Show { get; private set; }
    }
}
