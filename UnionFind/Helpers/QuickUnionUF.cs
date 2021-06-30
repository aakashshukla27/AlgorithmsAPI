﻿using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind.Helpers
{
    class QuickUnionUF
    {
        private int[] id; // access to component id (site indexed)
        private int count; // number of components
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="n">Size of array</param>
        public QuickUnionUF(int n)
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
            // Give p and q the same root
            int proot = Find(p);
            int qroot = Find(q);
            if(proot == qroot)
            {
                return;
            }
            id[proot] = qroot;
            count--;
        }

        /// <summary>
        /// recursively gets id of current element till element is equal to id
        /// </summary>
        /// <param name="p">node number</param>
        /// <returns>root of the tree</returns>
        public int Find(int p)
        {
            while(p != id[p])
            {
                p = id[p];
            }
            return p;
        }

    }
}
