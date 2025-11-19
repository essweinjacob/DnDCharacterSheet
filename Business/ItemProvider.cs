using Business.Interfaces;
using DataAccess.DAOs;
using DataAccess.Interfaces;

namespace Business
{
    public class ItemProvider : IItemProvider
    {
        public IItemDataConnection _dataConnection;

        public ItemProvider(IItemDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public IEnumerable<ItemModifier> GetItemModifiers(IEnumerable<int> itemIds)
        {
            return _dataConnection.GetItemModifiers(itemIds);
        }
    }
}
