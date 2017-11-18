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
        public string DisplayUrl { get; internal set; }
        /// <summary>
        /// コンテンツ表示ページのURLを取得します。
        /// </summary>
        [DataMember(Name = "expanded_url")]
        public string ExpandedUrl { get; internal set; }
        /// <summary>
        /// コンテンツIDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; internal set; }
        /// <summary>
        /// コンテンツIDを文字列として取得します。
        /// </summary>
        [DataMember(Name = "id_str")]
        public string StringID { get; internal set; }
        /// <summary>
        /// ツイート内のコンテンツを示している範囲を取得します。
        /// </summary>
        [DataMember(Name = "indices")]
        public int[] Indices { get; internal set; }
        /// <summary>
        /// コンテンツ本体のURLを取得します。
        /// </summary>
        [DataMember(Name = "media_url")]
        public string MediaUrl { get; internal set; }
        /// <summary>
        /// コンテンツ本体のhttps URLを取得します。
        /// </summary>
        [DataMember(Name = "media_url_https")]
        public string MediaUrlHttps { get; internal set; }
        /// <summary>
        /// コンテンツの表示サイズ情報を取得します。
        /// </summary>
        [DataMember(Name = "sizes")]
        public SizeList Sizes { get; internal set; }
        /// <summary>
        /// このコンテンツを投稿したツイートのIDを取得します。
        /// </summary>
        [DataMember(Name = "source_status_id")]
        public ulong SourceStatusID { get; internal set; }
        /// <summary>
        /// このコンテンツを投稿したツイートのIDを文字列として取得します。
        /// </summary>
        [DataMember(Name = "source_status_id_str")]
        public string SourceStatusStringID { get; internal set; }
        /// <summary>
        /// コンテンツの種類を示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "type")]
        public string MediaType { get; internal set; }
        /// <summary>
        /// ツイートに表記されているURL文字列を取得します。
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; internal set; }
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
        public Size Thumbnail { get; internal set; }
        /// <summary>
        /// 大サイズの情報を取得します。
        /// </summary>
        [DataMember(Name = "large")]
        public Size Large { get; internal set; }
        /// <summary>
        /// 中サイズの情報を取得します。
        /// </summary>
        [DataMember(Name = "medium")]
        public Size Medium { get; internal set; }
        /// <summary>
        /// 小サイズの情報を取得します。
        /// </summary>
        [DataMember(Name = "small")]
        public Size Small { get; internal set; }
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
        public int Width { get; internal set; }
        /// <summary>
        /// 高さを取得します。
        /// </summary>
        [DataMember(Name = "h")]
        public int Height { get; internal set; }
        /// <summary>
        /// リサイズアルゴリズムを示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "resize")]
        public string Resize { get; internal set; }

        public static implicit operator System.Drawing.Size(Size size)
        {
            return new System.Drawing.Size(size.Width, size.Height);
        }
    }
}
