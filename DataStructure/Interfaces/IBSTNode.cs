using DataStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    public interface IBSTNode : INode
    {
        IBSTNode Left { get; set; }
        IBSTNode Right { get; set; }
    }
}
