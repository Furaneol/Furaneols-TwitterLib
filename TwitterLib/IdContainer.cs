using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// IDの一覧を格納するクラスです。
    /// </summary>
    [DataContract]
    class IdContainer : CursorNavigator
    {
        /// <summary>
        /// IDの一覧を取得します。
        /// </summary>
        [DataMember(Name = "ids")]
        public ulong[] IDList { get; internal set; }

        public override Twitter Parent { get; internal set; }
    }
}
