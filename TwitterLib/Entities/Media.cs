using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities
{
    /// <summary>
    /// 映像や画像コンテンツの情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Media
    {
        /// <summary>
        /// クライアントに表示するURLを取得します。
        /// </summary>
        [DataMember(Name = "display_url")]
        public string DisplayUrl { get; protected set; }
        /// <summary>
        /// コンテンツ表示ページのURLを取得します。
        /// </summary>
        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; protected set; }
        /// <summary>
        /// コンテンツIDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; protected set; }
        /// <summary>
        /// コンテンツIDを文字列として取得します。
        /// </summary>
        [DataMember(Name = "id_str")]
        public string StringID { get; protected set; }
        /// <summary>
        /// ツイート内のコンテンツを示している範囲を取得します。
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; protected set; }
        /// <summary>
        /// コンテンツ本体のURLを取得します。
        /// </summary>
        [DataMember(Name = "media_url")]
        public string MediaUrl { get; protected set; }
        /// <summary>
        /// コンテンツ本体のhttps URLを取得します。
        /// </summary>
        [DataMember(Name = "media_url_https")]
        public string MediaUrlHttps { get; protected set; }
        /// <summary>
        /// コンテンツの表示サイズ情報を取得します。
        /// </summary>
        [DataMember(Name = "sizes")]
        public SizeList Sizes { get; protected set; }
        /// <summary>
        /// このコンテンツを投稿したツイートのIDを取得します。
        /// </summary>
        [DataMember(Name = "source_status_id")]
        public ulong SourceStatusID { get; protected set; }
        /// <summary>
        /// このコンテンツを投稿したツイートのIDを文字列として取得します。
        /// </summary>
        [DataMember(Name = "source_status_id_str")]
        public string SourceStatusStringID { get; protected set; }
        /// <summary>
        /// コンテンツの種類を示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "type")]
        public string MediaType { get; protected set; }
        /// <summary>
        /// ツイートに表記されているURL文字列を取得します。
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; protected set; }
        /// <summary>
        /// メディアの説明文を取得します。
        /// </summary>
        [DataMember(IsRequired =false,Name = "ext_alt_text")]
        public string AltText { get; protected set; }
    }
    /// <summary>
    /// メディアサイズの一覧を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class SizeList
    {
        /// <summary>
        /// サムネイルのサイズ情報を取得します。
        /// </summary>
        [DataMember(Name = "thumb")]
        public Size Thumbnail { get; protected set; }
        /// <summary>
        /// 大サイズの情報を取得します。
        /// </summary>
        [DataMember(Name = "large")]
        public Size Large { get; protected set; }
        /// <summary>
        /// 中サイズの情報を取得します。
        /// </summary>
        [DataMember(Name = "medium")]
        public Size Medium { get; protected set; }
        /// <summary>
        /// 小サイズの情報を取得します。
        /// </summary>
        [DataMember(Name = "small")]
        public Size Small { get; protected set; }
    }
    /// <summary>
    /// サイズ情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Size
    {
        /// <summary>
        /// 幅を取得します。
        /// </summary>
        [DataMember(Name = "w")]
        public int Width { get; protected set; }
        /// <summary>
        /// 高さを取得します。
        /// </summary>
        [DataMember(Name = "h")]
        public int Height { get; protected set; }
        /// <summary>
        /// リサイズアルゴリズムを示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "resize")]
        public string Resize { get; protected set; }
        /// <summary>
        /// System.Drawing.Sizeへの変換を行います。
        /// </summary>
        /// <param name="size"></param>
        public static implicit operator System.Drawing.Size(Size size)
        {
            return new System.Drawing.Size(size.Width, size.Height);
        }
    }
}
