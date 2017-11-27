using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// 現在のユーザー宛のツイート一覧を取得します。
        /// </summary>
        /// <param name="count"></param>
        /// <param name="sinceId"></param>
        /// <param name="maxId"></param>
        /// <param name="trimUser"></param>
        /// <param name="includeEntities"></param>
        /// <returns></returns>
        public Tweet[] GetMentionTimeline(int? count = null, ulong? sinceId = null, ulong? maxId = null, bool? trimUser = null, bool? includeEntities)
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
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Tweet[]));
            
        }
    }
}
