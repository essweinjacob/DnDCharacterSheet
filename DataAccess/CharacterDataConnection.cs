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
        }

        public IEnumerable<BaseStat> GetStatsForCharacter(int id)
        {
            return new List<BaseStat>()
            {
                new BaseStat() { StatType = StatType.Strength, Value = 10 },
                new BaseStat() { StatType = StatType.Dexterity, Value = 10 },
                new BaseStat() { StatType = StatType.Constitution, Value = 10 },
                new BaseStat() { StatType = StatType.Intelligence, Value = 10 },
                new BaseStat() { StatType = StatType.Wisdom, Value = 10 },
                new BaseStat() { StatType = StatType.Charisma, Value = 10 },
            };
        }

        public IEnumerable<ItemDetails> GetItemsForCharacter(int id)
        {
            return new List<ItemDetails>()
            {
                new ItemDetails() { ItemId = 1, Name = "Short Sword", Description = "A basic short sword.", Quantity = 1 },
                new ItemDetails() { ItemId = 2, Name = "Health Potion", Description = "Restores 10 HP.", Quantity = 3 },
            };
        }
    }
}
