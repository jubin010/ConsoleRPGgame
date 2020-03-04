using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class PShieldSkill : CardSkill
    {
        public PShieldSkill(int s)
        {
            Shield = s;
        }

        public override void RunSkill()
        {
            GameCore.PShield += Shield;
            Describe = string.Format("你的护甲增加了{0}", Shield);
            base.RunSkill();
            
        }
    }
}
