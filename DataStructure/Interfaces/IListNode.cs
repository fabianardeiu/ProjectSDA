using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Interfaces
{
    public interface IListNode : INode
    {
        //IData Data { get; set; }
        IListNode Next { get; set; }
    }
}
