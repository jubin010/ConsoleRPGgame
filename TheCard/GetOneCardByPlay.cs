using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class GetOneCardByPlay : Perk
    {
        public GameCore Core { get; set; }
        public GetOneCardByPlay(GameCore core)
        {
            Symbol = "/+/";
            Describe = "抽牌=1";
            Core = core;
            Way = TriggerWays.PlayCard;
        }
        public override void TriggerPerk()
        {
            
            Core.DrawCard(1);


            base.TriggerPerk();
        }
    }
}
