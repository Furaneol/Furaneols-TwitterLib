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
        /// <see cref="https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-followers-ids"/>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowerIdList(ulong? cursor = null, int? count = null)
        {
            return Parent.GetFollowerIdList(UserID, cursor, count);
        }
        /// <summary>
        /// 現在のユーザーをフォローしている人(フォロワー)の一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="skipStatus">ステータス情報を省略するかどうか</param>
        /// <param name="includeUserEntities"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowerList(ulong? cursor = null, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null)
        {
            return Parent.GetFollowerList(UserID, cursor, count, skipStatus, includeUserEntities);
        }
        /// <summary>
        /// 現在のユーザーがフォローしている人のID一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowIdList(ulong? cursor = null, int? count = null)
        {
            
        }
        /// <summary>
        /// 現在のユーザーがフォローしている人の一覧を取得します。
        /// </summary>
        /// <param name="cursor"></param>
        /// <param name="count"></param>
        /// <param name="skipStatus"></param>
        /// <param name="includeUserEntities"></param>
        /// <returns></returns>
        public IEnumerable<User> GetFollowList(ulong? cursor = null, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null)
        {

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
        public IEnumerable<ulong> GetFollowerIdList(ulong id, ulong? cursor = null, int? count = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            return getFollowerIdList(args, cursor, count);
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーのフォロワーのID一覧を取得します。
        /// </summary>
        /// <param name="screenName">対象のスクリーン名</param>
        /// <param name="cursor">読み込み始めるページ(null:先頭のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerable<ulong> GetFollowerIdList(string screenName, ulong? cursor = null, int? count = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowerIdList(args, cursor, count);
        }

        private IEnumerable<ulong> getFollowerIdList(SortedDictionary<string, string> args, ulong? cursor, int? count)
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
        public IEnumerable<User> GetFollowerList(ulong id, ulong? cursor = null, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = id.ToString() };
            return getFollowerList(args, cursor, count, skipStatus, includeUserEntities);
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
        public IEnumerable<User> GetFollowerList(string screenName, ulong? cursor = null, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            return getFollowerList(args, cursor, count, skipStatus, includeUserEntities);
        }

        private IEnumerable<User> getFollowerList(SortedDictionary<string, string> args, ulong? cursor, int? count, bool? skipStatus, bool? includeUserEntities)
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
    }
}
