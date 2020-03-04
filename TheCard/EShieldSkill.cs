using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class EShieldSkill : CardSkill
    {
        public EShieldSkill(int s)
        {
            Shield = s;
            Symbol = string.Format("防{0}", Shield);
        }
        public override void RunSkill()
        {
            GameCore.EShield += Shield;
            Describe = string.Format("敌方的护甲增加了{0}", Shield);
            base.RunSkill();

        }
    }
}
