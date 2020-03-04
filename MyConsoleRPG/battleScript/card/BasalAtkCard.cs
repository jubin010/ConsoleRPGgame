namespace MyConsoleRPG
{
    internal class BasalAtkCard : Card
    {

        public BasalAtkCard()
        {
            Name = "拳击";
            Describe = string.Format("减少1点生命,造成{0}的伤害", 2);
            EnergyCost = 0;
            CardType = CardTypes.器;
            CardSkills.Add(new BasalAtk(2));
            CardSkills.Add(new GetHurt(1));

        }

      
    }
}