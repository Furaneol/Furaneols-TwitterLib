using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// 位置情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Coordinate : ApiResponce
    {
        /// <summary>
        /// 座標情報を取得します。
        /// </summary>
        [DataMember(Name = "coodinates")]
        public float[] Coodinates { get; internal set; }
        /// <summary>
        /// この情報の種類を示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; internal set; }
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }
    }
}
