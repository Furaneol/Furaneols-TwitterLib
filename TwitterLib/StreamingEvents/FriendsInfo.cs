using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// ユーザーストリームの接続確立時に送信されるユーザーのフォローリストです。
    /// </summary>
    public class FriendsInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.FriendsList;
        public override Twitter Parent { get; internal set; }

        internal FriendsInfo(Twitter parent, ulong[] list)
        {
            Parent = parent;
            FriendsIdList = list;
        }
        /// <summary>
        /// フォローしているユーザーIDの一覧を取得します。
        /// </summary>
        public ulong[] FriendsIdList { get; }
    }
}
