using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.MapGen
{
    public enum CellType
    {
        Road,
        Wall,
        DamagedWall,
        Water,
        Tank
    }

    public class Cell
    {
        public int X { get; }
        public int Y { get; }
        public CellType Type { get; set; }
        public static int Width { get; } = 5;
        public static int Height { get; } = 3;

        private static string _roadSymbol = " ";
        private static string _wallSymbol = "█";
        private static string _damagedWallSymbol = "░";
        private static string _waterSymbol = "▒";

        public Cell(int x, int y, CellType type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public string GetSymbol()
        {
            return Type switch
            {
                CellType.Road => _roadSymbol,
                CellType.Wall => _wallSymbol,
                CellType.DamagedWall => _damagedWallSymbol,
                CellType.Water => _waterSymbol,
                _ => _wallSymbol,
            };
        }
    }
}
