using System;

namespace MyConsoleRPG
{
    internal class GetHurt : CardSkill
    {
        public GetHurt(int h)
        {
            Hurt = h;
        }
        public override void RunScript()
        {
            
            if (GameCore.IsPlayerRound)
                PHurt();
            else
                EHurt();
            
        }

        private void EHurt()
        {
            GameCore.EHp -= Hurt;
            Describe = string.Format("  敌方生命受到{0}点伤害", Hurt);
        }

        private void PHurt()
        {
            GameCore.PHp -= Hurt;
            Describe = string.Format("  你的生命受到{0}点伤害", Hurt);
        }
    }
}