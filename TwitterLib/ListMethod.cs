using System.Collections.Generic;
using System;

namespace TwitterLib
{
    public partial class List
    {
        /// <summary>
        /// リストに登録されているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="includeEntities">Entitiesノードを含むかどうか</param>
        /// <param name="skipStatus">statusノードを省略するかどうか</param>
        /// <param name="cursor">カーソル</param>
        /// <returns></returns>
        public IEnumerable<User> GetMembers(int? count = null, bool? includeEntities = null, bool? skipStatus = null, ulong? cursor = null)
        {
            return (Parent ?? throw new InvalidOperationException("Parentプロパティがnullであるため、List.GetMembersメソッドを使用できません。")).GetMembersOfList(ID, count, includeEntities, skipStatus, cursor);
        }

        
    }

    public partial class Twitter
    {
        /// <summary>
        /// 指定されたリストに登録されているユーザーの一覧を取得します。
        /// </summary>
        /// <param name="listId">リストのID</param>
        /// <param name="count">1ページあたりのユーザー数</param>
        /// <param name="includeEntities">Entitiesノードを含むかどうか</param>
        /// <param name="skipStatus">statusノードを省略するかどうか</param>
        /// <param name="cursor">カーソル</param>
        /// <returns></returns>
        public IEnumerable<User> GetMembersOfList(ulong listId, int? count = null, bool? includeEntities = null, bool? skipStatus = null, ulong? cursor = null)
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
        public IEnumerable<User> GetMembersOfList(string ownerScreenName, string slug, int? count = null, bool? includeEntities = null, bool? skipStatus = null, ulong? cursor = null)
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
        public IEnumerable<User> GetMembersOfList(ulong ownerId, string slug, int? count = null, bool? includeEntities = null, bool? skipStatus = null, ulong? cursor = null)
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

        private IEnumerable<User> GetMembersOfList(SortedDictionary<string,string> args,ulong? cursor)
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
    }
}
