using Panzer0.MapGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.Base
{
    internal class Level
    {
        public string MapKey { get; }
        public int LevelNumber { get; }
        public Cell PlayerStartPosition { get; }
        public List<Cell> EnemiesStartPositions { get; }

        public Level(int levelNumber, Cell playerStartPosition, List<Cell> enemiesStartPositions)
        {
            LevelNumber = levelNumber;
            PlayerStartPosition = playerStartPosition;
            EnemiesStartPositions = enemiesStartPositions;
        }

    }
}
