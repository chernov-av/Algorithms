using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Data
{
    class BinaryTree<T>: ITrees<T> where T:IComparable<T>
    {
        List<T> PrintList = new List<T>();
        TreeNode<T> root;
        int treeSize = 0;

        public void TreeInsert(T _key)
        {
            TreeNode<T> newNode = new TreeNode<T>(_key);
            TreeNode<T> y = null;
            TreeNode<T> x = this.root;

            while (x != null)
            {
                y = x;
                if (newNode.key.CompareTo(x.key) < 0)
                {
                    x = x.left;
                }
                else x = x.right;
            }

            newNode.parent = y;
            if (y == null)
            {
                this.root = newNode;
            }
            else if (newNode.key.CompareTo(y.key) < 0)
            {
                y.left = newNode;
            }
            else y.right = newNode;

            this.treeSize++;            
        }

        public void TreeDelete(T _key)
        {
            TreeNode<T> deletedNode = IterativeTreeSearch(this.root, _key);

            if (deletedNode.left == null)
            {
                Transplant(deletedNode, deletedNode.right);
            }
            else if (deletedNode.right == null)
            {
                Transplant(deletedNode, deletedNode.left);
            }
            else
            {
                TreeNode<T> y = TreeMinimum(deletedNode.right);
                if (y.parent != deletedNode)
                {
                    Transplant(y, y.right);
                    y.right = deletedNode.right;
                    y.right.parent = y;
                }
                Transplant(deletedNode, y);
                y.left = deletedNode.left;
                y.left.parent = y;
            }
            this.treeSize--;
        }

        void Transplant(TreeNode<T> u, TreeNode<T> v)
        {
            if (u.parent == null)
            {
                this.root = v;
            }
            else if (u == u.parent.left)
            {
                u.parent.left = v;
            }
            else u.parent.right = v;
            if (v != null)
            {
                v.parent = u.parent;
            }
        }

        public void TreeWalk()
        {
            this.PrintList.Clear();
            InorderTreeWalk(this.root);
        }

        public void InorderTreeWalk(TreeNode<T> _parent)
        {
            if (_parent != null)
            {
                InorderTreeWalk(_parent.left);
                PrintList.Add(_parent.key);
                InorderTreeWalk(_parent.right);
            }
        }

        public TreeNode<T> TreeSearch(TreeNode<T> _root, T _key)
        {
            if (_root==null || _key.Equals(_root.key))
            {
                return _root;
            }
            if (_key.CompareTo(_root.key) < 0)
            {
                return TreeSearch(_root.left,_key);
            }
            else
            {
                return TreeSearch(_root.right, _key);
            }
        }

        public TreeNode<T> IterativeTreeSearch(TreeNode<T> _root, T _key)
        {
            while (_root!=null && _key.CompareTo(_root.key) != 0)
            {
                if (_key.CompareTo(_root.key) < 0)
                {
                    _root = _root.left;
                }
                else _root = _root.right;
            }
            return _root;
        }

        public TreeNode<T> TreeMinimum(TreeNode<T> _root)
        {
            while (_root.left != null)
            {
                _root = _root.left;
            }
            return _root;
        }

        public TreeNode<T> TreeMaximum(TreeNode<T> _root)
        {
            while (_root.right != null)
            {
                _root = _root.right;
            }
            return _root;
        }

        public TreeNode<T> TreeSuccessor(TreeNode<T> _root)
        {
            if (_root.right != null)
            {
                return TreeMinimum(_root.right);
            }
            TreeNode<T> y = _root.parent;
            while (y != null && _root == y.right)
            {
                _root = y;
                y = y.parent;
            }
            return y;
        }

        public int GetSize
        {
            get { return this.treeSize; }
        }

        public T[] GetTree
        {
            get { this.TreeWalk(); return this.PrintList.ToArray(); }
        }
    }

    class TreeNode<T> where T : IComparable<T>
    {
        public T key { get; set; }
        public TreeNode<T> parent;
        public TreeNode<T> left;
        public TreeNode<T> right;

        public TreeNode(T _key)
        {
            this.key = _key;
        }

        public int CompareTo(T other)
        {
            return key.CompareTo(other);
        }
    }
    
}
