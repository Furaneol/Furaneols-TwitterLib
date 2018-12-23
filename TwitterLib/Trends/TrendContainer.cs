using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib.Trends
{
    /// <summary>
    /// トレンド情報コンテナです。
    /// </summary>
    [DataContract]
    class TrendContainer : ApiResponce
    {
        public override Twitter Parent { get; internal set; }
        [DataMember(Name ="trends")]
        public TrendInfo[] Trends { get; private set; }
    }
}
