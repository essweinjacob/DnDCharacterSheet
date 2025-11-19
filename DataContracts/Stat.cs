using DataAccess;

namespace DataContracts
{
    public class Stat
    {
        public StatType StatType { get; set; }
        public int Value { get; set; }
        public string Explanation { get; set; }
    }
}
