using TwitterLib.Trends;
using System.Collections.Generic;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// トレンド取得時に使用可能な位置情報の一覧を取得します。
        /// </summary>
        /// <returns></returns>
        public TrendPlaceInfo[] GetAvailableTrendPlaces()
        {
            return (TrendPlaceInfo[])GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "GET", "https://api.twitter.com/1.1/trends/available.json", new SortedDictionary<string, string>(), typeof(TrendPlaceInfo[]));
        }
    }
}
