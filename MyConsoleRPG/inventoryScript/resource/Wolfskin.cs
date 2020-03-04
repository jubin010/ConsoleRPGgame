using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class Wolfskin : Resource
    {
        public Wolfskin():this(1)
        {
        }

        public Wolfskin(int a)
        {
            NoContName = "狼皮";

            Amount = a;
        }

    }
}
