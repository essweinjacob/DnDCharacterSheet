using DataContracts;

namespace DataAccess.Interfaces
{
    public interface ICharacterDataConnection
    {
        Character GetCharacter(int id);
        IEnumerable<Stat> GetStatsForCharacter(int id);
    }
}
