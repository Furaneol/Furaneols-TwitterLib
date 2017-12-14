using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// Tweet PromptカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class TweetPromptRateLimit
    {
        /// <summary>
        /// /tweet_prompts/report_interactionの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/tweet_prompts/report_interaction")]
        public RateLimitStatus ReportInteraction { get; private set; }
        /// <summary>
        /// /tweet_prompts/showの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/tweet_prompts/show")]
        public RateLimitStatus Show { get; private set; }
    }
}
