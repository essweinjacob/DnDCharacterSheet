using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.DAOs;
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
            CharacterDetails characterDetails = _dataConnection.GetCharacterDetails(id);
            IEnumerable<Stat> Stats = _dataConnection.GetStatsForCharacter(id);
            IEnumerable<Item> Inventory = _dataConnection.GetItemsForCharacter(id);
            Character character = new Character
            {
                CharacterDetails = characterDetails,
                Stats = Stats,
                Inventory = Inventory
            };

            return character;
        }
    }
}
