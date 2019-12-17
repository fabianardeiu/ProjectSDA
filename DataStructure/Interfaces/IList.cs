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
        void Insert(IData data);
    }
}
