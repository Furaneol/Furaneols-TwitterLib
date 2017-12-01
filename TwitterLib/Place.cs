using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// 場所の情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class Place : ApiResponce
    {
        /// <summary>
        /// 識別文字列を取得します。
        /// </summary>
        [DataMember(Name = "id")]
        public string ID { get; internal set; }
        /// <summary>
        /// この場所に関する追加情報を提供するURLを取得します。
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; internal set; }
        /// <summary>
        /// 場所の種類を示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "place_type")]
        public string PlaceType { get; internal set; }
        /// <summary>
        /// 場所の短縮名を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; internal set; }
        /// <summary>
        /// 場所の完全名を取得します。
        /// </summary>
        [DataMember(Name = "full_name")]
        public string FullName { get; internal set; }
        /// <summary>
        /// 場所が属している国の2文字コードを取得します。
        /// </summary>
        [DataMember(Name = "country_code")]
        public string CountryCode { get; internal set; }
        /// <summary>
        /// 国名を取得します。
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; internal set; }
        /// <summary>
        /// この位置情報が示す範囲を取得します。
        /// </summary>
        [DataMember(Name = "bounding_box")]
        public BoundingBox BoundingBox { get; internal set; }

        public override Twitter Parent { get; internal set; }
    }
    /// <summary>
    /// エリアの端を示す座標情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class BoundingBox : ApiResponce
    {
        /// <summary>
        /// ボックスを囲む位置情報の配列を取得します。
        /// </summary>
        [DataMember(Name = "coordinates")]
        public float[][][] Coordinates { get; internal set; }
        /// <summary>
        /// ボックスの種類を示す文字列を取得します。
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; internal set; }

        public override Twitter Parent { get; internal set; }
    }
}
