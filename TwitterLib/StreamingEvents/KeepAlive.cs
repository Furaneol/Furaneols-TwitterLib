using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// 通信切断が起こっていない事を示す情報オブジェクトです。このオブジェクトに格納される追加情報はありません。
    /// </summary>
    public class KeepAlive : StreamingMessage
    {
        /// <summary>
        /// このプロパティは常に列挙子：StreamingMessageType.KeepAliveを返します。
        /// </summary>
        public override StreamingMessageType MessageType => StreamingMessageType.KeepAlive;
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }
    }
}
