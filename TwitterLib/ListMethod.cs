using System.Collections.Generic;

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
            SortedDictionary<string, string> args = new SortedDictionary<string, string>() { ["list_id"] = ID.ToString() };
            if (count.HasValue)
                args["count"] = count.ToString();
            if (includeEntities.HasValue)
                args["include_entities"] = includeEntities.ToString().ToLower();
            if (skipStatus.HasValue)
                args["skip_status"] = skipStatus.ToString().ToLower();
            do
            {
                if (cursor.HasValue)
                    args["cursor"] = cursor.ToString();
                UserContainer container = (UserContainer)Parent.GetOAuthResponce("GET", "https://api.twitter.com/1.1/lists/members.json", args, typeof(UserContainer));
                cursor = container.NextCursor;
                foreach (User user in container.Users)
                    yield return user;
            } while (cursor != 0);
        }

        
    }

    public partial class Twitter
    {

    }
}
