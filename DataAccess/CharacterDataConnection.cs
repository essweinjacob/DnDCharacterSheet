using DataAccess.Interfaces;
using DataContracts;

namespace DataAccess
{
    public class CharacterDataConnection : ICharacterDataConnection
    {
        public Character GetCharacter(int id)
        {
            return new Character()
            {
                CharacterId = 1,
                Name = "Test Name",
                Level = 1
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
    }
}
