using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// 指定されたユーザーIDを持つユーザーのツイート一覧を取得します。
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="count"></param>
        /// <param name="sinceId"></param>
        /// <param name="maxId"></param>
        /// <param name="trimUser"></param>
        /// <param name="excludeReplies"></param>
        /// <param name="includeRetweets"></param>
        /// <returns></returns>
        public Tweet[] GetUserTimeline(ulong userId,
            int? count = null,
            ulong? sinceId = null,
            ulong? maxId = null,
            bool? trimUser = null,
            bool? excludeReplies = null,
            bool? includeRetweets = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = userId.ToString() };
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
            if (includeRetweets.HasValue)
                args["include_rts"] = includeRetweets.ToString().ToLower();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tweet[]));
            return (Tweet[])GetOAuthResponce("GET", "https://api.twitter.com/1.1/statuses/user_timeline.json", args, serializer);
        }

    }
}
