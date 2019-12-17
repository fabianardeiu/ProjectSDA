using DataStructure;
using DataStructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepository
    {
        IList GetAll();
        IData GetById(int id);
        void Add(IData data);
        void Delete(IData data);
        IData Update(IData data);
    }
}
