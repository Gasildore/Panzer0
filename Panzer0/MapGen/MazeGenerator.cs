using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.MapGen
{
    public class MazeGenerator
    {
        private IMazeAlgorithm _generationAlgorithm = new MazeAlgorithm();

        public MazeGenerator(IMazeAlgorithm algorithm)
        {
            _generationAlgorithm = algorithm;
        }

        public bool[,] Generate(int width, int height)
        {
            bool[,] maze = _generationAlgorithm.Generate(width, height);

            return maze;
        }
    }
}
