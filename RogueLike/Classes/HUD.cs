using System;
namespace RogueLike.Classes
{
    public class HUD
    {
        public HUD()
        {
        }

        public void DisplayHUD(Hero hero)
        {
            var statLine = "| ATT : " + hero.Attack +
                " | DEF : " + hero.Defense +
                " | SPD : " + hero.Speed +
                " | LCK : " + hero.Luck +
                " |";

            var baseLine = "| " + hero.Name +
                " | LVL : " + hero.Level +
                " | HP : " + hero.Health[0] + "/" + hero.Health[1];

            var spaceLeft = statLine.Length - baseLine.Length - 1;
            for (int i = 0; i < spaceLeft; i++) baseLine += " ";
            baseLine += "|";

            var separator = "";
            for (int i = 0; i < statLine.Length; i++) separator += "-";

            Console.WriteLine(separator);
            Console.WriteLine(baseLine);
            Console.WriteLine(separator);
            Console.WriteLine(statLine);
            Console.WriteLine(separator);
            Console.WriteLine();
        }
    }
}
