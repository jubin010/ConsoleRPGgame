using System;

namespace MyConsoleRPG
{
    internal class GetLing : CardSkill
    {
        

        public GetLing(int l)
        {
            Ling = l;
        }

        public override void RunScript()
        {
            if (GameCore.IsPlayerRound)
            {
                if (GameCore.Energy < GameCore.MaxEnergy)
                    PGetLing();
            }
            else
            {
                if (GameCore.EEnergy < GameCore.EMaxEnergy)
                    EGetLing();
            }  
        }

        private void EGetLing()
        {
            GameCore.EEnergy += Ling;
            Describe = string.Format("  敌方灵气+{0}",Ling);   
        }

        private void PGetLing()
        {
            GameCore.Energy += Ling;
            Describe = string.Format("  我方灵气+{0}", Ling);
        }
    }
}