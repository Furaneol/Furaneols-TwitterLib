using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TwitterLib
{
    public partial class User
    {
        /// <summary>
        /// 現在のユーザーをフォローしている人(フォロワー)のユーザーID一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowerIdList(int? count = null, ulong? cursor = null)
        {
            return Parent.GetFollowerIdList(UserID, count, cursor);
        }
        /// <summary>
        /// 現在のユーザーをフォローしている人(フォロワー)の一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="skipStatus">ステータス情報を省略するかどうか</param>
        /// <param name="includeUserEntities"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowerList(int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, ulong? cursor = null)
        {
            return Parent.GetFollowerList(UserID, count, skipStatus, includeUserEntities, cursor);
        }
        /// <summary>
        /// 現在のユーザーがフォローしている人のID一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowIdList(int? count = null, ulong? cursor = null)
        {
            return Parent.GetFollowIdList(UserID, count, cursor);
        }
        /// <summary>
        /// 現在のユーザーがフォローしている人の一覧を取得します。
        /// </summary>
        /// <param name="count"></param>
        /// <param name="skipStatus"></param>
        /// <param name="includeUserEntities"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowList(int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, ulong? cursor = null)
        {
            return Parent.GetFollowList(UserID, count, skipStatus, includeUserEntities, cursor);
        }
    }

    public partial class Twitter
    {
        #region GetFollowerIdList
        /// <summary>
        /// 指定されたIDを持つユーザーのフォロワーのID一覧を取得します。
        /// </summary>
        /// <param name="id">対象のユーザーID</param>
        /// <param name="cursor">読み込み始めるページ(null:先頭のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowerIdList(ulong id, int? count = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            return getFollowerIdList(args, count, cursor);
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーのフォロワーのID一覧を取得します。
        /// </summary>
        /// <param name="screenName">対象のスクリーン名</param>
        /// <param name="cursor">読み込み始めるページ(null:先頭のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowerIdList(string screenName, int? count = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowerIdList(args, count, cursor);
        }

        private IEnumerable<ulong> getFollowerIdList(SortedDictionary<string, string> args, int? count, ulong? cursor)
        {
            if (count.HasValue)
                args["count"] = count.ToString();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/followers/ids.json", args, typeof(IdContainer));
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        #endregion

        #region GetFollowerList
        /// <summary>
        /// 指定されたIDを持つユーザーのフォロワー一覧を取得します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cursor"></param>
        /// <param name="count"></param>
        /// <param name="skipStatus"></param>
        /// <param name="includeUserEntities"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowerList(ulong id, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            return getFollowerList(args, count, skipStatus, includeUserEntities, cursor);
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーのフォロワー一覧を取得します。
        /// </summary>
        /// <param name="screenName"></param>
        /// <param name="cursor"></param>
        /// <param name="count"></param>
        /// <param name="skipStatus"></param>
        /// <param name="includeUserEntities"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowerList(string screenName, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowerList(args, count, skipStatus, includeUserEntities, cursor);
        }

        private IEnumerable<User> getFollowerList(SortedDictionary<string, string> args, int? count, bool? skipStatus, bool? includeUserEntities, ulong? cursor)
        {
            if (count.HasValue)
                args["count"] = count.ToString();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            if (includeUserEntities.HasValue)
                args["include_user_entities"] = includeUserEntities.ToString().ToLower();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                UserContainer container = (UserContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/followers/list.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach (User user in container.Users)
                    yield return user;
            } while (cursor != 0);
        }
        #endregion

        #region GetFollowIdList
        /// <summary>
        /// 指定されたIDを持つユーザーがフォローしているアカウントのID一覧を取得します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowIdList(ulong id, int? count = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            return getFollowIdList(args, count, cursor);
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーがフォローしているアカウントのID一覧を取得します。
        /// </summary>
        /// <param name="screenName"></param>
        /// <param name="count"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowIdList(string screenName, int? count = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowIdList(args, count, cursor);
        }

        private IEnumerable<ulong> getFollowIdList(SortedDictionary<string, string> args, int? count, ulong? cursor)
        {
            if (count.HasValue)
                args["count"] = count.ToString();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/friends/ids.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        #endregion

        #region GetFollowList
        /// <summary>
        /// 指定されたIDを持つユーザーがフォローしているアカウントの一覧を取得します。
        /// </summary>
        /// <param name="id"></param>
        /// <param name="count"></param>
        /// <param name="skipStatus"></param>
        /// <param name="includeUserEntities"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowList(ulong id, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            return getFollowList(args, count, skipStatus, includeUserEntities, cursor);
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーがフォローしているアカウントの一覧を取得します。
        /// </summary>
        /// <param name="screenName"></param>
        /// <param name="count"></param>
        /// <param name="skipStatus"></param>
        /// <param name="includeUserEntities"></param>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowList(string screenName, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowList(args, count, skipStatus, includeUserEntities, cursor);
        }

        private IEnumerable<User> getFollowList(SortedDictionary<string, string> args, int? count, bool? skipStatus, bool? includeUserEntities, ulong? cursor)
        {
            if (count.HasValue)
                args["count"] = count.ToString();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            if (includeUserEntities.HasValue)
                args["include_user_entities"] = includeUserEntities.ToString().ToLower();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                UserContainer container = (UserContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/friends/list.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach (User user in container.Users)
                    yield return user;

            } while (cursor != 0);
        }
        #endregion

        #region Friendship
        /// <summary>
        /// 認証ユーザーが保留している、フォローを希望しているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<ulong> GetIncomingFriendship(ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/friendships/incoming.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        /// <summary>
        /// 認証ユーザーが保留されている、フォローをリクエストしているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="cursor"></param>
        /// <returns></returns>
        public IEnumerable<ulong> GetOutgoingFriendship(ulong? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/friendships/outgoing.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        /// <summary>
        /// 1つ以上のスクリーン名を指定して関係性を取得します。
        /// </summary>
        /// <param name="screenNames">1個以上100個以下のスクリーン名</param>
        /// <returns></returns>
        public UserFriendship[] GetFriendships(params string[] screenNames)
        {
            if (screenNames.Length == 0)
                return new UserFriendship[] { };
            if (screenNames.Length > 100)
                throw new ArgumentException("100個以上のスクリーン名を指定することはできません。");
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = string.Join(",", screenNames) };
            return (UserFriendship[])GetOAuthResponce("GET", "https://api.twitter.com/1.1/friendships/lookup.json", args, typeof(UserFriendship[]));
        }
        /// <summary>
        /// 1つ以上のIDを指定して関係性を取得します。
        /// </summary>
        /// <param name="ids">1個以上100個以下のID</param>
        /// <returns></returns>
        public UserFriendship[] GetFriendships(params ulong[] ids)
        {
            if (ids.Length == 0)
                return new UserFriendship[] { };
            if (ids.Length > 100)
                throw new ArgumentException("100個以上のIDを指定することはできません。");
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = string.Join(",", ids) };
            return (UserFriendship[])GetOAuthResponce("GET", "https://api.twitter.com/1.1/friendships/lookup.json", args, typeof(UserFriendship[]));
        }
        #endregion
    }
}
