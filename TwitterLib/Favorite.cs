using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
    partial class Twitter
    {
        /// <summary>
        /// 指定されたツイートにいいねします。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tweet Favorite(ulong id)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["id"] = id.ToString() };
            return (Tweet)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "POST", "https://api.twitter.com/1.1/favorites/create.json", args, typeof(Tweet));
        }
        /// <summary>
        /// 指定されたツイートのいいねを解除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tweet Unfavorite(ulong id)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["id"] = id.ToString() };
            return (Tweet)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "POST", "https://api.twitter.com/1.1/favorites/destroy.json", args, typeof(Tweet));
        }
    }

    partial class Tweet
    {
        /// <summary>
        /// ツイートをいいねします。
        /// </summary>
        public void Favorite()
        {
            Parent?.Favorite(ID);
        }
        /// <summary>
        /// ツイートのいいねを解除します。
        /// </summary>
        public void Unfavorite()
        {
            Parent?.Unfavorite(ID);
        }
    }
}
