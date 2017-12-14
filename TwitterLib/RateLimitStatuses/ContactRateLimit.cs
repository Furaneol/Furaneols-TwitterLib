using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.RateLimitStatuses
{
    /// <summary>
    /// ContactsカテゴリのREST APIの使用回数制限情報を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    public class ContactRateLimit
    {
        /// <summary>
        /// /contacts/uploaded_byの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/contacts/uploaded_by")]
        public RateLimitStatus UploadedBy { get; private set; }
        /// <summary>
        /// /contacts/usersの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/contacts/users")]
        public RateLimitStatus Users { get; private set; }
        /// <summary>
        /// /contacts/addressbookの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/contacts/addressbook")]
        public RateLimitStatus Addressbook { get; private set; }
        /// <summary>
        /// /contacts/users_and_uploaded_byの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/contacts/users_and_uploaded_by")]
        public RateLimitStatus UsersAndUploadedBy { get; private set; }
        /// <summary>
        /// /contacts/delete/statusの回数制限を取得します。
        /// </summary>
        [DataMember(Name ="/contacts/delete/status")]
        public RateLimitStatus DeleteStatus { get; private set; }
    }
}
