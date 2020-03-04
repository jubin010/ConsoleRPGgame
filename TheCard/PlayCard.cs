using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class PlayCard:CardSkill
    {
        public PlayCard(Card c)
        {
            GetCard = c;
            
        }

        public Card GetCard { get; set; }
        public override void RunSkill()
        {
            if (GetCard.IsEnemyCard == false)
                Describe = string.Format("你打出:{0}", GetCard.Name);
            base.RunSkill();
            if (GetCard.IsEnemyCard == false)
            {
                foreach (var item in GameCore.PlayerPerks)
                {
                    if (item.Way == Perk.TriggerWays.PlayCard)
                    {
                        item.TriggerPerk();
                    }
                }   

            }
           
        }
    }
}
