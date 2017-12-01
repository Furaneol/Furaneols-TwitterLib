using System.Runtime.Serialization;

namespace TwitterLib
{
    /// <summary>
    /// ユーザー情報の一覧を格納するオブジェクトです。
    /// </summary>
    [DataContract]
    class UserContainer : CursorNavigator
    {
        /// <summary>
        /// ユーザーの一覧を取得します。
        /// </summary>
        [DataMember(Name ="users")]
        public User[] Users { get; private set; }

        Twitter parent;
        public override Twitter Parent
        {
            get { return parent; }
            internal set
            {
                parent = value;
                foreach(User user in Users)
                {
                    user.Parent = value;
                }
            }
        }
    }
}
