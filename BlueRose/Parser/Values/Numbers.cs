using System;
using System.Collections.Generic;
using System.Text;

namespace BlueRose.Parser.Values
{
    internal class Numbers : VALUES
    {
        public double value { get; set; } = 0.0;
        private int start_pos = 0;
        private int end_pos = 0;

        public void SetPosition(int start, int end)
        {
            start_pos = start;
            end_pos = end;
        }
        public Numbers(double val)
        {
            value = val;
        }

        public Numbers AddOperation(Numbers other)
        {
            if (other.GetType() == typeof(Numbers))
                return new Numbers(value + other.value);
            else throw new Exception("Error ...");
        }
        public Numbers SubOperation(Numbers other)
        {
            if (other.GetType() == typeof(Numbers))
                return new Numbers(value - other.value);
            else throw new Exception("Error ...");
        }

        public Numbers MulOperation(Numbers other)
        {
            if (other.GetType() == typeof(Numbers))
                return new Numbers(value * other.value);
            else throw new Exception("Error ...");
        }
        public Numbers DivOperation(Numbers other)
        {
            if (other.GetType() == typeof(Numbers))
                return new Numbers(value / other.value);
            else throw new Exception("Error ...");
        }

        public override string print()
        {
            return $"{this.value}";
        }
    }
}
