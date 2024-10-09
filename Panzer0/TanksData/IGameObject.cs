using Panzer0.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.TanksData
{
    internal interface IGameObject
    {
        void Update(float deltaTime);
        void Draw(ConsoleRenderer renderer);
    }
}
