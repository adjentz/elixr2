using System;
using System.Linq;
using System.Security.Cryptography;

namespace Elixr2.Api.Models
{
    public class Dice
    {
        private readonly RandomNumberGenerator rng;
        public Dice(int amount, int sides)
        {
            rng = RandomNumberGenerator.Create();
        }

        private int NextInt(int minInclusive, int maxInclusive)
        {
            byte[] fourBytes = new byte[4];
            rng.GetBytes(fourBytes);

            uint scale = BitConverter.ToUInt32(fourBytes, 0);
            return (int)(minInclusive + (maxInclusive + 1 - minInclusive) * (scale / (uint.MaxValue + 1.0)));
        }
        public static Dice FromNotation(string notation)
        {
            string[] parts = notation?.Split('d', 'D');
            if(parts?.Length != 2)
            {
                throw new ArgumentException("Notation is invalid");
            }
            
            int amount = int.Parse(parts[0]);
            int sides = int.Parse(parts[1]);
            return new Dice(amount, sides);
        }
        public int Amount { get; }
        public int Sides { get; }
        public int AverageRoll
        {
            get
            {
                return (int)Math.Ceiling(Sides * 1.0 / 2) * Amount;
            }
        }
        public int Roll() => Enumerable.Range(0, Amount).Sum(i => NextInt(1, Sides));
    }
}