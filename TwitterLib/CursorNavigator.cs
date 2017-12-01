using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// カーソルナビゲーション情報部分を定義するクラスです。
    /// </summary>
    [DataContract]
    public abstract class CursorNavigator : ApiResponce
    {
        /// <summary>
        /// 前のページIDを取得または設定します。
        /// </summary>
        [DataMember(Name = "previous_cursor")]
        public ulong PreviousCursor { get; internal set; }
        /// <summary>
        /// 次のページIDを取得または設定します。この値が0の場合、次のページは存在しません。
        /// </summary>
        [DataMember(Name = "next_cursor")]
        public ulong NextCursor { get; internal set; }
    }
}
