using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class QuestBaseTile : MapTile
    {
        public QuestBaseTile()
        {
            TileType = TileTypes.quest;
            TileText = "这里是南务阁，是南谷镇接取宗门任务的地方";
            Quests.Add(typeof(TestQuest).Name);
            Quests.Add(typeof(TestQuest2).Name);
            Quests.Add(typeof(TestQuest3).Name);

        }
    }
}
