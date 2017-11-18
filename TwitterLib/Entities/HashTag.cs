using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class HashTag
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; internal set; }
    }
}
