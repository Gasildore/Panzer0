using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.MapGen
{    
    public interface IMazeAlgorithm
    {
        bool[,] Generate(int width, int height);
    }
}
