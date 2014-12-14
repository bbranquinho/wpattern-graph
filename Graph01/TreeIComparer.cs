using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    public class TreeIComparer : IComparer<Tree>
    {
        public TreeIComparer()
            : base()
        {
        }

        public int Compare(Tree a, Tree b)
        {
            return ((a.h < b.h) ? -1 : ((a.h > b.h) ? 1 : 0));
        }
    }

    public class QIcomparer : IComparer<int>
    {
        int[] delay;

        public QIcomparer(int[] mDelay)
            : base()
        {
            delay = mDelay;
        }

        public int Compare(int a, int b)
        {
            return ((delay[a] < delay[b]) ? -1 : ((delay[a] > delay[b]) ? 1 : 0));
        }
    }
}
