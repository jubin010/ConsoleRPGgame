using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class AtkCard:Card
    {
        public AtkCard()
        {
            
            EnergyCost = 0;
            Name = "攻击5";
            Describe = "对敌方造成5点伤害";
            CardSkills.Add(new PAtkSkill(5));
        }

        public override void RunResult()
        {
            base.RunResult();
            
        }
    }
}
