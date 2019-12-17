
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

    }
}
