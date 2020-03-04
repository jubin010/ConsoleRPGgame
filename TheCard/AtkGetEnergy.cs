using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class AtkGetEnergy : Perk
    {
        public AtkGetEnergy()
        {
            Symbol = "0";
            Way = TriggerWays.ATK;
            Describe = "灵气+1";
        }

        public override void TriggerPerk()
        {
            
            GameCore.Energy += 1;


            base.TriggerPerk();
        }
    }
}
