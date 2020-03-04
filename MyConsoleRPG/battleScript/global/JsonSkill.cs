using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// json>skill的桥梁类
    /// </summary>
    class JsonSkill
    {
        
        public string SkillName { get; set; }//skill实例检索名
        public string Describe { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Shield { get; set; }
        public int Hurt { get; set; }
        public int Ling { get; set; }

        public CardSkill CreatAndSetSkill() 
        {
            CardSkill skill = (CardSkill)GameMainRecycle.Skills.Group[SkillName].Clone();
            skill.Describe = Describe;
            skill.Symbol = Symbol;
            skill.Name = Name;
            skill.Atk = Atk;
            skill.Shield = Shield;
            skill.Hurt = Hurt;
            skill.Ling = Ling;
            return skill;
        }

    }
}
