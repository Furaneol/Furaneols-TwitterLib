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
        public IEnumerator<ulong> GetFollowerIdList(ulong? cursor = null, int? count = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string> { ["user_id"] = UserID.ToString() };
            if (count.HasValue)
                args["count"] = count.ToString();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)Parent.GetOAuthResponce("GET", "https://api.twitter.com/1.1/followers/ids.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        /// <summary>
        /// 現在のユーザーをフォローしている人(フォロワー)の一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="skipStatus">ステータス情報を省略するかどうか</param>
        /// <param name="includeUserEntities"></param>
        /// <returns></returns>
        public IEnumerator<User> GetFollowerList(ulong? cursor = null, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = UserID.ToString() };
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
                UserContainer container = (UserContainer)Parent.GetOAuthResponce("GET", "https://api.twitter.com/1.1/followers/list.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach(User user in container.Users)
                    yield return user;
            } while (cursor != 0);
        }
        /// <summary>
        /// 現在のユーザーがフォローしている人のID一覧を取得します。
        /// </summary>
        /// <param name="cursor">読み込み開始ページの番号(null=最初のページ)</param>
        /// <param name="count">1ページあたりのID数</param>
        /// <returns></returns>
        public IEnumerator<ulong> GetFollowIdList(ulong? cursor = null, int? count = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = UserID.ToString() };
            if (count.HasValue)
                args["count"] = count.ToString();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                IdContainer container = (IdContainer)Parent.GetOAuthResponce("GET", "https://api.twitter.com/1.1/friends/ids.json", args, typeof(IdContainer));
                cursor = container.NextCursor;
                foreach (ulong id in container.IDList)
                    yield return id;
            } while (cursor != 0);
        }
        /// <summary>
        /// 現在のユーザーがフォローしている人の一覧を取得します。
        /// </summary>
        /// <param name="cursor"></param>
        /// <param name="count"></param>
        /// <param name="skipStatus"></param>
        /// <param name="includeUserEntities"></param>
        /// <returns></returns>
        public IEnumerator<User> GetFollowList(ulong? cursor = null, int? count = null, bool? skipStatus = null, bool? includeUserEntities = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = UserID.ToString() };
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
                UserContainer container = (UserContainer)Parent.GetOAuthResponce("GET", "https://api.twitter.com/1.1/friends/list.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach (User user in container.Users)
                    yield return user;
            } while (cursor != 0);
        }
    }
}
