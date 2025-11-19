using DataAccess.DAOs;
using DataAccess.Interfaces;

namespace DataAccess
{
    public class ItemDataConnection : IItemDataConnection
    {
        public IEnumerable<ItemModifier> GetItemModifiers(IEnumerable<int> itemIds)
        {
            return new List<ItemModifier>()
            {
                new ItemModifier()
                {
                    ItemId = 1,
                    StatType = StatType.Strength,
                    BonusValue = 2
                }
            };
        }
    }
}
