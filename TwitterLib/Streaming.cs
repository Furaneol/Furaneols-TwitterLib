using System.Runtime.Serialization;
using System;

namespace TwitterLib
{
    /// <summary>
    /// Twitter Streaming APIの応答情報である事を示します。
    /// </summary>
    [DataContract]
    public abstract class StreamingMessage : ApiResponce
    {
        public abstract StreamingMessageType MessageType { get; }
        /// <summary>
        /// 応答があった時刻を取得します。
        /// </summary>
        public DateTime TimeStamp { get; private set; }

        [DataMember(Name = "timestamp_ms")]
        private string timeStamp
        {
            get { return (TimeStamp - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds.ToString(); }
            set { TimeStamp = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(double.Parse(value)); }
        }
    }
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
    /// <summary>
    /// 通信切断が起こっていない事を示す情報オブジェクトです。このオブジェクトに格納される追加情報はありません。
    /// </summary>
    public class KeepAlive : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.KeepAlive;
        public override Twitter Parent { get; internal set; }
    }
    /// <summary>
    /// ツイートが削除されたことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class TweetDeleteInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.TweetDeleted;
        public override Twitter Parent { get; internal set; }
        #region private class
        [DataContract]
        class StatusNode
        {
            [DataMember(Name = "id")]
            public ulong ID { get; private set; }
            [DataMember(Name = "user_id")]
            public ulong UserID { get; private set; }
        }
        #endregion

        private StatusNode status;
        /// <summary>
        /// 削除されたツイートのIDを取得します。
        /// </summary>
        public ulong ID { get => status?.ID ?? 0; }
        /// <summary>
        /// 削除されたツイートを投稿したユーザーのIDを取得します。
        /// </summary>
        public ulong UserID { get => status?.UserID ?? 0; }
    }
    /// <summary>
    /// 位置情報が削除されたことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class ScrubGeoInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.ScrubGeo;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 位置情報を削除したユーザーIDを取得します。
        /// </summary>
        [DataMember(Name = "user_id")]
        public ulong UserID { get; private set; }
        /// <summary>
        /// 削除の起点となるツイートのIDを取得します。
        /// </summary>
        [DataMember(Name = "up_to_status_id")]
        public ulong UpToStatusID { get; private set; }
    }
    /// <summary>
    /// 配信されなかったツイートが存在する事を示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class SpeedLimitInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.Limit;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 接続開始から現在までに配信されなかったツイートの数を取得します。
        /// </summary>
        [DataMember(Name = "track")]
        public int Track { get; private set; }
    }
    /// <summary>
    /// ツイートの閲覧が制限されたことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class StatusWithheldInfo
    {
        /// <summary>
        /// 制限されたツイートのIDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong ID { get; private set; }
        /// <summary>
        /// 当該ツイートを投稿したユーザーのIDを取得します。
        /// </summary>
        [DataMember(Name ="user_id")]
        public ulong UserID { get; private set; }
        /// <summary>
        /// 閲覧制限を行った国を示すコードの一覧を取得します。
        /// </summary>
        [DataMember(Name = "withheld_in_countries")]
        public string[] Countries { get; private set; }
    }
    /// <summary>
    /// ユーザーの情報およびツイートの閲覧が制限されたことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class UserWithheldInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.WithheldUser;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 閲覧制限を受けたユーザーのIDを取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public ulong UserID { get; private set; }
        /// <summary>
        /// 閲覧制限を行った国を示すコードの一覧を取得します。
        /// </summary>
        [DataMember(Name = "user_withheld")]
        public string[] Countries { get; private set; }
    }
    /// <summary>
    /// ストリームが切断したことを示す情報オブジェクトです。
    /// </summary>
    [DataContract]
    public class DisconnectionInfo:StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.Disconnect;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// ステータスコードを取得します。
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; private set; }
        /// <summary>
        /// 切断されたストリームの名前を取得します。
        /// </summary>
        [DataMember(Name = "stream_name")]
        public string StreamName { get; private set; }
        /// <summary>
        /// 切断理由を説明する文字列を取得します。
        /// </summary>
        [DataMember(Name ="reason")]
        public string Reason { get; private set; }

    }
    /// <summary>
    /// ストリームから警告を受けていることを示すオブジェクトです。
    /// </summary>
    [DataContract]
    public class WarningInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.Warnings;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// 状態を示すコード文字列を取得します。
        /// </summary>
        [DataMember(Name ="code")]
        public string Code { get; private set; }
        /// <summary>
        /// メッセージを取得します。
        /// </summary>
        [DataMember(Name ="message")]
        public string Message { get; private set; }
    }
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
    /// <summary>
    /// このライブラリでサポートされていないメッセージの情報オブジェクトです。
    /// </summary>
    public class UnknownMessage : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.Unknown;
        public override Twitter Parent { get; internal set; }

        internal UnknownMessage(Twitter parent,string content)
        {
            Parent = parent;
            ResponceContent = content;
        }
        /// <summary>
        /// 解釈に失敗したコンテンツの内容を取得します。
        /// </summary>
        public string ResponceContent { get; }
    }
    /// <summary>
    /// イベントの情報オブジェクトの基本クラスです。
    /// </summary>
    [DataContract]
    public class EventInfo : StreamingMessage
    {
        public override StreamingMessageType MessageType => StreamingMessageType.Events;
        public override Twitter Parent { get; internal set; }
        /// <summary>
        /// イベントの名前を取得します。
        /// </summary>
        [DataMember(Name = "event")]
        public string EventName { get; private set; }
        /// <summary>
        /// イベントの発生日時を取得します。
        /// </summary>
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; private set; }
        /// <summary>
        /// イベントの対象のユーザーを取得します。
        /// </summary>
        [DataMember(Name = "target")]
        public User TargetUser { get; private set; }
        /// <summary>
        /// イベントを発生させたユーザーを取得します。
        /// </summary>
        [DataMember(Name = "source")]
        public User SourceUser { get; private set; }
    }
    [DataContract]
    public class TweetEventInfo : EventInfo
    {
        /// <summary>
        /// 対象のツイートを取得します。
        /// </summary>
        [DataMember(Name ="target_object")]
        public Tweet TargetedTweet { get; private set; }
    }
    /// <summary>
    /// ストリーミングメッセージの内容を判別する為の汎用デシリアライザです。
    /// </summary>
    [DataContract]
    internal class StreamingContract
    {
        [DataMember(Name ="delete")]
        public TweetDeleteInfo Delete { get; private set; }

        [DataMember(Name ="scrub_geo")]
        public ScrubGeoInfo ScrubGeo { get; private set; }

        [DataMember(Name ="limit")]
        public SpeedLimitInfo Limit { get; private set; }

        [DataMember(Name ="status_withheld")]
        public StatusWithheldInfo StatusWithheld { get; private set; }

        [DataMember(Name ="user_withheld")]
        public UserWithheldInfo UserWithheld { get; private set; }

        [DataMember(Name ="disconnect")]
        public DisconnectionInfo disconnection { get; private set; }

        [DataMember(Name ="warning")]
        public WarningInfo warning { get; private set; }

        [DataMember(Name = "events")]
        public string EventName { get; private set; }
    }
}
