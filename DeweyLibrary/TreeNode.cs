using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyApp.MVVM.ViewModel
{
    internal class TreeNode<T>
    {
        public Category Data;
        public TreeNode<Category> Parent { get; set; }
        //public List<TreeNode<Category>> Children { get; set; }
        public TreeNode<Category>[] Children = new TreeNode<Category>[10];
        //public T Data { get; set; }
        //public TreeNode<T> Parent { get; set; }
        //public List<TreeNode<T>> Children { get; set; }

        public TreeNode(Category Data)
        {
            this.Data = Data;

        }

        public void Insert(Category newValue, TreeNode<Category> parent)
        {
            if (newValue.level < newValue.id.Length)
            {
                Parent = parent;

                string value = newValue.id.Substring(newValue.level, 1);

                int arrayPosition = Convert.ToInt32(value);
                Category level1 = new Category();
                TreeNode<Category> level1Branch = new TreeNode<Category>(level1);

                if (parent.Children[arrayPosition] == null)
                {
                    //Create 1st level node
                    value = newValue.id.Substring(newValue.level, 1);

                    level1.id = value;
                    if (newValue.level == 2) level1.name = newValue.name;
                    newValue.level++;
                    Parent.Children[Convert.ToInt32(value)] = level1Branch;
                    level1Branch.Parent = Parent.Parent;
                    level1Branch.Insert(newValue, level1Branch);
                }
                else
                {
                    newValue.level++;
                    level1Branch = parent.Children[arrayPosition];
                    Parent.Insert(newValue, level1Branch);
                }
            }
        }
    }
}
