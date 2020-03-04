using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class QuestKill
    {
        private int _killCont;
        private int _nowKillCont;

        public QuestKill(string npcName, int killCont)
        {
            NpcName = npcName;
            KillCont = killCont;
        }

        public string NpcName { get; set; }
        public int KillCont
        {
            get
            {
                if (_killCont < 1)
                    _killCont = 1;
                return _killCont;
            }
            set => _killCont = value;
        }
        public int NowKillCont
        {
            get => _nowKillCont;
            set
            {
                if (value > KillCont)
                {
                    _nowKillCont = KillCont;
                }
                else
                {
                    _nowKillCont = value;
                }
            }
        }

        public void ReSetKlii()
        {
            NowKillCont = 0;
        }
    }
}
