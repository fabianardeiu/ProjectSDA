using DataStructure.Interfaces;

namespace DataStructure
{
    public interface IBST
    {
        IBSTNode Root { get;set; }
        IBSTNode GetBSTNodeById(int id);

        void Insert(IData data);
        void DeleteBSTNodeById(int id);
        bool Search(IData data);
        void Inorder(IBSTNode root);
        IBSTNode GetBSTNodeParentById(int id);
    }
}
