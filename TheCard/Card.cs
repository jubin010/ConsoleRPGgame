using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class Card
    {
        
        public bool IsEnemyCard { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public List<CardSkill> CardSkills { get; set; }
        public int EnergyCost { get; set; }

        public Card()
        {
            CardSkills = new List<CardSkill>(10);
            CardSkills.Add(new PlayCard(this));
        }

        public virtual void RunResult()
        {
            foreach (var item in CardSkills)
            {
                item.RunSkill();
            }
        }
    }
}
