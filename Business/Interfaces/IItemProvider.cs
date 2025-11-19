using DataAccess.DAOs;

namespace Business.Interfaces
{
    public interface IItemProvider
    {
        IEnumerable<ItemModifier> GetItemModifiers(IEnumerable<int> itemIds);
    }
}
