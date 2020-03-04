using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class PerkCard : Card
    {
        public PerkCard()
        {
            EnergyCost = 2;
            Name = "能力牌";
            Describe = "增加能力";
            CardSkills.Add(new PerkSkill());
        }
        public override void RunResult()
        {
            base.RunResult();
            GameCore.Selfcore.PlayerCardGroup.Remove(this);
        }
    }
}
