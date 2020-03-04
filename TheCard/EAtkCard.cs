using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class EAtkCard:Card
    {
        public EAtkCard()
        {
            IsEnemyCard = true;
            CardSkills.Add(new EAtkSkill(5));
        }

        public override void RunResult()
        {
            base.RunResult();
            
        }
    }
}
