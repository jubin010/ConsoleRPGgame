using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class CardSkill
    {
        public string Describe { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public Perk.TriggerWays Way { get; set; }
        public int Atk { get; set; }
        public int Shield { get; set; }

        public virtual void RunSkill()
        {
            GameCore.Result.AppendLine(Describe);
        }
    }
}
