using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class EAtkSkill : CardSkill
    {
        public EAtkSkill(int a)
        {
            Atk = a;
            Symbol = string.Format("攻{0}", Atk);
        }

        public override void RunSkill()
        {
            
            if (GameCore.PShield > 0)
            {
                if (GameCore.PShield >= Atk)
                {
                    GameCore.PShield -= Atk;
                    Describe = string.Format("敌方对你的护甲造成了{0}伤害", Atk);
                }
                else
                {
                    
                    GameCore.PHp -= (Atk - GameCore.PShield);
                    Describe = string.Format("敌方击破了你的护甲，并对你造成了{0}伤害", Atk - GameCore.PShield);
                    GameCore.PShield = 0;
                }
            }
            else
            {
                GameCore.PHp -= Atk;
                Describe = string.Format("敌方对你造成了{0}伤害", Atk);
            }
                
            base.RunSkill();
        }
    }
}
