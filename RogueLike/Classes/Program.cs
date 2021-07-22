using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RogueLike.Classes;

namespace RogueLike
{
    class MainClass
    {
        public static HUD hud;
        public static Map map;

        public static Hero hero;
        public static Monster monster;

        public static bool Reset;

        public static void Main(string[] args)
        {
            while (true)
            {
                #region Initialization

                Reset = false;

                hud = new HUD();
                map = new Map();

                map.ReadMap("map01");

                hero = new Hero();
                monster = new Monster(map);

                #endregion

                while (!Reset)
                {
                    Console.Clear();

                    hud.DisplayHUD(hero);

                    map.PlaceMonster(monster);
                    map.PlaceHero(hero);

                    map.GenerateMap();
                    hero.Action(ref Reset, map.TileMap);
                }
            }
        }
    }
}
