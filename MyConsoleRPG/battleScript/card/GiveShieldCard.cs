namespace MyConsoleRPG
{
    internal class GiveShieldCard : Card
    {
        public GiveShieldCard()
        {
            Name = "剑罡";
            Describe = string.Format("获得{0}点护甲", 5);
            EnergyCost = 1;
            CardType = CardTypes.灵;
            CardSkills.Add(new GetShield(5));
            
        }

        
    }
}