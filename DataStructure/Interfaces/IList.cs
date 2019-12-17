using DataStructure;
using DataStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IList
    {
        IListNode First { get; set; }
        IListNode Current { get; set; }
        IListNode Previous { get; set; }


        void IterateList();

        void Insert(IData data);
        void AddFirstNode(IData data);
        void InsertLast(IData data);

        void Delete(IData data);
        void DeleteFirstNode();
        void DeleteInternalNode(IData data);
        void DeleteLastNode();

        int ListLength();
        IListNode FindNodeInListByData(IData data);
        IListNode NextNode(IListNode node);

    }
}
