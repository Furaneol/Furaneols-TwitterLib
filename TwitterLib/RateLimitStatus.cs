using TwitterLib.RateLimitStatuses;
using System.Collections.Generic;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// APIの使用回数制限情報を取得します。
        /// </summary>
        /// <returns></returns>
        public RateLimitStatusContainer GetRateLimitStatus(TwitterAuthenticationMode mode)
        {
            return (RateLimitStatusContainer)GetOAuthResponce(mode, "GET", "https://api.twitter.com/1.1/application/rate_limit_status.json", new SortedDictionary<string, string>() { ["resources"] = "application,favorites,followers,friends,friendships,geo,help,lists,search,statuses,trends,users" }, typeof(RateLimitStatusContainer));
        }
    }
}
