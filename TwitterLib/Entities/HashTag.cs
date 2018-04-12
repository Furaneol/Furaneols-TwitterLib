using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    /// <summary>
    /// ハッシュタグ情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class HashTag
    {
        /// <summary>
        /// ハッシュタグの範囲を取得します。
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; internal set; }
        /// <summary>
        /// ハッシュタグ文字列を取得します。
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; internal set; }
    }
}
