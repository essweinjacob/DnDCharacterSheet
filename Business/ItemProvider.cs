using Business.Interfaces;
using DataAccess.DAOs;
using DataAccess.Interfaces;
using DataContracts;

namespace Business
{
    public class ItemProvider : IItemProvider
    {
        public IItemDataConnection _dataConnection;

        public ItemProvider(IItemDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public IEnumerable<Item> GetItems(IEnumerable<ItemQuantity> itemQuantities)
        {
            var itemIds = itemQuantities.Select(_ => _.ItemId);

            var itemDetails = _dataConnection.GetItems(itemIds);
            var itemModifiers = _dataConnection.GetItemModifiers(itemIds);


            var inventory = new List<Item>();
            itemQuantities.ToList().ForEach(iq =>
            {
                var itemDetail = itemDetails.FirstOrDefault(_ => _.ItemId == iq.ItemId);
                if (itemDetail != null)
                {
                    inventory.Add(new Item
                    {
                        ItemId = itemDetail.ItemId,
                        Name = itemDetail.Name,
                        Description = itemDetail.Description,
                        Quantity = iq.Quantity,
                        StatModifiers = itemModifiers.Where(_ => _.ItemId == itemDetail.ItemId).ToList()
                    });
                }
            });

            return inventory;
        }
    }
}
