using DataAccess.DAOs;
using DataContracts;

namespace Business.Interfaces
{
    public interface IItemProvider
    {
        IEnumerable<Item> GetItems(IEnumerable<ItemQuantity> itemQuantities);
    }
}
