using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class TestBattleTile : MapTile
    {
        public TestBattleTile()
        {
            TileChar = '兽';
            TileType = TileTypes.battle;
            Units.Add(GameMainRecycle.NpcUnits.Group[typeof(TestEnemy).Name]);
            
            
        }
    }
}
