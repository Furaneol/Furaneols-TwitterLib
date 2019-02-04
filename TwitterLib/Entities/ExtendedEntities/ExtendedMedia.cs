using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities.ExtendedEntities
{
    /// <summary>
    /// 拡張メディア情報を格納するクラスです。
    /// </summary>
    [DataContract]
    public class ExtendedMedia
    {
        /// <summary>
        /// IDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; private set; }
        /// <summary>
        /// ツイートテキスト上の範囲を取得します。
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; private set; }
        /// <summary>
        /// メディアファイルのURLを取得します。
        /// </summary>
        [DataMember(Name ="media_url")]
        public string MediaUrl { get; private set; }
        /// <summary>
        /// メディアファイルのURL(https)を取得します。
        /// </summary>
        [DataMember(Name = "media_url_https")]
        public string MediaUrlHttps { get; private set; }
        /// <summary>
        /// 短縮URLを取得します。
        /// </summary>
        [DataMember(Name ="url")]
        public string Url { get; private set; }
        /// <summary>
        /// メディアを投稿したツイートURLを取得します。
        /// </summary>
        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; private set; }
        /// <summary>
        /// メディアを投稿したツイートの完全URLを取得します。
        /// </summary>
        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; private set; }
        /// <summary>
        /// メディアの種類を取得します。
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; private set; }
        /// <summary>
        /// メディアのサイズを取得します。
        /// </summary>
        [DataMember(Name = "sizes")]
        public SizeList Sizes { get; private set; }
    }
}
