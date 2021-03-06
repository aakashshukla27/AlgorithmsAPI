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
        /// <returns>Checks if the 2 components provided are connected</returns>
        public bool Connected(int p, int q)
        {
            return (Find(p) == Find(q));
        }

        /// <summary>
        /// Unions 2 integers, replaces id of first with id of second
        /// </summary>
        /// <param name="p">first node</param>
        /// <param name="q">second node</param>
        public void Union(int p, int q)
        {
            int pid = Find(p);
            int qid = Find(q);

            // if already connected do nothing
            if(pid == qid)
            {
                return;
            }
            // else union them and reduce number of connected components
            for (int i = 0; i < id.Length; i++)
            {
                if(id[i] == pid)
                {
                    id[i] = qid;
                }
            }
            count--;
        }

        /// <summary>
        /// returns value of current id in the array
        /// </summary>
        /// <param name="p"></param>
        /// <returns>value of the current element in id[i]</returns>
        public int Find(int p)
        {
            return id[p];
        }

    }
}
