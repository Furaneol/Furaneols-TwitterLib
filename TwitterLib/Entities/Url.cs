using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    /// <summary>
    /// ツイートに埋め込まれたURLの情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Url
    {
        /// <summary>
        /// ツイート投稿時に入力されたURLを取得します。
        /// </summary>
        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; protected set; }
        /// <summary>
        /// ツイート投稿時に入力されたURLをプロトコル付きで取得します。
        /// </summary>
        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; protected set; }
        /// <summary>
        /// ツイート内におけるURLの範囲を取得します。
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; protected set; }
        /// <summary>
        /// ツイートに埋め込まれた短縮URLを取得します。
        /// </summary>
        [DataMember(Name = "url")]
        public string UrlString { get; protected set; }
    }
}
