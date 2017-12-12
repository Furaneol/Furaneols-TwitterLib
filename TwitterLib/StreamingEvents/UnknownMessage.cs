using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib.StreamingEvents
{
    /// <summary>
    /// このライブラリでサポートされていないメッセージの情報オブジェクトです。
    /// </summary>
    public class UnknownMessage : StreamingMessage
    {
        /// <summary>
        /// このプロパティは常に列挙子：StreamingMessageType.Unknownを返します。
        /// </summary>
        public override StreamingMessageType MessageType => StreamingMessageType.Unknown;
        /// <summary>
        /// このインスタンスを作成したTwitterオブジェクトを取得します。
        /// </summary>
        public override Twitter Parent { get; internal set; }

        internal UnknownMessage(Twitter parent, string content)
        {
            Parent = parent;
            ResponceContent = content;
        }
        /// <summary>
        /// 解釈に失敗したコンテンツの内容を取得します。
        /// </summary>
        public string ResponceContent { get; }
    }
}
