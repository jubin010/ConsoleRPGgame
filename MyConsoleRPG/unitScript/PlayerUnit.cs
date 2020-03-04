using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 玩家单位
    /// </summary>
    class PlayerUnit:GameUnit
    {
        public PlayerUnit()
        {
            Name = "赵日天";
            UnitHp = UnitMaxHp = 50;
            Inventorys.Add(new GoldStone(0));
            Inventorys.Add(new WoodStone(0));
            Inventorys.Add(new WaterStone(0));
            Inventorys.Add(new FireStone(0));
            Inventorys.Add(new SoilStone(0));

            ManMadeWeapon temp = new ManMadeWeapon();
            temp.Name = "千机伞";
            temp.WeaponType = TheFiveElements.Gold;
            temp.WeaponCards.Add(new BasalAtkCard());
            temp.WeaponCards.Add(new BaseSwordAtkCard());
            temp.WeaponCards.Add(new GiveShieldCard());
            temp.WeaponCards.Add(new LingSwordAtkCard());
            Inventorys.Add(temp);
            Inventorys.Add((ManMadeWeapon)temp.Clone());
            

        }

     
     


        public override void SetBaseFun()
        {
            Functions.Add(new GoldBaseFun(Quality.地品));
            Functions.Add(new WoodBaseFun(Quality.地品));
            Functions.Add(new WaterBaseFun(Quality.天品));
            Functions.Add(new FireBaseFun(Quality.凡品));
            Functions.Add(new SoilBaseFun(Quality.地品));


            base.SetBaseFun();
        }
    }
}
