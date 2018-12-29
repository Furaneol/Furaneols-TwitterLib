using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Trends
{
    /// <summary>
    /// トレンド取得時に指定できる位置情報を示すデータを格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class TrendPlaceInfo : ApiResponce
    {
        /// <summary>
        /// 位置情報の名前を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        /// <summary>
        /// 位置情報の種類を取得します。
        /// </summary>
        [DataMember(Name = "placeType")]
        public PlaceType Type { get; private set; }
        /// <summary>
        /// 位置情報に紐づいたwhere.yahooapis.comのURLを取得します。
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; private set; }
        /// <summary>
        /// 現在の位置情報を含む親情報のWOEIDを取得します。
        /// </summary>
        [DataMember(Name = "parentid")]
        public int ParentID { get; private set; }
        /// <summary>
        /// 国名を取得します。
        /// </summary>
        [DataMember(Name = "country")]
        public string Country { get; private set; }
        /// <summary>
        /// 位置情報に割り当てられたYahoo! Where on Earth IDを取得します。
        /// </summary>
        [DataMember(Name = "woeid")]
        public int WOEID { get; private set; }
        /// <summary>
        /// 国名コードを取得します。
        /// </summary>
        [DataMember(Name = "countryCode")]
        public string CountryCode { get; private set; }
        /// <summary>
        /// 作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }

        public override string ToString()
        {
            return Name + "(" + Country + ")";
        }
    }
    /// <summary>
    /// 位置情報の種類を示すデータを格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class PlaceType
    {
        /// <summary>
        /// 位置情報種別コードを取得します。
        /// </summary>
        [DataMember(Name = "code")]
        public int Code { get; private set; }
        /// <summary>
        /// 位置情報種別の名前を取得します。
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; private set; }
    }
}
