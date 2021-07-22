using System;
namespace RogueLike.Classes
{
    public class Hero : Character
    {
        public Hero(string nm, int posX, int posY, int lvl, int[] hp,
            int att, int def, int spd, int lck)
            : base(nm, posX, posY, lvl, hp, att, def, spd, lck)
        {
        }

        public Hero(Map map, int bHP, int max) : base (map, bHP, max)
        {
        }

        public void Action(ref bool reset, Tile[,] map)
        {
            var input = Console.ReadKey();

            var futurePosX = PositionX;
            var futurePosY = PositionY;

            switch (input.Key)
            {
                case ConsoleKey.R:
                    reset = true;
                    break;

                case ConsoleKey.UpArrow:
                    futurePosX -= 1;
                    FutureTile(map, futurePosX, futurePosY);
                    break;

                case ConsoleKey.DownArrow:
                    futurePosX += 1;
                    FutureTile(map, futurePosX, futurePosY);
                    break;

                case ConsoleKey.RightArrow:
                    futurePosY += 1;
                    FutureTile(map, futurePosX, futurePosY);
                    break;

                case ConsoleKey.LeftArrow:
                    futurePosY -= 1;
                    FutureTile(map, futurePosX, futurePosY);
                    break;

                default:
                    break;
            }
        }

        private void FutureTile(Tile[,] map, int fPosX, int fPosY)
        {
            var fTile = map[fPosX, fPosY];
            switch (fTile.Type)
            {
                case Tile.TileType.Block:
                    if (fTile.IsPassable) Move(map, fPosX, fPosY);
                    break;

                case Tile.TileType.Entity:
                    Battle();
                    break;

                case Tile.TileType.Object:
                    GetObject();
                    break;

                case Tile.TileType.Exit:
                    Exit();
                    break;

                default:
                    break;
            }
        }

        private void Move(Tile[,] map, int fPosX, int fPosY)
        {
            var bufferHeroPosX = PositionX;
            var bufferHeroPosY = PositionY;

            var tileSprite = map[fPosX, fPosY].Sprite;
            var bufferTilePosX = fPosX;
            var bufferTilePosY = fPosY;

            map[bufferTilePosX, bufferTilePosY] = new Tile('@');
            map[bufferHeroPosX, bufferHeroPosY] = new Tile(tileSprite);

            PositionX = bufferTilePosX;
            PositionY = bufferTilePosY;
        }

        private void Battle()
        {

        }

        private void GetObject()
        {

        }

        private void Exit()
        {

        }
    }
}
