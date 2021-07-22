using System;
namespace RogueLike.Classes
{
    public class Modifier
    {
        public Modifier()
        {
        }

        //private void DefineStatisticDie(int stat, ref Vector2 die)
        //{
        //    if (stat < 3) die = new Vector2(1, 2);
        //    else if (stat == 3 || stat == 4) die = new Vector2(2, 2);
        //    else die = new Vector2(4, 2);
        //}

        public int Roll(int dices, int faces)
        {
            var result = 0;
            var rng = new Random();
            for (var i = 0; i < dices; i++) result += rng.Next(1, faces + 1);
            return result;
        }
    }
}
