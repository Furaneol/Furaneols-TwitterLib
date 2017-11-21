using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace TwitterLib
{
    /// <summary>
    /// Twitter APIの使用時に起こる例外の情報を格納します。
    /// </summary>
    [Serializable]
    public class TwitterException : Exception
    {
        static DataContractJsonSerializer emSerializer = new DataContractJsonSerializer(typeof(ErrorMessageContainer));
        /// <summary>
        /// 指定されたWebExceptionを解析し、情報を抽出します。
        /// </summary>
        /// <param name="wex"></param>
        public TwitterException(WebException wex)
        {
            if (wex.Status == WebExceptionStatus.ProtocolError)
            {
                using (HttpWebResponse res = (HttpWebResponse)wex.Response)
                {
                    ErrorMessageContainer msg = (ErrorMessageContainer)emSerializer.ReadObject(res.GetResponseStream());
                    ErrorMessage first = msg.Errors[0];
                    ErrorCode = first.Code;
                    Message = first.Message;
                    List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
                    foreach(ErrorMessage part in msg.Errors)
                    {
                        list.Add(new KeyValuePair<int, string>(part.Code, part.Message));
                    }
                    ErrorMessages = list.ToArray();
                }
            }
            else
            {
                ErrorCode = 999;
                HttpStatusCode = 999;
                switch (wex.Status)
                {
                    case WebExceptionStatus.CacheEntryNotFound:
                        Message = "指定したキャッシュエントリが見つかりませんでした。";
                        break;
                    case WebExceptionStatus.ConnectFailure:
                        Message = "トランスポートレベルで、リモートサービスと通信できませんでした。";
                        break;
                    case WebExceptionStatus.ConnectionClosed:
                        Message = "接続を終了するのが早すぎました。";
                        break;
                    case WebExceptionStatus.KeepAliveFailure:
                        Message = "Keep-alive ヘッダーを指定する要求のための接続が予期せずに閉じられました。";
                        break;
                    case WebExceptionStatus.MessageLengthLimitExceeded:
                        Message = "サーバーに要求を送信、またはサーバーからの応答を受信しているときに、制限長を超えるメッセージが渡されました。";
                        break;
                    case WebExceptionStatus.NameResolutionFailure:
                        Message = "名前解決サービスがホスト名を解決できませんでした。";
                        break;
                    case WebExceptionStatus.Pending:
                        Message = "内部非同期要求が保留中です。";
                        break;
                    case WebExceptionStatus.PipelineFailure:
                        Message = "要求がパイプライン処理された要求で、応答の受信前に接続が閉じられました。";
                        break;
                    case WebExceptionStatus.ProxyNameResolutionFailure:
                        Message = "名前解決サービスがプロキシ ホスト名を解決できませんでした。";
                        break;
                    case WebExceptionStatus.ReceiveFailure:
                        Message = "リモート サーバーから完全な応答が受信されませんでした。";
                        break;
                    case WebExceptionStatus.RequestCanceled:
                        Message = "要求が取り消されたか、System.Net.WebRequest.Abort メソッドが呼び出されたか、または分類できないエラーが発生しました。";
                        break;
                    case WebExceptionStatus.RequestProhibitedByCachePolicy:
                        Message = "要求はキャッシュ ポリシーで許可されませんでした。";
                        break;
                    case WebExceptionStatus.RequestProhibitedByProxy:
                        Message = "この要求はプロキシで許可されませんでした。";
                        break;
                    case WebExceptionStatus.SecureChannelFailure:
                        Message = "SSL を使用して接続を確立する際にエラーが発生しました。";
                        break;
                    case WebExceptionStatus.SendFailure:
                        Message = "完全な要求をリモート サーバーに送信できませんでした。";
                        break;
                    case WebExceptionStatus.ServerProtocolViolation:
                        Message = "サーバー応答が有効な HTTP 応答ではありません。";
                        break;
                    case WebExceptionStatus.Timeout:
                        Message = "要求のタイムアウト時間中に応答が受信されませんでした。";
                        break;
                    case WebExceptionStatus.TrustFailure:
                        Message = "サーバー証明書を検証できませんでした。";
                        break;
                    case WebExceptionStatus.UnknownError:
                        Message = "未知の種類の例外が発生しました。";
                        break;
                }
            }
        }
        /// <summary>
        /// 応答内に記述された最初のエラーコードを取得します。(999:トランスポート層以下で発生した問題による例外)
        /// </summary>
        public int ErrorCode { get; }
        /// <summary>
        /// HTTPステータスコードを取得します。(999:トランスポート層以下で発生した問題による例外)
        /// </summary>
        public int HttpStatusCode { get; }
        /// <summary>
        /// エラーメッセージを取得します。
        /// </summary>
        public override string Message { get; }
        /// <summary>
        /// レスポンスに含まれていた全てのエラーメッセージを取得します。
        /// </summary>
        public KeyValuePair<int, string>[] ErrorMessages { get; }

        [DataContract]
        class ErrorMessageContainer
        {
            [DataMember(Name = "errors")]
            public ErrorMessage[] Errors { get; private set; }
        }

        [DataContract]
        class ErrorMessage
        {
            [DataMember(Name = "message")]
            public string Message { get; private set; }

            [DataMember(Name = "code")]
            public int Code { get; private set; }
        }
    }
}
