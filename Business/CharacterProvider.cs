using Business.Interfaces;
using DataAccess.Interfaces;
using DataAccess.DAOs;
using DataContracts;
using DataAccess;

namespace Business
{
    public class CharacterProvider : ICharacterProvider
    {
        private ICharacterDataConnection _dataConnection { get; set; }
        private IItemProvider _itemProvider { get; set; }

        public CharacterProvider(
            ICharacterDataConnection dataConnection,
            IItemProvider itemProvider
        )
        {
            _dataConnection = dataConnection;
            _itemProvider = itemProvider;
        }

        public Character GetCharacter(int id)
        {
            CharacterDetails characterDetails = _dataConnection.GetCharacterDetails(id);
            IEnumerable<BaseStat> stats = _dataConnection.GetStatsForCharacter(id);
            IEnumerable<ItemQuantity> characterItems = _dataConnection.GetCharacterItems(id);
            IEnumerable<Item> items = _itemProvider.GetItems(characterItems);
            Character character = new Character
            {
                CharacterDetails = characterDetails,
                Stats = CalculateStats(stats, items),
                Inventory = items
            };

            return character;
        }

        private IEnumerable<Stat> CalculateStats(IEnumerable<BaseStat> baseStats, IEnumerable<Item> items)
        {
            var baseStatsList = baseStats.ToList();

            return new List<Stat>()
            {
                CreateStat(StatType.Strength, baseStatsList, items),
                CreateStat(StatType.Dexterity, baseStatsList, items),
                CreateStat(StatType.Constitution, baseStatsList, items),
                CreateStat(StatType.Intelligence, baseStatsList, items),
                CreateStat(StatType.Wisdom, baseStatsList, items),
                CreateStat(StatType.Charisma, baseStatsList, items),
            };
        }

        private Stat CreateStat(StatType statType, IEnumerable<BaseStat> baseStats, IEnumerable<Item> items)
        {
            var baseStat = baseStats.FirstOrDefault(_ => _.StatType == statType);
            var itemModifiers = items.SelectMany(_ => _.StatModifiers).Where(_ => _.StatType == statType).ToList();
            var bonusValue = itemModifiers.Sum(_ => _.BonusValue);
            var bonusExplanations = itemModifiers.Select(_ => $"Item Bonus: {_.BonusValue}");
            var explanation = $"Base : {baseStat?.Value}" + (bonusExplanations.Any() ? ", " + string.Join(", ", bonusExplanations) : string.Empty);

            return new Stat()
            {
                StatType = statType,
                Value = (baseStat?.Value ?? 0) + bonusValue,
                Explanation = explanation
            };
        }
    }
}
