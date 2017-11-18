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
        /// 言及先のユーザーIDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; internal set; }
        /// <summary>
        /// 言及先のユーザーIDを文字列として取得します。
        /// </summary>
        [DataMember(Name = "id_str")]
        public string StringID { get; internal set; }
        /// <summary>
        /// 言及先ユーザー名の範囲を取得します。
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; internal set; }
        /// <summary>
        /// 言及先の表示名を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; internal set; }
        /// <summary>
        /// 言及先のスクリーン名を取得します。
        /// </summary>
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; internal set; }
    }
}
