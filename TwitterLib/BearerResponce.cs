using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// oauth2/tokenの応答情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    internal class BearerResponce:ApiResponce
    {
        /// <summary>
        /// トークンの種類を取得します。
        /// </summary>
        [DataMember(Name = "token_type")]
        public string Type { get; private set; }
        /// <summary>
        /// トークン文字列を取得します。
        /// </summary>
        [DataMember(Name = "access_token")]
        public string BearerToken { get; private set; }

        public override Twitter Parent { get; internal set; }
    }
}
