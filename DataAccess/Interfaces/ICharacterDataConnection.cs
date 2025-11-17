using DataAccess.DAOs;
using DataContracts;

namespace DataAccess.Interfaces
{
    public interface ICharacterDataConnection
    {
        CharacterDetails GetCharacterDetails(int id);
        IEnumerable<Stat> GetStatsForCharacter(int id);
        IEnumerable<Item> GetItemsForCharacter(int id);
    }
}
