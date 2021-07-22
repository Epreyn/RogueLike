using System;
using System.Collections.Generic;

namespace RogueLike.Classes
{
    public class Character
    {
        #region FIELDS

        public string Name { get; set; }

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public int Level { get; set; }

        public int[] Health { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int Luck { get; set; }

        #endregion

        public Character(string name, int positionX, int positionY, int level, int[] health,
            int attack, int defense, int speed, int luck)
        {
            Name = name;
            PositionX = positionX;
            PositionY = positionY;
            Level = level;
            Health = health;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            Luck = luck;
        }

        public Character(Map map, int baseHP, int maxStat)
        {
            var rng = new Random();
            var isPlaced = false;
            var pointsToAttribute = maxStat * 3;

            var rngNameLength = rng.Next(3, 5);
            Name = GenerateName(rngNameLength);

            while (!isPlaced)
            {
                PositionX = rng.Next(0, map.MapSizeRow());
                PositionY = rng.Next(0, map.MapSizeColumn());

                if (map.TileMap[PositionX, PositionY].Sprite == '.')
                    isPlaced = true;
            }

            Level = 1;

            for (int i = 0; i < 5; i++)
            {
                var rngStat = pointsToAttribute < maxStat ?
                    rng.Next(1, pointsToAttribute / 2 + 1) :
                    rng.Next(1, maxStat + 1);

                switch (i)
                {
                    case 0:
                        Attack = rngStat;
                        break;

                    case 1:
                        Defense = rngStat;
                        break;

                    case 2:
                        Speed = rngStat;
                        break;

                    case 3:
                        Luck = rngStat;
                        break;

                    case 4:
                        if (pointsToAttribute > 0) rngStat = pointsToAttribute;
                        Health = new int[2] { rngStat + baseHP, rngStat + baseHP };
                        break;
                    default:
                        break;
                }

                pointsToAttribute -= rngStat;
                if (pointsToAttribute < 0) pointsToAttribute = 0;
            }
        }

        public bool IsDead()
        {
            return Health[0] <= 0;
        }

        private static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2;
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }
            return Name;
        }
    }
}
