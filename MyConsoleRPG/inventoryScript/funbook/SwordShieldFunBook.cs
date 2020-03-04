using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SwordShieldFunBook : FunBook
    {
        public SwordShieldFunBook()
        {
            Fun = new SwordShield();
            Name = Fun.Name;
        }
    }
}
