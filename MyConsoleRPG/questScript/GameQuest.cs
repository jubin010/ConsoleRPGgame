using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class GameQuest : ICloneable//克隆接口
    {
        private string _questText;
        private bool _isComplete;

        public GameQuest()
        {
            Kills = new List<QuestKill>(4);
        }

        public List<QuestKill> Kills { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public string QuestText
        {
            get
            {
                _questText = string.Format
                    (@"[{0}]
  {1}
                    ", Name, Describe);
                return _questText;
            }
            private set => _questText = value;
        }
        public bool IsComplete
        {
            get
            {
                _isComplete = false;
                foreach (var item in Kills)
                {
                    if (item.NowKillCont == item.KillCont)
                        _isComplete = true;
                }
                return _isComplete;
            } private set => _isComplete = value; }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void ReSetQuest()
        {
            foreach (var item in Kills)
            {
                item.ReSetKlii();
            }
        }
    }
}
