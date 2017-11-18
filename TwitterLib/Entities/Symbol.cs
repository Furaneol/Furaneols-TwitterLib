using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    [DataContract]
    public class Symbol
    {
        [DataMember(Name = "indices")]
        public int[] Indices { get; internal set; }
        [DataMember(Name = "text")]
        public string Text { get; internal set; }
    }
}
