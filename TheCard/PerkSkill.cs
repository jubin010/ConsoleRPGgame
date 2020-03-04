using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class PerkSkill : CardSkill
    {
        public PerkSkill()
        {
            Describe = "你增加了“获得”的能力";
        }

        public override void RunSkill()
        {
            GameCore.PlayerPerks.Add(new AtkGetEnergy());
            base.RunSkill();

        }
    }
}
