using DataStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public interface IBSTNode : INode
    {
        //IData Data { get; set; }
        IBSTNode Left { get; set; }
        IBSTNode Right { get; set; }
    }
}
