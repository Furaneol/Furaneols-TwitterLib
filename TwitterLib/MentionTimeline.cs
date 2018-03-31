using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// 現在のユーザー宛のツイート一覧を取得します。
        /// </summary>
        /// <param name="count">取得する件数</param>
        /// <param name="sinceId">最も古いツイートID</param>
        /// <param name="maxId">最も新しいツイートID</param>
        /// <param name="trimUser"></param>
        /// <param name="includeEntities"></param>
        /// <returns></returns>
        public Tweet[] GetMentionTimeline(int? count = null, ulong? sinceId = null, ulong? maxId = null, bool? trimUser = null, bool? includeEntities = null)
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
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            return (Tweet[])GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "GET", "https://api.twitter.com/1.1/statuses/mentions_timeline.json", args, typeof(Tweet[]));
        }
    }
}
