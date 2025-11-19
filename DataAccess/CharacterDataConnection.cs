using DataAccess.DAOs;
using DataAccess.Interfaces;

namespace DataAccess
{
    public class CharacterDataConnection : ICharacterDataConnection
    {
        public CharacterDetails GetCharacterDetails(int id)
        {
            return new CharacterDetails()
            {
                CharacterId = 1,
                Name = "Elyric",
                Level = 4,
                Race = "Half Elf",
                Class = "Sorcerrer",
                SubClass = "Wild Magic"
            };
            /* Table Design
             * Name: Characters
             * Columns:
             * [CharacterId] INT PRIMARY KEY,
             * [Name] NVARCHAR(25) NOT NULL,
             * [Level] INT NOT NULL,
             * [Race] NVARCHAR(25) NOT NULL,
             * [Class] NVARCHAR(25) NOT NULL,
             * [SubClass] NVARCHAR(25) NULL
             */
        }

        public IEnumerable<BaseStat> GetStatsForCharacter(int id)
        {
            return new List<BaseStat>()
            {
                new BaseStat() { CharacterId = 1, StatType = StatType.Strength, Value = 10 },
                new BaseStat() { CharacterId = 1, StatType = StatType.Dexterity, Value = 10 },
                new BaseStat() { CharacterId = 1, StatType = StatType.Constitution, Value = 10 },
                new BaseStat() { CharacterId = 1, StatType = StatType.Intelligence, Value = 10 },
                new BaseStat() { CharacterId = 1, StatType = StatType.Wisdom, Value = 10 },
                new BaseStat() { CharacterId = 1, StatType = StatType.Charisma, Value = 10 },
            };
            /* Table Design
             * Name: CharacterStats
             * Columns:
             * [CharacterId] INT FOREIGN KEY REFERENCES Characters(CharacterId),
             * [StatType] INT NOT NULL,
             * [Value] INT NOT NULL,
             * PRIMARY KEY (CharacterId, StatType)
             */
        }

        public IEnumerable<ItemQuantity> GetCharacterItems(int id)
        {
            return new List<ItemQuantity>()
            {
                new ItemQuantity() { ItemId = 1, Quantity = 1 },
                new ItemQuantity() { ItemId = 2, Quantity = 3 },
            };
            /*
             * Table Design
             * Name: CharacterItems
             * Columns:
             * [CharacterId] INT FOREIGN KEY REFERENCES Characters(CharacterId),
             * [ItemId] INT FOREIGN KEY REFERENCES Items(ItemId),
             * [Quantity] INT NOT NULL,
             * PRIMARY KEY (CharacterId, ItemId)
             */
        }
    }
}
