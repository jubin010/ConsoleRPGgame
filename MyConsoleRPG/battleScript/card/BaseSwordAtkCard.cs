namespace MyConsoleRPG
{
    internal class BaseSwordAtkCard : Card
    {
        public BaseSwordAtkCard()
        {
            Name = "剑击";
            Describe = string.Format("造成{0}的伤害", 3);
            CardType = CardTypes.器;
            EnergyCost = 0;
            CardSkills.Add(new BasalAtk(3));
        }

        
    }
}