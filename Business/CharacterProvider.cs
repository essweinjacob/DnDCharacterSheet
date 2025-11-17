using Business.Interfaces;
using DataAccess.Interfaces;
using DataContracts;

namespace Business
{
    public class CharacterProvider : ICharacterProvider
    {
        private ICharacterDataConnection _dataConnection { get; set; }

        public CharacterProvider(ICharacterDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }

        public Character GetCharacter(int id)
        {
            Character character = _dataConnection.GetCharacter(id);
            character.Stats = _dataConnection.GetStatsForCharacter(id);

            return character;
        }
    }
}
