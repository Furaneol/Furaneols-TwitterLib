using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
    /// <summary>
    /// Twitter APIリクエストの認証方式を指定する値です。
    /// </summary>
    [Flags]
    public enum TwitterAuthenticationMode
    {
        /// <summary>
        /// 認証モードが未設定です。
        /// </summary>
        None = 0x00,
        /// <summary>
        /// ユーザー認証のみを使用します。
        /// </summary>
        UserAuthentication = 0x01,
        /// <summary>
        /// アプリケーション認証のみを使用します。
        /// </summary>
        ApplicationOnlyAuthentication = 0x02,
        /// <summary>
        /// 認証方式を自動選択します。全ての認証方式が利用可能な場合はユーザー認証を使用します。
        /// </summary>
        Automatic = 0x03
    }
}
