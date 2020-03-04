using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class BestAtkCard : Card
    {
        public BestAtkCard()
        {
            EnergyCost = 1;
            Name = "攻击2";
            Describe = "对敌方造成2点伤害";
            CardSkill pa = new PAtkSkill(2)
            {
                Way = Perk.TriggerWays.Shield
            };
            CardSkills.Add(pa);
            CardSkills.Add(new BestAtkSkill());
        }
    }
}
