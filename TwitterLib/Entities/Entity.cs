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
            get => hashTags ?? new HashTag[] { };
            internal set { hashTags = value; }
        }
        /// <summary>
        /// ツイートに埋め込まれているメディアの一覧を取得します。
        /// </summary>
        [DataMember(IsRequired = false, Name = "media")]
        public Media[] MediaList
        {
            get => media ?? new Media[] { };
            internal set { media = value; }
        }
        /// <summary>
        /// ツイートに含まれているURLの一覧を取得します。
        /// </summary>
        [DataMember(Name = "urls")]
        public Url[] Urls
        {
            get => urls ?? new Url[] { };
            internal set { urls = value; }
        }
        /// <summary>
        /// ツイートに含まれている言及先の一覧を取得します。
        /// </summary>
        [DataMember(Name = "mentions")]
        public Mention[] Mentions
        {
            get => mentions ?? new Mention[] { };
            internal set { mentions = value; }
        }
        /// <summary>
        /// ツイートに含まれているシンボルの一覧を取得します。
        /// </summary>
        [DataMember(Name = "symbols")]
        public Symbol[] Symbols
        {
            get => symbols ?? new Symbol[] { };
            internal set { symbols = value; }
        }
    }
}
