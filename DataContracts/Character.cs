namespace DataContracts
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Class { get ; set; }
        public string Race { get; set; }
        public IEnumerable<Stat> Stats { get; set; }
    }
}
