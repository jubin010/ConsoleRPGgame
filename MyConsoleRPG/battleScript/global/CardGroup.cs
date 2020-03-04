using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class CardGroup
    {
        public Dictionary<string, Card> Group { get; set; }
        public CardGroup()
        {
            Group = new Dictionary<string, Card>
            {
                {typeof(ManMadeCard).Name,new ManMadeCard() },
                #region 器
                { typeof(BasalAtkCard).Name, new BasalAtkCard() },
                { typeof(BaseSwordAtkCard).Name, new BaseSwordAtkCard() },
                { typeof(LingSwordAtkCard).Name, new LingSwordAtkCard() },
                
                #endregion

                #region 灵
                {typeof(GiveShieldCard).Name,new GiveShieldCard() },
                #endregion

                #region 法
                

                #endregion

                

               
            };
        }
    }
}
