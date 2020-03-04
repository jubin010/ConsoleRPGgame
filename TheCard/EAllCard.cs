using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class EAllCard : Card
    {
        public EAllCard()
        {
            IsEnemyCard = true;
            CardSkills.Add(new EAtkSkill(5));
            CardSkills.Add(new EShieldSkill(3));
        }
    }
}
