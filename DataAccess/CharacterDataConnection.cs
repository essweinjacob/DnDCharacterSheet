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
    }
}
