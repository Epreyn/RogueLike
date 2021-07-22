using System;
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

        public Character(Map map)
        {
            var rng = new Random();
            var isPlaced = false;

            Name = "MONSTER";

            while (!isPlaced)
            {
                PositionX = rng.Next(0, map.MapSizeRow());
                PositionY = rng.Next(0, map.MapSizeColumn());

                if (map.TileMap[PositionX, PositionY].Sprite == '.')
                    isPlaced = true;
            }

            Level = 1;

            var rngHealth = rng.Next(5, 21);
            Health = new int[2] { rngHealth, rngHealth };

            var rngAttack = rng.Next(1, 6);
            Attack = rngAttack;

            var rngDefense = rng.Next(1, 6);
            Defense = rngDefense;

            var rngSpeed = rng.Next(1, 6);
            Speed = rngSpeed;

            var rngLuck = rng.Next(1, 6);
            Luck = rngLuck;
        }

        public Character()
        {
            var rng = new Random();

            Name = "RANDOM";
            PositionX = 1;
            PositionY = 1;
            Level = 1;

            var rngHealth = rng.Next(5, 21);
            Health = new int[2] { rngHealth, rngHealth };

            var rngAttack = rng.Next(2, 11);
            Attack = rngAttack;

            var rngDefense = rng.Next(2, 11);
            Defense = rngDefense;

            var rngSpeed = rng.Next(2, 11);
            Speed = rngSpeed;

            var rngLuck = rng.Next(2, 11);
            Luck = rngLuck;
        }

        public bool IsDead()
        {
            return Health[0] <= 0;
        }
    }
}
