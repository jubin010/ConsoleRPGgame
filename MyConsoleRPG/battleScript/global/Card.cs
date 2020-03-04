using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 卡牌分类：
    /// 武器卡：只能来自于武器自带的卡组，不消化灵气，重复获取
    /// 灵气卡：打出需要消耗灵气，重复获取
    /// 功法卡：打出后消耗，消耗灵气，生成对应被动
    /// 
    /// </summary>
    class Card : ICloneable
    {
        private int _energyCost;

        public string Name { get; set; }

        public string Describe { get; set; }
        public List<CardSkill> CardSkills { get; set; }
        public int EnergyCost { get
            {
                if (CardType == CardTypes.器)
                    _energyCost = 0;
                return _energyCost;
            } set => _energyCost = value; }
        public enum CardTypes
        {
            器 = 0,
            灵 = 1,
            法 = 2,
        }
        public CardTypes CardType { get; set; }

        public Card()
        {
            CardSkills = new List<CardSkill>(10);
            CardSkills.Add(new PlayCard());
        }


        public virtual void RunResult()
        {
            foreach (var item in CardSkills)
            {
                item.OwnerCard = this;
                item.RunSkill();
            }
        }


        public string ToCardSaveString()
        {
            CardSave save = new CardSave();
            if (GetType().Name != typeof(ManMadeCard).Name)
            {
                save.ClassName = GetType().Name;
            }
            else
            {
                save.ClassName = typeof(ManMadeCard).Name;
                save.Cname = Name;
                save.Cdescribe = Describe;
                save.Ctype = CardType;
                save.Ccost = EnergyCost;
                foreach (var item in CardSkills)
                {
                    save.SkillSaves.Add(item.ToJsonSkill());
                }
            }
            return Newtonsoft.Json.JsonConvert.SerializeObject(save);

        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
