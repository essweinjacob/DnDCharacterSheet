using DataAccess.DAOs;

namespace DataAccess.Interfaces
{
    public interface ICharacterDataConnection
    {
        CharacterDetails GetCharacterDetails(int id);
        IEnumerable<BaseStat> GetStatsForCharacter(int id);
        IEnumerable<ItemDetails> GetItemsForCharacter(int id);
    }
}
