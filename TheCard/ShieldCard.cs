using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class ShieldCard : Card
    {
        public ShieldCard()
        {
            Name = "防护2";
            Describe = "增加2点护甲";
            EnergyCost = 2;
            CardSkills.Add(new PShieldSkill(3));
        }
        public override void RunResult()
        {
            base.RunResult();
           
        }
    }
}
