using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib.Entities.ExtendedEntities
{
    /// <summary>
    /// 拡張エンティティ情報を取得します。
    /// </summary>
    [DataContract]
    public class ExtendedEntity
    {
        /// <summary>
        /// 格納されているメディア情報を取得します。
        /// </summary>
        [DataMember(Name = "media", IsRequired = false)]
        public ExtendedMedia[] MediaList { get; }
    }
}
