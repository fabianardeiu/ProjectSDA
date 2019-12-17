using DataStructure.Interfaces;
using System;

namespace DataStructure
{
    public class BSTNode : IBSTNode
    {
        public IData Data { get; set; }
        public IBSTNode Left { get; set; }
        public IBSTNode Right { get; set; }
    }
}
