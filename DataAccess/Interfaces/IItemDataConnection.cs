using DataAccess.DAOs;

namespace DataAccess.Interfaces
{
    public interface IItemDataConnection
    {
        IEnumerable<ItemDetails> GetItems(IEnumerable<int> itemIds);
        IEnumerable<ItemModifier> GetItemModifiers(IEnumerable<int> itemIds);
    }
}
