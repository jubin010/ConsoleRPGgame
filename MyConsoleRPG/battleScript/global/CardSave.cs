using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class CardSave
    {
        public CardSave()
        {
            SkillSaves = new List<JsonSkill>(10);
        }

        public string ClassName { get; set; }
        public string Cname { get; set; }
        public Card.CardTypes Ctype { get; set; }
        public string Cdescribe { get; set; }
        public int Ccost { get; set; }
        public List<JsonSkill> SkillSaves { get; set; }
        
        public Card CreatAndSetCard()
        {
            Card card =(Card) GameMainRecycle.Cards.Group[ClassName].Clone();
            if (ClassName != typeof(ManMadeCard).Name)
                return card;
            else
            {
                card.Name = Cname;
                card.Describe = Cdescribe;
                card.CardType = Ctype;
                card.EnergyCost = Ccost;
                card.CardSkills.Clear();
                foreach (var item in SkillSaves)
                {
                    card.CardSkills.Add(item.CreatAndSetSkill());
                }

                return card;
            }
        }
    }

    

}
