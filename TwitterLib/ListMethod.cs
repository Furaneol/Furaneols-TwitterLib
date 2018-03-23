using System.Collections.Generic;
using System;
using System.Net;

namespace TwitterLib
{
    public partial class List
    {
        /// <summary>
        /// リストに登録されているユーザーの一覧を取得します。
        /// </summary>
        /// <seealso cref="Twitter.GetMembersOfList(ulong, int?, bool?, bool?, long?)"/>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="includeEntities">Entitiesノードを含むかどうか</param>
        /// <param name="skipStatus">statusノードを省略するかどうか</param>
        /// <param name="cursor">カーソル</param>
        /// <returns></returns>
        public IEnumerable<User> GetMembers(int? count = null, bool? includeEntities = null, bool? skipStatus = null, long? cursor = null)
        {
            return (Parent ?? throw new InvalidOperationException("Parentプロパティがnullであるため、List.GetMembersメソッドを使用できません。")).GetMembersOfList(ID, count, includeEntities, skipStatus, cursor);
        }
        /// <summary>
        /// リストに登録されているユーザーのツイート一覧を取得します。
        /// </summary>
        /// <param name="sinceId"></param>
        /// <param name="maxId"></param>
        /// <param name="count"></param>
        /// <param name="includeEntities"></param>
        /// <param name="includeRetweets"></param>
        /// <returns></returns>
        public Tweet[] GetTweets(ulong? sinceId = null, ulong? maxId = null, int? count = null, bool? includeEntities = null, bool? includeRetweets = null)
        {
            if (Parent == null)
                throw new InvalidOperationException("Parentプロパティがnullであるため、List.GetTweetsメソッドを使用出来ません。");
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["list_id"] = ID.ToString() };
            if (sinceId.HasValue)
                args["since_id"] = sinceId.ToString();
            if (maxId.HasValue)
                args["max_id"] = maxId.ToString();
            if (count.HasValue)
                args["count"] = count.ToString();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (includeRetweets.HasValue)
                args["include_rts"] = includeRetweets.ToString().ToLower();
            return (Tweet[])Parent.GetOAuthResponce("GET", "https://api.twitter.com/1.1/lists/statuses.json", args, typeof(Tweet[]));
        }
    }

    public partial class Twitter
    {
        #region GetMembersOfList
        /// <summary>
        /// 指定されたリストに登録されているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="listId">リストのID</param>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="includeEntities">Entitiesノードを含むかどうか</param>
        /// <param name="skipStatus">statusノードを省略するかどうか</param>
        /// <param name="cursor">カーソル</param>
        /// <returns></returns>
        public IEnumerable<User> GetMembersOfList(ulong listId, int? count = null, bool? includeEntities = null, bool? skipStatus = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["list_id"] = listId.ToString() };
            if (count.HasValue)
                args["count"] = count.ToString();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            return GetMembersOfList(args, cursor);
        }
        /// <summary>
        /// 指定されたリストに登録されているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="ownerScreenName">所有者のスクリーン名</param>
        /// <param name="slug">スラグ</param>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="includeEntities">Entitiesノードを含むかどうか</param>
        /// <param name="skipStatus">statusノードを省略するかどうか</param>
        /// <param name="cursor">カーソル</param>
        /// <returns></returns>
        public IEnumerable<User> GetMembersOfList(string ownerScreenName, string slug, int? count = null, bool? includeEntities = null, bool? skipStatus = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>()
            {
                ["owner_screen_name"] = ownerScreenName,
                ["slug"] = slug
            };
            if (count.HasValue)
                args["count"] = count.ToString();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            return GetMembersOfList(args, cursor);
        }
        /// <summary>
        /// 指定されたリストに登録されているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="ownerId">所有者の固有ID</param>
        /// <param name="slug">スラグ</param>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="includeEntities">Entitiesノードを含むかどうか</param>
        /// <param name="skipStatus">statusノードを省略するかどうか</param>
        /// <param name="cursor">カーソル</param>
        /// <returns></returns>
        public IEnumerable<User> GetMembersOfList(ulong ownerId, string slug, int? count = null, bool? includeEntities = null, bool? skipStatus = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>()
            {
                ["owner_id"] = ownerId.ToString(),
                ["slug"] = slug
            };
            if (count.HasValue)
                args["count"] = count.ToString();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            return GetMembersOfList(args, cursor);
        }

        private IEnumerable<User> GetMembersOfList(SortedDictionary<string,string> args,long? cursor)
        {
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                UserContainer container = (UserContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/lists/members.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach (User user in container.Users)
                    yield return user;
            } while (cursor != 0);
        }
        #endregion

        #region GetRegesteredList
        /// <summary>
        /// 指定されたIDを持つユーザーがメンバーとして登録されているリストの一覧を取得します。
        /// </summary>
        /// <param name="userId">ユーザーのID</param>
        /// <param name="count">1ページ毎の件数</param>
        /// <param name="cursor">開始カーソル</param>
        /// <returns></returns>
        public IEnumerable<List> GetRegesteredList(ulong userId, int? count = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["user_id"] = userId.ToString() };
            if (count.HasValue)
                args["count"] = count.ToString();
            return GetRegesteredList(args, cursor);
        }
        /// <summary>
        /// 指定されたスクリーン名を持つユーザーがメンバーとして登録されているリストの一覧を取得します。
        /// </summary>
        /// <param name="screenName">スクリーン名</param>
        /// <param name="count">1ページ毎の件数</param>
        /// <param name="cursor">開始カーソル</param>
        /// <returns></returns>
        public IEnumerable<List> GetRegesteredList(string screenName, int? count = null, long? cursor = null)
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["screen_name"] = screenName };
            if (count.HasValue)
                args["count"] = count.ToString();
            return GetRegesteredList(args, cursor);
        }

        private IEnumerable<List> GetRegesteredList(SortedDictionary<string, string> args, long? cursor)
        {
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                ListContainer container = (ListContainer)GetOAuthResponce("GET", "https://api.twitter.com/1.1/lists/memberships.json", args, typeof(ListContainer));
                cursor = container.NextCursor;
                foreach (List list in container.Lists)
                    yield return list;
            } while (cursor != 0);
        }
        #endregion
    }
}
