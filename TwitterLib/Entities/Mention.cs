using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    /// <summary>
    /// メンション先の情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Mention
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id_str")]
        public string StringID { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; internal set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; internal set; }
    }
}
