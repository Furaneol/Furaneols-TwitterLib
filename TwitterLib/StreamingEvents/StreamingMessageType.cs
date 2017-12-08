using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// Streaming APIからの応答内容を示す値です。
    /// </summary>
    public enum StreamingMessageType
    {
        /// <summary>
        /// クライアント側が通信切断したと誤認しないように送信される空白行です。この値が指定された場合、詳細情報はありません。
        /// </summary>
        KeepAlive,
        /// <summary>
        /// ツイートオブジェクトです。Tweetクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        TweetContent,
        /// <summary>
        /// ツイートの削除通知です。TweetDeleteInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        TweetDeleted,
        /// <summary>
        /// 位置情報の削除通知です。GeoDeleteInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        ScrubGeo,
        /// <summary>
        /// 配信されなかったツイートがある事を示す通知情報です。
        /// </summary>
        Limit,
        /// <summary>
        /// ツイートに対する閲覧制限の通知です。WithheldStatusInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        WithheldStatus,
        /// <summary>
        /// ユーザーに対する閲覧制限の通知です。WithheldUserInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        WithheldUser,
        /// <summary>
        /// 通信切断の通知です。DisconnectionInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        Disconnect,
        /// <summary>
        /// ストリームからの警告通知です。WarningInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        Warnings,
        /// <summary>
        /// ユーザーストリームにおいて接続確立時に送信されるフレンドリストです。FriendsInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        FriendsList,
        /// <summary>
        /// イベント通知です。EventInfoクラスにキャストすることで詳細情報を取得できます。
        /// </summary>
        Events,
        /// <summary>
        /// 認識できないメッセージです。
        /// </summary>
        Unknown
    }
}
