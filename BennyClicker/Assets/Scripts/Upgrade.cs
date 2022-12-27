using UnitType;

namespace UpgradeClass
{
    public class Upgrade
    {
        public Upgrade(string spritePath, string name, bool isClickIncrease, unitInt number, unitInt price, unitInt increase)
        {
            SpritePath = spritePath;
            Name = name;
            IsClickIncrease = isClickIncrease;
            Price = price;
            Increase = increase;
            firstIncrease = increase;
            Number = number;
        }

        public string SpritePath { get; }
        public string Name { get; }
        public bool IsClickIncrease { get; }
        public unitInt Price { get; set; }
        public unitInt Increase { get; set; }
        public unitInt firstIncrease { get; set; }
        public unitInt Number { get; set; }

    }
}