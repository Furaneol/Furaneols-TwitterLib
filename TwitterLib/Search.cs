using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// 指定されたキーワードを含むツイートを検索します。
        /// </summary>
        /// <param name="q">キーワード</param>
        /// <param name="count"></param>
        /// <param name="since"></param>
        /// <param name="max"></param>
        /// <param name="resultType"></param>
        /// <param name="lang"></param>
        /// <param name="includeEntities"></param>
        /// <returns></returns>
        public Tweet[] SearchTweet(string q, int? count = null, ulong? since = null, ulong? max = null, SearchResultType? resultType = null, string lang = null, bool? includeEntities = null)
        {
            SortedDictionary<string, string> query = new SortedDictionary<string, string>() { ["q"] = q };
            if (count.HasValue) query["count"] = count.Value.ToString();
            if (since.HasValue) query["since_id"] = since.Value.ToString();
            if (max.HasValue) query["max_id"] = max.Value.ToString();
            if (resultType.HasValue) query["result_type"] = resultType.Value.ToString().ToLower();
            if (!string.IsNullOrEmpty(lang)) query["lang"] = lang;
            if (includeEntities.HasValue) query["include_entities"] = includeEntities.ToString().ToLower();
            return ((SearchResultContainer)GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/search/tweets.json", query, typeof(SearchResultContainer))).Result;
        }
    }
    /// <summary>
    /// ツイート検索の種類を指定する値です。
    /// </summary>
    public enum SearchResultType
    {
        /// <summary>
        /// RecentとPopularの結果を含んだ検索結果を指定します。
        /// </summary>
        Mixed,
        /// <summary>
        /// 最新のツイートを指定します。
        /// </summary>
        Recent,
        /// <summary>
        /// 話題のツイートを指定します。
        /// </summary>
        Popular
    }

    [DataContract]
    class SearchResultContainer : ApiResponce
    {
        [DataMember(Name = "statuses")]
        public Tweet[] Result { get; private set; }
        public override Twitter Parent { get ; internal set; }
    }
}
