using Panzer0.MapGen;
using Panzer0.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panzer0.TanksData
{
    internal class PlayerTank : Tank
    {
        public override TankType Type => TankType.Player;
        public override byte TankColor => 2;

        public PlayerTank(Cell startPosition, GameMap gameMap, GameObjectsSystem gameObjectsSystem, LevelSystem levelSystem)
            : base(startPosition, gameMap, gameObjectsSystem, levelSystem, 3) { }

        public void ResetHealth()
        {
            Health = 3;
        }
    }
}
