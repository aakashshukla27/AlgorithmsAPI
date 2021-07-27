using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Problems
{
    class BinaryTreePruning
    {
        
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
            {
                return root;
            }

            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);

            if (root.val == 1 || root.left != null || root.right != null)
            {
                return root;
            }

            return null;
        }

       


    }



  
}
