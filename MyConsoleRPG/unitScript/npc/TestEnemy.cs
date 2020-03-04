namespace MyConsoleRPG
{
    internal class TestEnemy : GameUnit
    {
        public TestEnemy()
        {
            Name = "测试敌人";
            UnitHp = UnitMaxHp = 25;
            Equipments.UnitWeapon = new BaseWoodSword();

            //掉落设定
            Inventorys.Add(new BaseWoodOrcCycle());
            Inventorys.Add(new BaseWoodSword());
            Inventorys.Add(new SwordShieldFunBook());
            Inventorys.Add(new GoldStone());
            Inventorys.Add(new GoldStone());
            Inventorys.Add(new WoodStone());
            Inventorys.Add(new WaterStone());
            Inventorys.Add(new FireStone());
            Inventorys.Add(new SoilStone());
            Inventorys.Add(new Wolfskin());
            Inventorys.Add(new Wolfskin());
            Inventorys.Add(new Wolfskin());
            

            ManMadeCard card = new ManMadeCard();
            card.Name = "千机变";
            card.EnergyCost = 1;
            card.CardType = Card.CardTypes.灵;
            card.Describe = "万法千机，随机应变";
            card.CardSkills.Add(new BasalAtk(1));
            card.CardSkills.Add(new GetHurt(1));
            card.CardSkills.Add(new GetLing(1));
            card.CardSkills.Add(new GetShield(3));
            ManMadeWeapon w = new ManMadeWeapon();
            w.Name = "千机伞*改";
            w.WeaponType = TheFiveElements.Gold;
            w.WeaponCards.Add(card);
            w.WeaponCards.Add(card);
            w.WeaponCards.Add(new BasalAtkCard());
            w.WeaponCards.Add(new BaseSwordAtkCard());
            w.WeaponCards.Add(new GiveShieldCard());
            w.WeaponCards.Add(new LingSwordAtkCard());


            Inventorys.Add(w);
            Inventorys.Add(w);

        }

        public override void SetBaseFun()
        {
            base.SetBaseFun();
            Functions.Add(new GoldBaseFun(Quality.地品));
            Functions.Add(new WoodBaseFun(Quality.地品));
            Functions.Add(new WaterBaseFun(Quality.地品));
            Functions.Add(new FireBaseFun(Quality.地品));
            Functions.Add(new SoilBaseFun(Quality.地品));
        }
    }
}