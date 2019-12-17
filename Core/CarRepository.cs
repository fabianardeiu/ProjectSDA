using Core.Interfaces;
using DataStructure;
using DataStructure.Interfaces;
using Domain;

namespace Core
{
    public class CarRepository : IRepository
    {
        private static IBST _contextBST = new BST();

        private static IList _contextList = new List();

        static CarRepository()
        {
            var car1 = new Car { Make = "Mercedes-Benz", Model = "E Class", Year = 2010 };
            var car2 = new Car { Make = "Mercedes-Benz", Model = "S Class", Year = 2011 };
            var car3 = new Car { Make = "Mercedes-Benz", Model = "C Class", Year = 2018 };
            var car4 = new Car { Make = "Mercedes-Benz", Model = "A Class", Year = 2000 };
            _contextBST.Insert(car1);
            _contextBST.Insert(car2);
            _contextBST.Insert(car3);
            _contextBST.Insert(car4);

            _contextList.Insert(car1);
            _contextList.Insert(car2);
            _contextList.Insert(car3);
            _contextList.Insert(car4);
        }
        public void Add(IData data)
        {
            _contextBST.Insert(data);
            _contextList.Insert(data);
        }

        public void Delete(IData data)
        {
            _contextBST.DeleteBSTNodeById(data.Id);
            _contextList.Delete(data);
        }

        public IList GetAll()
        {
            return _contextList;
        }

        public IData GetById(int id)
        {
            var BSTNode = _contextBST.GetBSTNodeById(id);
            if(BSTNode == null)
            {
                return null;
            }
            return BSTNode.Data;
        }

        public IData Update(IData data)
        {
            var toUpdateInBst = _contextBST.GetBSTNodeById(data.Id);
            var toUpdateInList = _contextList.FindNodeInListByData(data);

            if (toUpdateInBst == null || toUpdateInList == null)
                return null;

            toUpdateInBst.Data = data;
            _contextBST.DeleteBSTNodeById(data.Id);
            _contextBST.Insert(toUpdateInBst.Data);

            toUpdateInList.Data = data;
            _contextList.Delete(data);
            _contextList.Insert(toUpdateInList.Data);

            return toUpdateInList.Data;
        }
    }
}
