using System.Collections.Generic;
using System.Text;

namespace MyConsoleRPG
{
    internal class QuestShopRoomScript : InformationRoomScript
    {
        public QuestShopRoomScript()
        {
            Quests = new List<string>(100);
            SelectText = new List<string>(100);
            SelectQuest = new List<GameQuest>(100);
        }

        public List<string> Quests { get; set; }
        public int SelectIndex { get; set; }
        public List<string> SelectText { get; set; }
        public List<GameQuest> SelectQuest { get; set; }


        public override void SetSelect()
        {
            
        }

        public override void Runing()
        {
            DeBugRun();
            PrintHelper.PrintStoryText(new StringBuilder().Append(GameMainRecycle.InfoText), GameRoom.LineLength);
            QuestInfoRoomScript questRoom = (QuestInfoRoomScript)GameMainRecycle.RoomScripts.Group[typeof(QuestInfoRoomScript).Name];
            SelectText.Clear();
            SelectQuest.Clear();
            foreach (var item in Quests)
            {
                SelectQuest.Add(questRoom.Quests.Group[item]);
                SelectText.Add(questRoom.Quests.Group[item].Name);
            }
            OutRoom = LastRoom;
            if (RetureRoom == false)
                SelectIndex = 999;
            
            SelectIndex = PrintHelper.PrintSelectText(SelectText, SelectIndex);
            if (SelectIndex <= SelectText.Count)
            {
                GameMainRecycle.PlayerInfo.PlayerQuest = (GameQuest)SelectQuest[SelectIndex].Clone();
            }
         }
    }
}