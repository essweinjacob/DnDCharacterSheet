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
            IItemProvider itemProvider)
        {
            _dataConnection = dataConnection;
            _itemProvider = itemProvider;
        }

        public Character GetCharacter(int id)
        {
            CharacterDetails characterDetails = _dataConnection.GetCharacterDetails(id);
            IEnumerable<BaseStat> stats = _dataConnection.GetStatsForCharacter(id);
            IEnumerable<ItemDetails> itemDetails = _dataConnection.GetItemsForCharacter(id);
            IEnumerable<ItemModifier> itemModifiers = _itemProvider.GetItemModifiers(itemDetails.Select(_ => _.ItemId).ToList());
            Character character = new Character
            {
                CharacterDetails = characterDetails,
                Stats = CalculateStats(stats, itemModifiers),
                Inventory = GetItems(itemDetails, itemModifiers)
            };

            return character;
        }

        private IEnumerable<Stat> CalculateStats(IEnumerable<BaseStat> baseStats, IEnumerable<ItemModifier> items)
        {
            var baseStatsList = baseStats.ToList();
            var itemsList = items.ToList();

            return new List<Stat>()
            {
                CreateStat(StatType.Strength, baseStatsList, itemsList),
                CreateStat(StatType.Dexterity, baseStatsList, itemsList),
                CreateStat(StatType.Constitution, baseStatsList, itemsList),
                CreateStat(StatType.Intelligence, baseStatsList, itemsList),
                CreateStat(StatType.Wisdom, baseStatsList, itemsList),
                CreateStat(StatType.Charisma, baseStatsList, itemsList),
            };
        }

        private Stat CreateStat(StatType statType, List<BaseStat> baseStats, List<ItemModifier> items)
        {
            var baseStat = baseStats.FirstOrDefault(_ => _.StatType == statType);
            var itemModifiers = items.Where(_ => _.StatType == statType).ToList();
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

        private IEnumerable<Item> GetItems(IEnumerable<ItemDetails> itemDetails, IEnumerable<ItemModifier> itemModifiers)
        {
            var inventory = new List<Item>();
            itemDetails.ToList().ForEach(item =>
            {
                inventory.Add(new Item
                {
                    ItemId = item.ItemId,
                    Name = item.Name,
                    Description = item.Description,
                    Quantity = item.Quantity,
                    StatModifiers = itemModifiers.Where(_ => _.ItemId == item.ItemId).ToList()
                });
            });

            return inventory;
        }
    }
}
