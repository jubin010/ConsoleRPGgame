using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class NpcUnitGroup
    {
        public Dictionary<string, GameUnit> Group { get; set; }
        public NpcUnitGroup()
        {
            Group = new Dictionary<string, GameUnit>
            {
                { typeof(TestEnemy).Name, new TestEnemy() },
            };
        }
    }
}
