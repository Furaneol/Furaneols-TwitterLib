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
            Tweet[] timeline = null;
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Tweet[]));
            GetOAuthResponce("GET", "", args, (Stream stream) => { timeline = (Tweet[])js.ReadObject(stream); });
            return timeline;
        }
    }
}
