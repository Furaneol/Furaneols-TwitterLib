using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterLib
{
    /// <summary>
    /// 
    /// </summary>
    class ListContainer : CursorNavigator
    {
        Twitter parent;

        public override Twitter Parent
        {
            get => parent;
            internal set
            {
                parent = value;
                if (Lists != null)
                    foreach (List list in Lists)
                        list.Parent = value;
            }
        }

        public List[] Lists { get; private set; }
    }
}
