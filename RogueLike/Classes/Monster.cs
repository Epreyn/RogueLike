using System;
namespace RogueLike.Classes
{
    public class Monster : Character
    {
        public Monster(string nm, int posX, int posY, int lvl, int[] hp,
                int att, int def, int spd, int lck)
                : base(nm, posX, posY, lvl, hp, att, def, spd, lck)
        {
        }

        public Monster(Map map, int bHP, int max) : base(map, bHP, max)
        {
        }
    }
}
