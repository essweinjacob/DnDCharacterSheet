using DataAccess.DAOs;
using DataAccess.Interfaces;
using DataContracts;

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
        }

        public IEnumerable<Stat> GetStatsForCharacter(int id)
        {
            return new List<Stat>()
            {
                new Stat() { StatType = StatType.Strength, Value = 10 },
                new Stat() { StatType = StatType.Dexterity, Value = 10 },
                new Stat() { StatType = StatType.Constitution, Value = 10 },
                new Stat() { StatType = StatType.Intelligence, Value = 10 },
                new Stat() { StatType = StatType.Wisdom, Value = 10 },
                new Stat() { StatType = StatType.Charisma, Value = 10 },
            };
        }

        public IEnumerable<Item> GetItemsForCharacter(int id)
        {
            return new List<Item>()
            {
                new Item() { ItemId = 1, Name = "Short Sword", Description = "A basic short sword.", Quantity = 1 },
                new Item() { ItemId = 2, Name = "Health Potion", Description = "Restores 10 HP.", Quantity = 3 },
            };
        }
    }
}
