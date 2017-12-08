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
        public override StreamingMessageType MessageType => StreamingMessageType.KeepAlive;
        public override Twitter Parent { get; internal set; }
    }
}
