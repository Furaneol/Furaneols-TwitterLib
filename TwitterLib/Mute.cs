using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// 現在のユーザーがミュート中のユーザーのID一覧を取得します。
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<ulong> GetMuteIds(ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/mutes/users/ids.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        /// <summary>
        /// 現在のユーザーがミュート中のユーザーの一覧を取得します。
        /// </summary>
        /// <param name="includeEntities"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<User> GetMuteUsers(bool? includeEntities = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                UserContainer container = (UserContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/mutes/users/list.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach (User user in container.Users)
                    yield return user;
            } while (cursor != 0);
        }
        /// <summary>
        /// 指定されたスクリーン名のユーザーをミュートします。
        /// </summary>
        /// <param name="screenName"></param>
        /// <returns></returns>
        public User Mute(string screenName)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/mutes/users/create.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたIDのユーザーをミュートします。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Mute(ulong id)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString()]};
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/mutes/users/create.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたスクリーン名のユーザーに対するミュートを解除します。
        /// </summary>
        /// <param name="screenName"></param>
        /// <returns></returns>
        public User Unmute(string screenName)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/mutes/users/destroy.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたIDのユーザーに対するミュートを解除します。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User Unmute(ulong id)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/mutes/users/destroy.json", args, typeof(User));
        }
    }

    public partial class User
    {
        /// <summary>
        /// ユーザーをミュートします。
        /// </summary>
        public void Mute()
        {
            Parent.Mute(UserID);
        }
        /// <summary>
        /// ユーザーに対するミュートを解除します。
        /// </summary>
        public void Unmute()
        {
            Parent.Unmute(UserID);
        }
    }
}
