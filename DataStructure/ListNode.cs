using DataStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public class ListNode : IListNode
    {
        public IData Data { get; set; }
        public IListNode Next { get; set; }
    }
}
