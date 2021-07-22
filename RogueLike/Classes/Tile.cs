using System;
using System.Collections.Generic;

namespace RogueLike.Classes
{
    public class Tile
    {
        private List<char> _passableChars = new List<char>() {
            '.',
            'O',
            'E'
        };

        public enum TileType {
            Block,
            Entity,
            Object,
            Exit
        };

        public char Sprite { get; private set; }
        public bool IsPassable { get; private set; }
        public TileType Type { get; private set; }

        public Tile(char sprite)
        {
            Sprite = sprite;
            IsPassable = _passableChars.Contains(sprite);
            Type = sprite switch
            {
                '@' => TileType.Entity,
                'M' => TileType.Entity,
                'V' => TileType.Entity,

                'E' => TileType.Exit,

                'O' => TileType.Object,

                _ => TileType.Block,
            };
        }
    }
}
