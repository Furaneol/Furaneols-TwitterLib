using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// Trendsカテゴリのレート制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class TrendRateLimit
    {
        /// <summary>
        /// /trends/closestの取得回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/trends/closet")]
        public RateLimitStatus Closest { get; private set; }
        /// <summary>
        /// /trends/availableの取得回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/trends/available")]
        public RateLimitStatus Available { get; private set; }
        /// <summary>
        /// /trends/placeの取得回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/trends/place")]
        public RateLimitStatus Place { get; private set; }
    }
}
