namespace MyConsoleRPG
{
    internal class PlayCard : CardSkill
    {

        public override void RunScript()
        { 
            if (GameCore.IsPlayerRound)
                Describe = string.Format("你打出:{0}", OwnerCard.Name);
            else
                Describe = string.Format("敌方打出:{0}", OwnerCard.Name);
            
        }
    }
}