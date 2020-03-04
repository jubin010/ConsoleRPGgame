using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class EShieldCard:Card
    {
        public EShieldCard()
        {
            IsEnemyCard = true;
            CardSkills.Add(new EShieldSkill(3));

        }

        public override void RunResult()
        {
            
            base.RunResult();
           
        }
    }
}
