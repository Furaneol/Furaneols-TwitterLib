using System.Runtime.Serialization;
using System.Xml;

namespace TwitterLib
{
    /// <summary>
    /// Twitter API応答オブジェクトの基本型です。
    /// </summary>
    [DataContract]
    public abstract class ApiResponce
    {
        /// <summary>
        /// 現在の応答オブジェクトを作成したTwitterクラスインスタンスを取得します。
        /// </summary>
        public abstract Twitter Parent { get; internal set; }
        /// <summary>
        /// 応答内容をXmlNodeに出力します。
        /// </summary>
        /// <param name="node"></param>
        public abstract void WriteTo(XmlNode node);
    }
}
