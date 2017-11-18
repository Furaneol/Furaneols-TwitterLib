using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    /// <summary>
    /// ツイートに含まれるコンテンツの情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Entities
    {
        /// <summary>
        /// ツイートに含まれているハッシュタグの一覧を取得します。
        /// </summary>
        [DataMember(Name ="hashtags")]
        public HashTag[] HashTags { get; internal set; }
        /// <summary>
        /// ツイートに埋め込まれているメディアの一覧を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "media")]
        public Media[] MediaList { get; internal set; }
        /// <summary>
        /// ツイートに含まれているURLの一覧を取得します。
        /// </summary>
        [DataMember(Name = "urls")]
        public Url[] Urls { get; internal set; }
        /// <summary>
        /// ツイートに含まれている言及先の一覧を取得します。
        /// </summary>
        [DataMember(Name = "mentions")]
        public Mention[] Mentions { get; internal set; }
        /// <summary>
        /// ツイートに含まれているシンボルの一覧を取得します。
        /// </summary>
        [DataMember(Name ="symbols")]
        public Symbol[] Symbols { get; internal set; }
    }
}
