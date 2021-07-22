using System;
using System.IO;

namespace RogueLike.Classes
{
    public class Map
    {
        public Tile[,] TileMap { get; set; }

        public int MapSizeRow()
        {
            return TileMap.GetLength(0);
        }

        public int MapSizeColumn()
        {
            return TileMap.GetLength(1);
        }

        public Map()
        {

        }

        private int LinesNumber(string path)
        {
            var file = new StreamReader(path).ReadToEnd();
            var lines = file.Split(new char[] { '\n' });
            return lines.Length;
        }

        public void ReadMap(string mapToLoad)
        {
            String line;
            try
            {
                var path = "/Users/pierre/Documents/GitHub/RogueLike/RogueLike/Maps/" + mapToLoad + ".txt";
                StreamReader sr = new StreamReader(path);

                int count = 0;
                line = sr.ReadLine();

                var columns = line.Length;
                var rows = LinesNumber(path);

                TileMap = new Tile[rows, columns];

                while (line != null)
                {
                    var charArray = line.ToCharArray();

                    for (int i = 0; i < charArray.Length; i++)
                    {
                        TileMap[count, i] = new Tile(charArray[i]);
                    }

                    count++;
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void GenerateWalls(int min, int max)
        {
            var rng = new Random();
            var rngWalls = rng.Next(min, max + 1);

            for (int i = 0; i < rngWalls; i++)
            {
                var isPlaced = false;

                while (!isPlaced)
                {
                    var posX = rng.Next(0, MapSizeRow());
                    var posY = rng.Next(0, MapSizeColumn());

                    if (TileMap[posX, posY].Sprite == '.')
                    {
                        isPlaced = true;
                        TileMap[posX, posY] = new Tile('#');
                    }
                }
            }
        }

        public void PlaceHero(Hero hero)
        {
            TileMap[hero.PositionX, hero.PositionY] = new Tile('@');
        }

        public void PlaceMonster(Monster monster)
        {
            TileMap[monster.PositionX, monster.PositionY] = !monster.IsDead() ? new Tile('M') : new Tile('.');
        }

        public void DisplayMap()
        {
            for (int i = 0; i < TileMap.GetLength(0); i++)
            {
                for (int j = 0; j < TileMap.GetLength(1); j++)
                {
                    Console.ForegroundColor =
                        TileMap[i, j].Sprite == '@' ?
                        ConsoleColor.Green :
                        TileMap[i, j].Sprite == 'M' ?
                        ConsoleColor.Red :
                        TileMap[i, j].Sprite == '.' ?
                        ConsoleColor.DarkGray : ConsoleColor.White; ;
                    Console.Write(TileMap[i, j].Sprite);
                }
                Console.WriteLine();
            }
        }
    }
}
