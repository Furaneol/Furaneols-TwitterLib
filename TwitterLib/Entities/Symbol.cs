using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    /// <summary>
    /// ティッカーシンボルの情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Symbol
    {
        /// <summary>
        /// ツイート内におけるティッカーシンボルの範囲を取得します。
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; protected set; }
        /// <summary>
        /// ティッカーシンボルの名前を取得します。
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; protected set; }
    }
}
