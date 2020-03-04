using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class BestAtkSkill:CardSkill
    {
        public override void RunSkill()
        {
            GameCore.Selfcore.HandCardGroup.Add(new BestAtkCard());
            base.RunSkill();
        }
    }
}
