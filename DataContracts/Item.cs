using DataAccess.DAOs;

namespace DataContracts
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public IEnumerable<ItemModifier> StatModifiers { get; set; }
    }
}
