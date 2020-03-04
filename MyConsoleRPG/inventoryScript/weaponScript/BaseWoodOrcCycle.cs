using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class BaseWoodOrcCycle : Weapon
    {
        public BaseWoodOrcCycle()
        {
            Name = "基础修行藤环";
            WeaponType = TheFiveElements.Wood;
        }

        public override void SetWeaponCards()
        {
            base.SetWeaponCards();
            WeaponCards.Add(new LingSwordAtkCard());
            WeaponCards.Add(new GiveShieldCard());
        }
    }
}
