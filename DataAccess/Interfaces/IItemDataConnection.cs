using DataAccess.DAOs;

namespace DataAccess.Interfaces
{
    public interface IItemDataConnection
    {
        IEnumerable<ItemModifier> GetItemModifiers(IEnumerable<int> itemIds);
    }
}
