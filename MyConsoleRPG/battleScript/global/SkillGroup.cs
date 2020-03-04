using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SkillGroup
    {
        public Dictionary<string, CardSkill> Group { get; set; }
        public SkillGroup()
        {
            Group = new Dictionary<string, CardSkill>
            {
                #region 
                { typeof(PlayCard).Name, new PlayCard() },
                { typeof(BasalAtk).Name, new BasalAtk(0) },
                { typeof(GetHurt).Name, new GetHurt(0) },
                { typeof(GetShield).Name, new GetShield(0) },
                { typeof(GetLing).Name, new GetLing(0) },
                
                
                

                #endregion

                

               
            };
        }
    }
}
