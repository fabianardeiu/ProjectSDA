using Core.Interfaces;
using DataStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class BST : IBST
    {
        private IList _list = new List();
        public IBSTNode Root { get; set; }

        public bool DeleteBSTNodeById(int id)
        {
            IBSTNode toDelete = GetBSTNodeById(id);
            if (toDelete == null)
                return false;
            else if(GetBSTNodeNumberOfChildrens(toDelete.Data.Id) == 0)
            {
                DeleteBSTNode0Childrens(toDelete);
            }
            else if(GetBSTNodeNumberOfChildrens(toDelete.Data.Id) == 1)
            {
                DeleteBSTNode1Children(toDelete);
            }
            else if(GetBSTNodeNumberOfChildrens(toDelete.Data.Id) == 2)
            {
                DeleteBSTNode2Childrens(toDelete);
            }
            else
            {
                return false;
            }
            return true;

        }

        public IBSTNode GetBSTNodeParentById(int id)
        {
            IBSTNode temp = Root;
            while (temp.Data.Id != id && temp.Right?.Data.Id != id)
            {
                if(temp.Data.Id > id)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return temp;
        }

        public IBSTNode GetBSTNodeById(int id)
        {
            IBSTNode temp = new BSTNode();
            temp = Root;
            while(temp != null)
            {
                if(id == temp.Data.Id)
                {
                    return temp;
                }
                else if(id < temp.Data.Id)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            return null;
        }

        public void Inorder(IBSTNode root)
        {
            if(root != null)
            {
                Inorder(root.Left);
                _list.Insert(root.Data);
                Inorder(root.Right);
            }
        }

        public IList GetAllNodes(IBSTNode root)
        {
            _list = new List();
            Inorder(root);
            return _list;
        }


        public void Insert(IData data)
        {
            IBSTNode temp = new BSTNode();
            IBSTNode dad = new BSTNode();
            IBSTNode newBSTNode = new BSTNode { Data = data };

            if (Root == null)
            {
                Root = newBSTNode;
            }
            else
            {
                temp = Root;
                while (temp != null)
                {
                    dad = temp;
                    if (newBSTNode.Data.Id < temp.Data.Id)
                        temp = temp.Left;
                    else
                        temp = temp.Right;
                }
                if (dad.Data.Id > newBSTNode.Data.Id)
                    dad.Left = newBSTNode;
                else
                    dad.Right = newBSTNode;
            }
            
        }

        public bool Search(IData data)
        {
            IBSTNode temp = new BSTNode();
            temp = Root;
            while (temp != null)
            {
                if (data == temp.Data)
                {
                    return true;
                }

                else if (data.Id < temp.Data.Id)
                    temp = temp.Left;
                else
                    temp = temp.Right;
            }
            return false;
        }

        private int GetBSTNodeNumberOfChildrens(int id)
        {
            int children = 0;
            IBSTNode toDelete = GetBSTNodeById(id);
            if (toDelete == null)
            {
                return -1;
            }
            else
            {
                if (toDelete.Left != null)
                {
                    children += 1;
                }
                if (toDelete.Right != null)
                {
                    children += 1;
                }
            }
            return children;
        }

        private void DeleteBSTNode0Childrens(IBSTNode toDelete)
        {
            IBSTNode temp = Root;
            while (temp.Left != toDelete && temp.Right != toDelete)
            {
                if (temp.Data.Id > toDelete.Data.Id)
                {
                    temp = temp.Left;
                }
                else
                {
                    temp = temp.Right;
                }
            }
            if (temp.Left == toDelete)
            {
                temp.Left = null;
            }
            else
            {
                temp.Right = null;
            }
        }

        private void DeleteBSTNode1Children(IBSTNode toDelete)
        {
            IBSTNode tempParent = new BSTNode();
            IBSTNode tempChild = new BSTNode();
            tempChild = toDelete.Left == null ? toDelete.Right : toDelete.Left;
            tempParent = GetBSTNodeParentById(toDelete.Data.Id);

            if (toDelete == tempParent.Left)
            {
                tempParent.Left = tempChild;
            }
            else
            {
                tempParent.Right = tempChild;
            }
        }

        private void DeleteBSTNode2Childrens(IBSTNode toDelete)
        {
            IBSTNode tempParent = new BSTNode();
            tempParent = GetBSTNodeParentById(toDelete.Data.Id);
            IBSTNode tempChild = new BSTNode();
            tempChild = GetBSTNodeById(minValue(toDelete.Right));
            tempParent.Left = tempChild;
            tempChild.Left = toDelete.Left;
        }

        private int minValue(IBSTNode root)
        {
            int minValue = root.Data.Id;
            while (root.Right != null)
            {
                minValue = root.Right.Data.Id;
                root = root.Right;
            }
            return minValue;
        }
    }
}
