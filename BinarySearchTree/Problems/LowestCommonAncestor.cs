using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree.Problems
{
    
    class LowestCommonAncestor
    {
        public TreeNode LowestCommonAncestorSolution(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (root.val == p.val || root.val == q.val) return root;

            TreeNode leftTree = LowestCommonAncestorSolution(root.left, p, q);
            TreeNode rightTree = LowestCommonAncestorSolution(root.right, p, q);

            if (leftTree != null && rightTree != null) return root;

            return leftTree ?? rightTree;


        }
    }

    

}
