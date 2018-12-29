using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Trends
{
    /// <summary>
    /// トレンド情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class TrendInfo
    {
        /// <summary>
        /// トレンドの表示名を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        /// <summary>
        /// 検索URLを取得します。
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; private set; }
        /// <summary>
        /// 検索クエリ文字列を取得します。
        /// </summary>
        [DataMember(Name = "query")]
        public string Query { get; private set; }
        /// <summary>
        /// ツイート数を取得します。
        /// </summary>
        [DataMember(Name = "tweet_volume", IsRequired = false)]
        public int? TweetVolume { get; private set; }
        /// <summary>
        /// トレンドの表示名を返します。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
