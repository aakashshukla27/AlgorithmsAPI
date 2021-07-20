using Graphs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Problems
{
    class EulerPath
    {
        private bool[] marked;

        public EulerPath(Graph G)
        {
            marked = new bool[G.Vertex()];
        }

        private void IsConnected()
        {

        }
    }
}
