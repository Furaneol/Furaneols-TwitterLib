using System;
using System.Collections.Generic;

namespace TwitterLib
{
    public partial class Twitter
    {
        /// <summary>
        /// 現在のユーザーがブロックしているユーザーのID一覧を取得します。
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<ulong> GetBlockIds(ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/blocks/ids.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        /// <summary>
        /// 現在のユーザーがブロックしているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerator<User> GetBlockUsers(ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                UserContainer container = (UserContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/blocks/list.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach (User user in container.Users)
                    yield return user;
            } while (cursor != 0);
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーをブロックします。
        /// </summary>
        /// <param name="screenName"></param>
        /// <param name="includeEntities"></param>
        /// <param name="skipStatus"></param>
        /// <returns></returns>
        public User Block(string screenName, bool? includeEntities = null, bool? skipStatus = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/blocks/create.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたIDを持つユーザーをブロックします。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeEntities"></param>
        /// <param name="skipStatus"></param>
        /// <returns></returns>
        public User Block(ulong id, bool? includeEntities = null, bool? skipStatus = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/blocks/create.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーに対する現在のユーザーからのブロックを解除します。
        /// </summary>
        /// <param name="screenName"></param>
        /// <param name="includeEntities"></param>
        /// <param name="skipStatus"></param>
        /// <returns></returns>
        public User Unblock(string screenName, bool? includeEntities = null, bool? skipStatus = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_statu"] = skipStatus.ToString().ToLower();
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/blocks/destroy.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたIDを持つユーザーに対する現在のユーザーからのブロックを解除します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeEntities"></param>
        /// <param name="skipStatus"></param>
        /// <returns></returns>
        public User Unblock(ulong id, bool? includeEntities = null, bool? skipStatus = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            return (User)GetOAuthResponce("POST", "https://api.twitter.com/1.1/blocks/destroy.json", args, typeof(User));
        }
    }

    public partial class User
    {

    }
}
