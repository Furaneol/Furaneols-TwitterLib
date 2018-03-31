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
        public IEnumerable<ulong> GetFollowerIdList(int? count = null, long? cursor = null)
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
        public IEnumerable<User> GetFollowerList(int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, long? cursor = null)
        {
            return Parent.GetFollowerList(UserID, count, skipStatus, includeUserEntities, cursor);
        }
        /// <summary>
        /// 現在のユーザーがフォローしている人のID一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowIdList(int? count = null, long? cursor = null)
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
        public IEnumerable<User> GetFollowList(int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, long? cursor = null)
        {
            return Parent.GetFollowList(UserID, count, skipStatus, includeUserEntities, cursor);
        }
        /// <summary>
        /// 現在のユーザーをフォローします。
        /// </summary>
        /// <param name="notify"></param>
        public void Follow(bool? notify)
        {
            (Parent ?? throw new InvalidOperationException("Parentプロパティがnullのため、User.Followメソッドを使用する事はできません。")).Follow(UserID);
        }
        /// <summary>
        /// 現在のユーザーへのフォローを解除します。
        /// </summary>
        public void Unfollow()
        {
            (Parent ?? throw new InvalidOperationException("Parentプロパティがnullのため、User.Unfollowメソッドを使用する事はできません。")).Unfollow(UserID);
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
        public IEnumerable<ulong> GetFollowerIdList(ulong id, int? count = null, long? cursor = null)
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
        public IEnumerable<ulong> GetFollowerIdList(string screenName, int? count = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowerIdList(args, count, cursor);
        }

        private IEnumerable<ulong> getFollowerIdList(SortedDictionary<string, string> args, int? count, long? cursor)
        {
            if (count.HasValue)
                args["count"] = count.ToString();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/followers/ids.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
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
        public IEnumerable<User> GetFollowerList(ulong id, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, long? cursor = null)
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
        public IEnumerable<User> GetFollowerList(string screenName, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowerList(args, count, skipStatus, includeUserEntities, cursor);
        }

        private IEnumerable<User> getFollowerList(SortedDictionary<string, string> args, int? count, bool? skipStatus, bool? includeUserEntities, long? cursor)
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
                UserContainer container = (UserContainer)GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/followers/list.json", args, typeof(UserContainer));
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
        public IEnumerable<ulong> GetFollowIdList(ulong id, int? count = null, long? cursor = null)
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
        public IEnumerable<ulong> GetFollowIdList(string screenName, int? count = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowIdList(args, count, cursor);
        }

        private IEnumerable<ulong> getFollowIdList(SortedDictionary<string, string> args, int? count, long? cursor)
        {
            if (count.HasValue)
                args["count"] = count.ToString();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/friends/ids.json", args, typeof(IdContainer));
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
        public IEnumerable<User> GetFollowList(ulong id, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, long? cursor = null)
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
        public IEnumerable<User> GetFollowList(string screenName, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowList(args, count, skipStatus, includeUserEntities, cursor);
        }

        private IEnumerable<User> getFollowList(SortedDictionary<string, string> args, int? count, bool? skipStatus, bool? includeUserEntities, long? cursor)
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
                UserContainer container = (UserContainer)GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/friends/list.json", args, typeof(UserContainer));
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
        public IEnumerable<ulong> GetIncomingFriendship(long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "GET", "https://api.twitter.com/1.1/friendships/incoming.json", args, typeof(IdContainer));
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
        public IEnumerable<ulong> GetOutgoingFriendship(long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "GET", "https://api.twitter.com/1.1/friendships/outgoing.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        /// <summary>
        /// 1つ以上のスクリーン名を指定して現在のユーザーとの関係性を取得します。
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
            return (UserFriendship[])GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "GET", "https://api.twitter.com/1.1/friendships/lookup.json", args, typeof(UserFriendship[]));
        }
        /// <summary>
        /// 1つ以上のIDを指定して現在のユーザーとの関係性を取得します。
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
            return (UserFriendship[])GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "GET", "https://api.twitter.com/1.1/friendships/lookup.json", args, typeof(UserFriendship[]));
        }
        /// <summary>
        /// 現在のユーザーがリツイートの表示を止めているユーザーのID一覧を取得します。
        /// </summary>
        /// <returns></returns>
        public ulong[] GetNoRetweetUsers()
        {
            return (ulong[])GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "GET", "https://api.twitter.com/1.1/friendships/no_retweets/ids.json", new SortedDictionary<string, string>(), typeof(ulong[]));
        }
        #endregion

        #region User
        /// <summary>
        /// スクリーン名を指定してユーザー情報を取得します。
        /// </summary>
        /// <param name="screenNames">1以上100以下の長さを持つスクリーン名の配列</param>
        /// <param name="includeEntities">エンティティを含めるかどうか</param>
        /// <returns></returns>
        public User[] GetUsers(string[] screenNames, bool? includeEntities = null)
        {
            if (screenNames.Length == 0)
                return new User[] { };
            if (screenNames.Length > 100)
                throw new ArgumentException("100個以上のスクリーン名を指定することはできません。");
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = string.Join(",", screenNames) };
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            return (User[])GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/users/lookup.json", args, typeof(User[]));
        }
        /// <summary>
        /// IDを指定してユーザー情報を取得します。
        /// </summary>
        /// <param name="ids">1以上100以下の長さを持つIDの配列</param>
        /// <param name="includeEntities">エンティティ情報を含めるかどうか</param>
        /// <returns></returns>
        public User[] GetUsers(ulong[] ids, bool? includeEntities = null)
        {
            if (ids.Length == 0)
                return new User[] { };
            if (ids.Length > 100)
                throw new ArgumentException("100個以上のIDを指定することはできません。");
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = string.Join(",", ids) };
            return (User[])GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/users/lookup.json", args, typeof(User[]));
        }
        /// <summary>
        /// ユーザー検索を実行します。
        /// </summary>
        /// <param name="query">検索クエリ</param>
        /// <param name="count">1ページの件数</param>
        /// <param name="page">ページ番号</param>
        /// <param name="includeEntities">エンティティを含むかどうか</param>
        /// <returns></returns>
        public User[] SearchUser(string query, int? count = null, int? page = null, bool? includeEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["q"] = query };
            if (count.HasValue)
                args["count"] = count.ToString();
            if (page.HasValue)
                args["page"] = page.ToString();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            return (User[])GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/users/search.json", args, typeof(User[]));
        }
        /// <summary>
        /// 指定されたIDを持つユーザーの情報を取得します。
        /// </summary>
        /// <param name="id">取得するユーザーのID</param>
        /// <param name="includeEntities">エンティティ情報を含めるかどうか</param>
        /// <returns></returns>
        public User GetUser(ulong id, bool? includeEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            return (User)GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/users/show.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーの情報を取得します。
        /// </summary>
        /// <param name="screenName">取得するユーザーのスクリーン名</param>
        /// <param name="includeEntities">エンティティ情報を含めるかどうか</param>
        /// <returns></returns>
        public User GetUser(string screenName, bool? includeEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            return (User)GetOAuthResponce(AuthenticationMode, "GET", "https://api.twitter.com/1.1/users/show.json", args, typeof(User));
        }
        #endregion

        #region Follow
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーをフォローします。
        /// </summary>
        /// <param name="screenName">対象のスクリーン名</param>
        /// <param name="notifyToTargetUser">対象に通知を送るかどうか</param>
        /// <returns></returns>
        public User Follow(string screenName, bool? notifyToTargetUser = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            if (notifyToTargetUser.HasValue)
                args["follow"] = notifyToTargetUser.ToString().ToLower();
            return (User)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "POST", "https://api.twitter.com/1.1/friendships/create.json", args, typeof(User));
        }
        /// <summary>
        /// 指定されたIDを持つユーザーをフォローします。
        /// </summary>
        /// <param name="id">対象のユーザーID</param>
        /// <param name="notifyToTargetUser">対象に通知を送るかどうか</param>
        /// <returns></returns>
        public User Follow(ulong id, bool? notifyToTargetUser = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            if (notifyToTargetUser.HasValue)
                args["follow"] = notifyToTargetUser.ToString().ToLower();
            return (User)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "POST", "https://api.twitter.com/1.1/friendships/create.json", args, typeof(User));
        }
        #endregion

        #region Unfollow
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーへのフォローを解除します。
        /// </summary>
        /// <param name="screenName"></param>
        /// <returns></returns>
        public User Unfollow(string screenName)
        {
            return (User)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "POST", "https://api.twitter.com/1.1/friendships/destroy.json", new SortedDictionary<string, string>() { ["screen_name"] = screenName }, typeof(User));
        }
        /// <summary>
        /// 指定されたIDを持つユーザーへのフォローを解除します。
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User Unfollow(ulong userId)
        {
            return (User)GetOAuthResponce(TwitterAuthenticationMode.UserAuthentication, "POST", "https://api.twitter.com/1.1/friendships/destroy.json", new SortedDictionary<string, string>() { ["user_id"] = userId.ToString() }, typeof(User));
        }
        #endregion
    }
}
