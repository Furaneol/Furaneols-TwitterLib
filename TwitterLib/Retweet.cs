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
        /// 指定されたIDのツイートをリツイートします。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tweet Retweet(ulong id)
        {
            return (Tweet)GetOAuthResponce("POST", "https://api.twitter.com/1.1/statuses/retweet/" + id + ".json", new SortedDictionary<string, string>() { ["id"] = id.ToString() }, typeof(Tweet));
        }
        /// <summary>
        /// 指定されたIDのリツイートを解除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Tweet Unretweet(ulong id)
        {
            return (Tweet)GetOAuthResponce("POST", "https://api.twitter.com/1.1/statuses/unretweet/" + id + ".json", new SortedDictionary<string, string>() { ["id"] = id.ToString() }, typeof(Tweet));
        }
    }

    partial class Tweet
    {
        /// <summary>
        /// 現在のツイートをリツイートします。
        /// </summary>
        /// <seealso cref="Twitter.Retweet(ulong)"/>
        public void Retweet()
        {
            Parent?.Retweet(ID);
        }
        /// <summary>
        /// 現在のツイートのリツイートを解除します。
        /// </summary>
        /// <seealso cref="Twitter.Unretweet(ulong)"/>
        public void UnRetweet()
        {
            Parent?.Unretweet(ID);
        }
    }
}
