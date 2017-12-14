using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// APIの使用回数・上限値およびリセット時刻を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class RateLimitStatus : ApiResponce
    {
        /// <summary>
        /// 使用回数の上限を取得します。
        /// </summary>
        [DataMember(Name = "limit")]
        public int Maximum { get; private set; }
        /// <summary>
        /// 残り使用可能回数を取得します。
        /// </summary>
        [DataMember(Name = "remaining")]
        public int RemainingCount { get; private set; }

        [DataMember(Name = "reset")]
        private int ResetTimeSeconds
        {
            get { return (int)(ResetTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds; }
            set { ResetTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value); }
        }
        /// <summary>
        /// 残り使用回数のリセット時刻を取得します。
        /// </summary>
        public DateTime ResetTime { get; private set; }
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }
    }
    /// <summary>
    /// application/rate_limit_status.jsonからの応答情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class RateLimitStatusContainer : ApiResponce
    {
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }

        [DataMember(Name = "resources")]
        private Resources resources;

        /// <summary>
        /// ListカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public ListRateLimit Lists { get => resources.ListLimit; }
        /// <summary>
        /// ApplicationカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public ApplicationRateLimit Application { get => resources.AppLimit; }
        /// <summary>
        /// MutesカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public MuteRateLimit Mutes { get => resources.MuteLimit; }
        /// <summary>
        /// Live Video StreamカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public LiveVideoStreamRateLimit LiveVideoStream { get => resources.LiveLimit; }
        /// <summary>
        /// FriendshipカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public FriendshipRateLimit Friendship { get => resources.FriendshipLimit; }
        /// <summary>
        /// GuideカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public GuideRateLimit Guide { get => resources.GuideLimit; }
        /// <summary>
        /// AuthカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public AuthRateLimit Auth { get => resources.AuthLimit; }
        /// <summary>
        /// BlockカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public BlockRateLimit Block { get => resources.BlockLimit; }
        /// <summary>
        /// GeoカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public GeoRateLimit Geo { get => resources.GeoLimit; }
        /// <summary>
        /// UsersカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public UserRateLimit User { get => resources.UserLimit; }
        /// <summary>
        /// FollowersカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public FollowersRateLimit Follower { get => resources.FollowerLimit; }
        /// <summary>
        /// CollectionsカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public CollectionsRateLimit Collection { get => resources.CollectionLimit; }
        /// <summary>
        /// Custom ProfilesカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public CustomProfileRateLimit CustomProfiles { get => resources.CustomProfiles; }
        /// <summary>
        /// WebhooksカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public WebhookRateLimit Webhooks { get => resources.Webhooks; }
        /// <summary>
        /// ContactsカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public ContactRateLimit Contacts { get => resources.Contacts; }
        /// <summary>
        /// Tweet PromptsカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public TweetPromptRateLimit TweetPrompts { get => resources.TweetPrompts; }
        /// <summary>
        /// MomentsカテゴリのREST APIの使用回数制限を取得します。
        /// </summary>
        public MomentRateLimit Moments { get => resources.Moment; }
        [DataContract]
        class Resources
        {
            [DataMember(Name = "lists")]
            public ListRateLimit ListLimit { get; private set; }

            [DataMember(Name ="application")]
            public ApplicationRateLimit AppLimit { get; private set; }

            [DataMember(Name = "mutes")]
            public MuteRateLimit MuteLimit { get; private set; }

            [DataMember(Name = "live_video_stream")]
            public LiveVideoStreamRateLimit LiveLimit { get; private set; }

            [DataMember(Name ="friendships")]
            public FriendshipRateLimit FriendshipLimit { get; private set; }

            [DataMember(Name ="guide")]
            public GuideRateLimit GuideLimit { get; private set; }

            [DataMember(Name ="auth")]
            public AuthRateLimit AuthLimit { get; private set; }

            [DataMember(Name ="blocks")]
            public BlockRateLimit BlockLimit { get; private set; }

            [DataMember(Name = "geo")]
            public GeoRateLimit GeoLimit { get; private set; }

            [DataMember(Name ="users")]
            public UserRateLimit UserLimit { get; private set; }

            [DataMember(Name ="followers")]
            public FollowersRateLimit FollowerLimit { get; private set; }

            [DataMember(Name ="collections")]
            public CollectionsRateLimit CollectionLimit { get; private set; }

            [DataMember(Name ="custom_profiles")]
            public CustomProfileRateLimit CustomProfiles { get; private set; }

            [DataMember(Name ="webhooks")]
            public WebhookRateLimit Webhooks { get; private set; }

            [DataMember(Name ="contacts")]
            public ContactRateLimit Contacts { get; private set; }

            [DataMember(Name ="tweet_prompts")]
            public TweetPromptRateLimit TweetPrompts { get; private set; }

            [DataMember(Name ="moments")]
            public MomentRateLimit Moment { get; private set; }
        }
    }
}
