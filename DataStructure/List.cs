
using Core.Interfaces;
using DataStructure.Interfaces;

namespace DataStructure
{
    public class List : IList
    {
        public IListNode First { get; set; }
        public IListNode Current { get; set; }
        public IListNode Previous { get; set; }


        public void Insert(IData data)
        {
            if(First == null)
            {
                AddFirstNode(data);
            }
            else
            {
                InsertLast(data);
            }
        }
        public void AddFirstNode(IData data)
        {
            IListNode node = new ListNode {Data = data};
            First = node;
        }

        public void InsertLast(IData data)
        {
            IListNode node = new ListNode { Data = data };
            Current = First;
            while (Current != null)
            {
                Previous = Current;
                Current = Current.Next;
            }
            Previous.Next = node;
        }

        public void Delete(IData data)
        {
            IListNode toDelete = FindNodeInListByData(data);
            if(toDelete == First)
            {
                DeleteFirstNode();
            }
            else if(toDelete.Next == null)
            {
                DeleteLastNode();
            }
            else
            {
                DeleteInternalNode(data);
            }
        }

        public void DeleteFirstNode()
        {
            IListNode firstNode = First;
            First = First.Next;
        }

        public void DeleteInternalNode(IData data)
        {
            var toDeleteNode = FindNodeInListByData(data);
            Current = First;
            bool runProgram = true;
            while (runProgram)
            {
                Previous = Current;
                if (Current.Next == toDeleteNode)
                {
                    Previous.Next = toDeleteNode.Next;
                    runProgram = false;
                }
                Current = Current.Next;
            }
        }

        public void DeleteLastNode()
        {
            Current = First;
            while (Current != null)
            {
                Previous = Current;
                if (Current.Next.Next == null)
                {
                    break;
                }
                Current = Current.Next;
            }
            Previous.Next = null;
        }

        public IListNode FindNodeInListByData(IData data)
        {
            var nod = First;
            while (nod != null)
            {
                if (nod.Data.Id == data.Id)
                {
                    break;
                }

                nod = nod.Next;
            }
            if (nod == null)
            {
                return null;
            }
            return nod;
        }

       

        public void IterateList()
        {
            IListNode node = First;
            while (node != null)
            {
                System.Console.WriteLine(node.Data.ToString());
                node = node.Next;
            }
        }

        public int ListLength()
        {
            int ctr = 0;
            IListNode node = First;
            while (node != null)
            {
                ctr += 1;
                node = node.Next;
            }
            return ctr;
        }

        public IListNode NextNode(IListNode node)
        {
            IListNode nextNode = node.Next;
            return nextNode;
        }

        
    }
}
