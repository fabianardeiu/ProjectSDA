using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Interfaces
{
    public interface IListNode : INode
    {
        IListNode Next { get; set; }
    }
}
