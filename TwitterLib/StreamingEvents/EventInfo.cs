using System;
using System.Runtime.Serialization;

namespace TwitterLib.StreamingEvents
{
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
        /// <summary>
        /// ツイートを対象としたイベントであるかどうかを示す値を取得します。
        /// </summary>
        public virtual bool HasTargetTweet => false;
        /// <summary>
        /// リストを対象としたイベントであるかどうかを示す値を取得します。
        /// </summary>
        public virtual bool HasTargetList => false;
    }
    /// <summary>
    /// ツイートを対象としたイベントの情報オブジェクトです。
    /// </summary>
    [DataContract]
    public sealed class TweetEventInfo : EventInfo
    {
        /// <summary>
        /// 対象のツイートを取得します。
        /// </summary>
        [DataMember(Name = "target_object")]
        public Tweet TargetedTweet { get; private set; }
        /// <summary>
        /// ツイートを対象としたイベントであるかどうかを示す値を取得します。
        /// </summary>
        public override bool HasTargetTweet => true;
    }
    /// <summary>
    /// リストを対象としたイベント情報のオブジェクトです。
    /// </summary>
    [DataContract]
    public sealed class ListEventInfo : EventInfo
    {
        /// <summary>
        /// 対象となったリストの情報を取得します。
        /// </summary>
        [DataMember(Name ="target_object")]
        public TwitterList TargetList { get; private set; }
        /// <summary>
        /// リストを対象としたイベントであるかどうかを示す値を取得します。
        /// </summary>
        public override bool HasTargetList => true;
    }
}
