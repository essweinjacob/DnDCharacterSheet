using DataAccess.DAOs;
using DataAccess.Interfaces;

namespace DataAccess
{
    public class ItemDataConnection : IItemDataConnection
    {

        public IEnumerable<ItemDetails> GetItems(IEnumerable<int> itemIds)
        {
            return new List<ItemDetails>()
            {
                new ItemDetails() { ItemId = 1, Name = "Short Sword", Description = "A basic short sword." },
                new ItemDetails() { ItemId = 2, Name = "Health Potion", Description = "Restores 10 HP." },
            };
            /*
             * Table Design
             * Name: CharacterItems
             * [ItemId] INT PRIMARY KEY,
             * [Name] NVARCHAR(50) NOT NULL,
             * [Description] NVARCHAR(255) NULL
             * */
        }

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
            /*
             * Table Design
             * [ItemId] INT FOREIGN KEY REFERENCES Items(ItemId),
             * [StatType] INT NOT NULL,
             * [BonusValue] INT NOT NULL,
             * PRIMARY KEY (ItemId, StatType)
             */
        }
    }
}
