using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// GeoカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class GeoRateLimit
    {
        /// <summary>
        /// /geo/similar_placesの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/geo/similar_places")]
        public RateLimitStatus SimilarPlaces { get; private set; }
        /// <summary>
        /// /geo/id/:place_idの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/geo/id/:place_id")]
        public RateLimitStatus PlaceId { get; private set; }
        /// <summary>
        /// /geo/reverse_geocodeの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/geo/reverse_geocode")]
        public RateLimitStatus ReverseGeocode { get; private set; }
        /// <summary>
        /// /geo/searchの回数制限を取得します。
        /// </summary>
        [DataMember(Name = "/geo/search")]
        public RateLimitStatus Search { get; private set; }
    }
}
