using DataContracts;

namespace Business.Interfaces
{
    public interface ICharacterProvider
    {
        Character GetCharacter(int id);
    }
}
