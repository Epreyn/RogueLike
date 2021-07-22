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

                hero = new Hero(map, 10, 10);
                monster = new Monster(map, 5, 5);

                map.GenerateWalls(10, 60);

                #endregion

                while (!Reset)
                {
                    Console.Clear();

                    hud.DisplayHUD(hero);

                    map.PlaceMonster(monster);
                    map.PlaceHero(hero);

                    map.DisplayMap();
                    hero.Action(ref Reset, map.TileMap);
                }
            }
        }
    }
}
