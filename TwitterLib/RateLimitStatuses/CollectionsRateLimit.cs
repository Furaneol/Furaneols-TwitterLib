using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// CollectionsカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class CollectionsRateLimit
    {
        /// <summary>
        /// /collections/listの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/collections/list")]
        public RateLimitStatus List { get; private set; }
        /// <summary>
        /// /collections/entriesの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/collections/entries")]
        public RateLimitStatus Entries { get; private set; }
        /// <summary>
        /// /collections/showの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/collections/show")]
        public RateLimitStatus Show { get; private set; }
    }
}
