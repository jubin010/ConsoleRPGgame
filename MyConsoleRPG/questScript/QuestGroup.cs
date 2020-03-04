using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class QuestGroup
    {
        public Dictionary<string, GameQuest> Group { get; set; }
        public QuestGroup()
        {
            Group = new Dictionary<string, GameQuest>
            {
                {typeof(TestQuest).Name,new TestQuest() },
                {typeof(TestQuest2).Name,new TestQuest2() },
                 {typeof(TestQuest3).Name,new TestQuest3() },
            };
        }
    }
}
