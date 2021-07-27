using System;
using Tree.Helpers;
using Tree.Problems;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode treeNode = new TreeNode(1);
            TreeNode l1 = new TreeNode(0);
            TreeNode r1 = new TreeNode(1);
            TreeNode l2 = new TreeNode(0);
            TreeNode l3 = new TreeNode(0);
            TreeNode r2 = new TreeNode(0);
            TreeNode r3 = new TreeNode(1);

            treeNode.left = l1;
            treeNode.right = r1;
            l1.left = l2;
            l1.right = l3;

            r1.left = r2;
            r1.right = r3;

          

            //int[] arr = new int[] { 1, 0, 1, 0, 0, 0, 1 };
            //for (int i = 1; i < arr.Length; i++)
            //{
            //    if(i%2 == 0)
            //    {
            //        treeNode.right = new TreeNode(arr[i]);
            //        treeNode
            //    }
            //}

        }
    }
}
