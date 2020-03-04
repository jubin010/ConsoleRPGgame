namespace MyConsoleRPG
{
    internal class LingSwordAtkCard : Card
    {
        public LingSwordAtkCard()
        {
            Name = "灵剑击";
            Describe = string.Format("造成{0}的伤害,获得{1}点灵气", 3,1);
            EnergyCost = 0;
            CardType = CardTypes.器;
            CardSkills.Add(new BasalAtk(3));
            CardSkills.Add(new GetLing(1));
        }


    }
}