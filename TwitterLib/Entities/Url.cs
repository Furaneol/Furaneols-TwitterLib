using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    [DataContract]
    public class Url
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "url")]
        public string UrlString { get; internal set; }
    }
}
