using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
    /// <summary>
    /// Streaming APIに接続するためのパラメーターを格納するオブジェクトです。
    /// </summary>
    public class StreamingStartArguments
    {
        double[] location;
        /// <summary>
        /// 速度低下警告を受け取るかどうかを示す値を取得または設定します。
        /// </summary>
        public bool? EnabledStallWarnings { get; set; }
        /// <summary>
        /// フィルターレベルを取得または設定します。
        /// </summary>
        public FilterLevel? FilterLevel { get; set; }
        /// <summary>
        /// 受信するツイートの言語を取得または設定します。
        /// </summary>
        public string[] Languages { get; set; }
        /// <summary>
        /// 取得対象ユーザーのID一覧を取得または設定します。
        /// </summary>
        public ulong[] Follows { get; set; }
        /// <summary>
        /// 取得対象となる位置を示す実数値配列を取得または設定します。
        /// </summary>
        public double[] Location
        {
            get { return location; }
            set
            {
                if (value.Length % 2 != 0)
                    throw new ArgumentException("Location配列は偶数個の要素を持つ必要があります。", "value");
                if ((value?.Length ?? 0) == 0)
                    location = null;
                else
                    location = value;
            }
        }
        /// <summary>
        /// 取得対象とする範囲を示す値を取得または設定します。有効な値はuserまたはfollowingsのみです。
        /// </summary>
        public string With
        {
            get { return with; }
            set
            {
                value = value.ToLower();
                if (value != "user" && value != "followings")
                    throw new ArgumentException("Withプロパティに指定できる文字列は\"user\"および\"followings\"のみです。", "value");
                with = value;
            }
        }
        /// <summary>
        /// リプライの宛先または送信元のうちいずれかのみをフォローしている場合に取得するかどうかを示す値を取得または設定します。
        /// </summary>
        public bool CollectAllReplies { get; set; }
        /// <summary>
        /// 設定された値を元にリクエストパラメーターを構築します。
        /// </summary>
        /// <returns></returns>
        internal SortedDictionary<string,string> CreateArgument()
        {
            SortedDictionary<string, string> args = new SortedDictionary<string, string>();
            if (EnabledStallWarnings.HasValue)
                args["stall_warnings"] = EnabledStallWarnings.ToString().ToLower();
            if (FilterLevel.HasValue)
                args["filter_level"] = FilterLevel.ToString().ToLower();
            if (Languages != null && Languages.Length > 0)
                args["language"] = string.Join(",", Languages);
            if (Follows != null && Follows.Length > 0)
                args["follow"] = string.Join(",", Follows);
            if (location != null && location.Length > 0)
                args["location"] = string.Join(",", location);
            if (!string.IsNullOrEmpty(With))
                args["with"] = With;
            if (CollectAllReplies)
                args["replies"] = "all";
            return args;
        }
    }
    /// <summary>
    /// Streaming APIにおけるフィルターレベルを指定する値です。
    /// </summary>
    public enum FilterLevel
    {
        /// <summary>
        /// filter_levelをnoneに設定します。
        /// </summary>
        None,
        /// <summary>
        /// filter_levelをlowに設定します。
        /// </summary>
        Low,
        /// <summary>
        /// filter_levelをmediumに設定します。
        /// </summary>
        Medium,
        /// <summary>
        /// filter_levelをhighに設定します。
        /// </summary>
        High
    }
}
