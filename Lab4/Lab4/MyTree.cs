using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class MyTree<T>
    {
        public TreeNode<T> Root { get; set; }

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            if (Root != null)
                GetTree(Root, list);
            return list;
        }

        private void GetTree(TreeNode<T> rt, List<T> ls)
        {
            ls.Add(rt.Value);
            if (rt.Brother != null)
                GetTree(rt.Brother, ls);
            if (rt.Child != null)
                GetTree(rt.Child, ls);
        }
    }

    public class TreeNode<T>
    {
        public T Value { get; set; }
        public TreeNode<T> Child { get => child; }
        public TreeNode<T> Brother { get => brother; }

        private TreeNode<T> child;
        private TreeNode<T> brother;

        public TreeNode<T> AddChild(T data)
        {
            TreeNode<T> child = new TreeNode<T> { Value = data };
            child.brother = this.child;
            this.child = child;

            return child;
        }

        public TreeNode<T> AddChild(TreeNode<T> child)
        {
            child.brother = this.child;
            this.child = child;

            return child;
        }

        public bool RemoveChild(int indexFromLeft)
        {
            if (indexFromLeft < 0 || child == null)
                return false;

            TreeNode<T> previous = child;
            if (indexFromLeft == 0)
            {
                child.brother = null;
                child = previous.brother;

                return true;
            }

            indexFromLeft -= 1;
            while (--indexFromLeft >= 0 && previous != null)
                previous = previous.brother;
            if (previous == null)
                return false;

            previous.brother = previous.brother.brother;
            return true;

        }

        public bool RemoveChild(TreeNode<T> node)
        {
            if (node == null || child == null)
                return false;

            TreeNode<T> previous = child;
            if (previous == node)
            {
                child.brother = null;
                child = previous.brother;

                return true;
            }
            while (previous.brother != node && previous != null)
                previous = previous.brother;
            if (previous == null)
                return false;

            previous.brother = previous.brother.brother;
            return true;
        }

        public bool RemoveChild(T data)
        {
            if (data == null || child == null)
                return false;

            TreeNode<T> previous = child;
            if (object.ReferenceEquals(data, previous.Value) || data.Equals(previous.Value))
            {
                child.brother = null;
                child = previous.brother;

                return true;
            }
            while (!(object.ReferenceEquals(data, previous.brother.Value) || data.Equals(previous.brother.Value)) && previous != null)
                previous = previous.brother;
            if (previous == null)
                return false;

            previous.brother = previous.brother.brother;
            return true;
        }

    }
}