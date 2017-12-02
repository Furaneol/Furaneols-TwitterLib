using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// 認証ユーザーとの関係性を示す情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class UserFriendship
    {
        /// <summary>
        /// 対象ユーザーの名前を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        /// <summary>
        /// 対象ユーザーのスクリーン名を取得します。
        /// </summary>
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; private set; }
        /// <summary>
        /// 対象ユーザーのIDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong UserID { get; private set; }
        /// <summary>
        /// 関係性を示す値を取得します。
        /// </summary>
        [DataMember(Name = "connections")]
        public string[] Connection { get; private set; }
    }
}
