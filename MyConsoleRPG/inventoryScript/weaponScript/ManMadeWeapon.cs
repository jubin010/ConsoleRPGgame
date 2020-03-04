using System.Collections.Generic;

namespace MyConsoleRPG
{
    class ManMadeWeapon : Weapon
    {
        public class WeaponSave
        {
            public WeaponSave()
            {
                Cards = new List<string>(20);
            }

            public  TheFiveElements Wtype { get; set; }
            public  string Wname { get; set; } 
            public List<string> Cards { get; set; }
        }

        public void SetManMadeByJson(string js)
        {
            WeaponSave ws = Newtonsoft.Json.JsonConvert.DeserializeObject<WeaponSave>(js);
            Name = ws.Wname;
            WeaponType = ws.Wtype;
            WeaponCards.Clear();
            foreach (var item in ws.Cards)
            {
                CardSave cardSave = Newtonsoft.Json.JsonConvert.DeserializeObject<CardSave>(item);
                WeaponCards.Add (cardSave.CreatAndSetCard());
            }
        }

        public InventorySave ToInventorySave()
        {
            InventorySave temp = new InventorySave();
            temp.InventoryName = GetType().Name;
            temp.InventoryCont = 1;
            WeaponSave ws = new WeaponSave();
            ws.Wname = Name;
            ws.Wtype = WeaponType;
            foreach (var item in WeaponCards)
            {

                ws.Cards.Add(item.ToCardSaveString());
            }

            temp.JsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ws);
            return temp;
        }
    }
}