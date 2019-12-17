using Core.Interfaces;
using DataStructure;
using DataStructure.Interfaces;
using Domain;

namespace Core
{
    public class CarRepository : IRepository
    {
        private static IBST _context = new BST();

        static CarRepository()
        {
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "E Class", Year = 2010 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "S Class", Year = 2011 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "C Class", Year = 2018 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "A Class", Year = 2000 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "E Class", Year = 2009 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "G Class", Year = 1999 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "GLE Class", Year = 2017 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "ML Class", Year = 2006 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "GLS Class", Year = 2019 });
            _context.Insert(new Car { Make = "Mercedes-Benz", Model = "V Class", Year = 2018 });
        }
        public void Add(IData data)
        {
            _context.Insert(data);
        }

        public void Delete(IData data)
        {
            _context.DeleteBSTNodeById(data.Id);
        }

        public IList GetAll()
        {
            return _context.GetAllNodes(_context.Root);
        }

        public IData GetById(int id)
        {
            var BSTNode = _context.GetBSTNodeById(id);
            if(BSTNode == null)
            {
                return null;
            }
            return BSTNode.Data;
        }

        public IData Update(IData data)
        {
            var toUpdate = _context.GetBSTNodeById(data.Id);

            if (toUpdate == null)
                return null;

            toUpdate.Data = data;
            _context.DeleteBSTNodeById(data.Id);
            _context.Insert(toUpdate.Data);

            return toUpdate.Data;
        }
    }
}
