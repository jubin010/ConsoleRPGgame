using System;

namespace MyConsoleRPG
{
    internal class BasalAtk : CardSkill
    {
        public BasalAtk(int a)
        {
            Atk = a;

        }
        public override void RunScript()
        {
            if (GameCore.IsPlayerRound)
            PATK();
            else
            EATK();
        }

        private void EATK()
        {
            if (GameCore.PShield > 0)
            {
                if (GameCore.PShield >= Atk)
                {
                    GameCore.PShield -= Atk;
                    Describe = string.Format("  敌方对你的护甲造成了{0}伤害", Atk);
                }
                else
                {

                    GameCore.PHp -= (Atk - GameCore.PShield);
                    Describe = string.Format("  敌方击破了你的护甲，并对你造成了{0}伤害", Atk - GameCore.PShield);
                    GameCore.PShield = 0;
                }
            }
            else
            {
                GameCore.PHp -= Atk;
                Describe = string.Format("  敌方对你造成了{0}伤害", Atk);
            }

        }

        private void PATK()
        {
            if (GameCore.EShield > 0)
            {
                if (GameCore.EShield >= Atk)
                {
                    GameCore.EShield -= Atk;
                    Describe = string.Format("  你对敌方护甲造成了{0}伤害", Atk);
                }
                else
                {

                    GameCore.EHp -= (Atk - GameCore.EShield);

                    Describe = string.Format("  你击破了敌方护甲，并对敌方生命造成了{0}伤害", Atk - GameCore.EShield);
                    GameCore.EShield = 0;
                }
            }
            else
            {
                GameCore.EHp -= Atk;
                Describe = string.Format("  你对敌方生命造成了{0}伤害", Atk);
            }
        }
    }
}