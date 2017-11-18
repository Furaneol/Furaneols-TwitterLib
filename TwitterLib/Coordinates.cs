using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace TwitterLib
{
    [DataContract]
    class InterCoordinates
    {
        [DataMember(Name ="coodinates")]
        public float[] Coordinates { get; internal set; }
    }
}
