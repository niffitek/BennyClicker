namespace UnitType
{
    public static class unitString
    {
        public static string[] units = new string[]
        {
            "",
            "Tausend",
            "Million",
            "Milliarde",
            "Billion",
            "Billiarde",
            "Trillion",
            "Trilliarde",
            "Quadrillion",
            "Quadrilliarde",
            "Quintillion",
            "Quintilliarde",
            "Sextillion (hehe)",
            "Sextilliarde (hehe)",
            "Septiollion",
            "Septilliarde",
            "Oktillion",
            "Oktilliarde",
            "Nonillion",
            "Nonilliarde",
            "Dezillion",
            "Dezilliarde",
            "Undezillion",
            "Undezilliarde",
            "Dodezillion",
            "Dodezilliarde",
            "Tredezillion",
            "Tredezilliarde",
            "Quattuordezillion",
            "Quattuordezilliarde",
            "Quindezillion",
            "Quindezilliarde",
            "Sexdezillion (hehe)",
            "Sexdezilliarde (hehe)",
            "Septendezillion",
            "Septendezilliarde",
            "Dodevigintillion",
            "Dodevigintilliarde",
            "Undevigintillion",
            "Undevigintilliarde",
            "Vigintillion",
            "Vigintilliarde",
            "Unvigintillion",
            "Unvigintilliarde",
            "Dovigintillion",
            "Dovigintilliarde",
        };
    }

    public class unitInt
    {
        public unitInt(double value, int unit)
        {
            Value = value;
            Unit = unit;
        }

        public double Value { get; set; }
        public int Unit { get; set; }

        public void Add(unitInt n)
        {
            if (n.Unit < Unit)
            {
                double tmpValue = n.Value;
                int tmpUnit = n.Unit;

                while (tmpUnit < Unit)
                {
                    tmpValue /= 1000;
                    tmpUnit += 1;
                }
                Value += tmpValue;
            }
            else if (n.Unit > Unit)
            {
                double tmpValue = n.Value;
                int tmpUnit = n.Unit;

                while (tmpUnit > Unit)
                {
                    Value /= 1000;
                    if (Unit < unitString.units.Length - 1)
                        Unit += 1;
                }
                Value += tmpValue;
                if (Value >= 1000)
                {
                    Value /= 1000;
                    if (Unit < unitString.units.Length - 1)
                        Unit += 1;
                }
            }
            else
            {
                Value += n.Value;
                if (Value >= 1000)
                {
                    Value /= 1000;
                    if (Unit < unitString.units.Length - 1)
                        Unit += 1;
                }
            }
        }

        public bool Sub(unitInt n)
        {
            double tmpValue = n.Value;
            int tmpUnit = n.Unit;
         
            if (n.Unit < Unit)
            {
                while (tmpUnit < Unit)
                {
                    tmpValue /= 1000;
                    tmpUnit += 1;
                }
            }
            Value -= tmpValue;
            if (Value < 1)
            {
                if (Unit > 0)
                {
                    Value *= 1000;
                    Unit -= 1;
                    return true;
                }
                else
                    return false;
            }
            return true;
        }

        public void Mult(double n)
        {
            Value *= n;

            while (Value > 1000)
            {
                Value /= 1000;
                if (Unit < unitString.units.Length - 1)
                    Unit += 1;
            }
        }

        public string toString()
        {
            if (Unit > 0)
                return (Value.ToString("0.000") + " " + unitString.units[Unit]);
            else
                return (Value.ToString("0") + " " + unitString.units[Unit]);
        }
    }
}