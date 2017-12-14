using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// LiveVideoStreamカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class LiveVideoStreamRateLimit
    {
        /// <summary>
        /// /live_video_stream/status/:idの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/live_video_stream/status/:id")]
        public RateLimitStatus Status { get; private set; }
    }
}
