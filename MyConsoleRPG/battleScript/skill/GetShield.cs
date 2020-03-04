using System;

namespace MyConsoleRPG
{
    internal class GetShield : CardSkill
    {
        public GetShield(int s)
        {
            Shield = s;
        }

        public override void RunScript()
        {

            if (GameCore.IsPlayerRound)
                PShield();
            else
                EShield();
            
        }

        private void EShield()
        {
            GameCore.EShield += Shield;
            Describe = string.Format("  敌方护甲增加了{0}", Shield);
            
        }

        private void PShield()
        {
            GameCore.PShield += Shield;
            Describe = string.Format("  你的护甲增加了{0}", Shield);
            
        }
    }
}