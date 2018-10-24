using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
    /// <summary>
    /// カーソルナビゲーションのページ遷移リクエストを送信する前に発生するイベントを処理するメソッドを表します。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PageTransitionEventHandler(Twitter sender, PageTransitionEventArgs e);
    /// <summary>
    /// ページ遷移イベントの情報を格納するオブジェクトです。
    /// </summary>
    public class PageTransitionEventArgs : EventArgs
    {
        bool cancel;

        /// <summary>
        /// ページ遷移イベントオブジェクトを作成します。
        /// </summary>
        public PageTransitionEventArgs()
        {
            cancel = false;
        }
        /// <summary>
        /// ページ遷移をキャンセルするかどうかを指定する値を取得または設定します。
        /// </summary>
        public bool Cancel
        {
            get => cancel; set
            {
                cancel = cancel || value;
            }
        }
    }
}
