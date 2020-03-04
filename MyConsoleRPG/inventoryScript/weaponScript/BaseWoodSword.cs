using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class BaseWoodSword:Weapon
    {
        public BaseWoodSword()
        {
            Name = "基础修行木剑";
            WeaponType = TheFiveElements.Gold;
        }
        public override void SetWeaponCards()
        {
            base.SetWeaponCards();
            WeaponCards.Add(new BaseSwordAtkCard());
            WeaponCards.Add(new BaseSwordAtkCard());
            WeaponCards.Add(new LingSwordAtkCard());
            

        }
    }
}
