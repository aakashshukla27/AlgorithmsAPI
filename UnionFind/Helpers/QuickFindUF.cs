using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind.Helpers
{
    
    class QuickFindUF
    {
        private int[] id; // access to component id (site indexed)
        private int count; // number of components
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="n">Size of array</param>
        public QuickFindUF(int n)
        {
            id = new int[n];
            count = n;
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }
        /// <summary>
        /// Returns number of components
        /// </summary>
        /// <returns> total number of components </returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Checks if 2 nodes are connected
        /// </summary>
        /// <param name="p">First Node</param>
        /// <param name="q">Second Node</param>
        /// <returns>CHecks if the 2 components provided are connected</returns>
        public bool connected(int p, int q)
        {
            return (id[p] == id[q]);
        }

    }
}
