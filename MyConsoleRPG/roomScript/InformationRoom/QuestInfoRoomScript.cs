using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 任务查看房间
    /// </summary>
    class QuestInfoRoomScript:InformationRoomScript
    {
        public QuestGroup Quests { get; set; }

        public QuestInfoRoomScript()
        {
            Quests = new QuestGroup(); 
        }

        
         
        public override void Runing()
        {
            GameQuest pq = GameMainRecycle.PlayerInfo.PlayerQuest;
            if (pq != null)
            {
                if(pq.IsComplete)
                    GameMainRecycle.InfoText =string.Format("{0}\r\n状态：已完成 ",  pq.QuestText);
                else
                    GameMainRecycle.InfoText = string.Format("{0}\r\n状态：未完成 ", pq.QuestText);
            }
            else
            {
                GameMainRecycle.InfoText = "当前未接取任务";
            }

            base.Runing();
            Console.WriteLine("击杀目标：");
            if(pq != null)
            {
                foreach (var item in pq.Kills)
                {
                    Console.WriteLine("    {0}<{1}/{2}>",item.NpcName,item.NowKillCont,item.KillCont);
                }
            }
        }
    }
}
