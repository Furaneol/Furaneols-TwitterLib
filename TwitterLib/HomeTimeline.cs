using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// タイムライン上のツイートを取得します。
        /// </summary>
        /// <param name="count">ツイート取得件数</param>
        /// <param name="sinceId">最も古いツイートのID</param>
        /// <param name="maxId">最も新しいツイートのID</param>
        /// <param name="trimUser">userノードを省略するかどうか</param>
        /// <param name="excludeReplies">リプライを除外するかどうか</param>
        /// <param name="includeEntities">entitiesノードを含めるかどうか</param>
        /// <returns></returns>
        public Tweet[] GetHomeTimeline(int? count = null, ulong? sinceId = null, ulong? maxId = null, bool? trimUser = null, bool? excludeReplies = null, bool? includeEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            if (count.HasValue)
                args["count"] = count.ToString();
            if (sinceId.HasValue)
                args["since_id"] = sinceId.ToString();
            if (maxId.HasValue)
                args["max_id"] = maxId.ToString();
            if (trimUser.HasValue)
                args["trim_user"] = trimUser.ToString().ToLower();
            if (excludeReplies.HasValue)
                args["exclude_replies"] = excludeReplies.ToString().ToLower();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            return (Tweet[])GetOAuthResponce("GET", "https://api.twitter.com/1.1/statuses/home_timeline.json", args, typeof(Tweet[]));
        }
    }
}
