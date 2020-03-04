using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class EmptyHanded:Weapon
    {
        public EmptyHanded()
        {
            Name = "空";
            WeaponType = TheFiveElements.Wood;
        }


        public override void SetWeaponCards()
        {
            base.SetWeaponCards();
            WeaponCards.Add(new BasalAtkCard());
            WeaponCards.Add(new BasalAtkCard());
            WeaponCards.Add(new BasalAtkCard());
        }
    }
}
