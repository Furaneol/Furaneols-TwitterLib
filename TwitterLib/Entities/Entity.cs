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
    public class Entity
    {

        HashTag[] hashTags;
        Media[] media;
        Url[] urls;
        Mention[] mentions;
        Symbol[] symbols;
        /// <summary>
        /// ツイートに含まれているハッシュタグの一覧を取得します。
        /// </summary>
        [DataMember(Name = "hashtags")]
        public HashTag[] HashTags
        {
            get => hashTags;
            internal set { hashTags = value ?? new HashTag[] { }; }
        }
        /// <summary>
        /// ツイートに埋め込まれているメディアの一覧を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "media")]
        public Media[] MediaList
        {
            get => media;
            internal set { media = value ?? new Media[] { }; }
        }
        /// <summary>
        /// ツイートに含まれているURLの一覧を取得します。
        /// </summary>
        [DataMember(Name = "urls")]
        public Url[] Urls
        {
            get => urls;
            internal set { urls = value ?? new Url[] { }; }
        }
        /// <summary>
        /// ツイートに含まれている言及先の一覧を取得します。
        /// </summary>
        [DataMember(Name = "mentions")]
        public Mention[] Mentions
        {
            get => mentions;
            internal set { mentions = value ?? new Mention[] { }; }
        }
        /// <summary>
        /// ツイートに含まれているシンボルの一覧を取得します。
        /// </summary>
        [DataMember(Name = "symbols")]
        public Symbol[] Symbols
        {
            get => symbols;
            internal set { symbols = value ?? new Symbol[] { }; }
        }
    }
}
