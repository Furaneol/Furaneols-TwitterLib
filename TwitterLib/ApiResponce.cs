using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// Twitter API応答オブジェクトの基本型です。
    /// </summary>
    [DataContract]
    public abstract class ApiResponce
    {
        /// <summary>
        /// 現在の応答オブジェクトを取得したTwitterクラスインスタンスを取得します。
        /// </summary>
        public abstract Twitter Parent { get; internal set; }
    }
}
