using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class Weapon:Equipment
    {
        public TheFiveElements WeaponType { get;  set; }
        public List<Card> WeaponCards { get; set; }

        public Weapon()
        {
            EqType = EquipmentType.weapon;
            WeaponCards = new List<Card>(20);
            SetWeaponCards();
        }

   

        public virtual void SetWeaponCards()
        {

        }



    }
}
