using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class PAtkSkill:CardSkill
    {
        
        
        public PAtkSkill(int a)
        {
            Atk = a;
            Way = Perk.TriggerWays.ATK;
        }

        public override void RunSkill()
        {
           
            if (GameCore.EShield > 0)
            {
                if (GameCore.EShield >= Atk)
                {
                    GameCore.EShield -= Atk;
                    Describe = string.Format("你对敌方护甲造成了{0}伤害", Atk);
                }
                else
                {
                    
                    GameCore.EHp -= (Atk - GameCore.EShield);
                    
                    Describe = string.Format("你击破了敌方护甲，并对敌方生命造成了{0}伤害", Atk - GameCore.EShield);
                    GameCore.EShield = 0;
                }
            }
            else
            {
                GameCore.EHp -= Atk;
                Describe = string.Format("你对敌方生命造成了{0}伤害", Atk);
            }
            base.RunSkill();
            foreach (var item in GameCore.PlayerPerks)
            {
                if (item.Way == Way)
                {
                    item.TriggerPerk();
                }
            }
            
        }
    }
}
