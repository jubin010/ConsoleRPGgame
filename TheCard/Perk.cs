using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class Perk
    {
        public string Describe { get; set; }
        public string Symbol { get; set; }
        public CardSkill TriggerSkill { get; set; }
        public enum TriggerWays
        {
            ATK = 0,
            Shield = 1,
            PlayCard = 2,
        }

        public TriggerWays Way { get; set; }

        public virtual void TriggerPerk()
        {
            GameCore.Result.AppendLine(Describe);
        }
    }
}
