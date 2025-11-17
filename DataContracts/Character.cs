using DataAccess.DAOs;

namespace DataContracts
{
    public class Character
    {
        public CharacterDetails CharacterDetails { get; set; }
        public IEnumerable<Stat> Stats { get; set; }
        public IEnumerable<Item> Inventory { get; set; }
    }
}
