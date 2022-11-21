using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyApp.MVVM.ViewModel
{
    internal class Tree<T>
    {
        public TreeNode<Category> Root { get; set; }

        public Tree()
        {
            //this.Root = Root;
        }

        public void InsertTreeNode(Category newValue)
        {
            if (Root != null)
            {
                Root.Insert(newValue, Root);
            }
            else
            {

                Root = new TreeNode<Category>(newValue);
            }
        }
    }
}
