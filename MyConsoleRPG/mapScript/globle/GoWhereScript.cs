using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    struct GoWhereScript
    {
        public GoWhereScript(Type goWhere, int nextStarX, int nextStarY)
        {
            GoWhere = goWhere;
            NextStarX = nextStarX;
            NextStarY = nextStarY;
        }

        public Type GoWhere { get; set; }//地图转换图块去往得地图
        public int NextStarX { get; set; }
        public int NextStarY { get; set; }
    }
}
