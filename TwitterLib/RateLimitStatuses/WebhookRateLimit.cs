using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// WebhookカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class WebhookRateLimit
    {
        /// <summary>
        /// /webhooks/subscriptions/direct_messagesの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/webhooks/subscriptions/direct_messages")]
        public RateLimitStatus SubscriptionsDirectMessages { get; private set; }
        /// <summary>
        /// /webhooksの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/webhooks")]
        public RateLimitStatus Webhooks { get; private set; }
    }
}
