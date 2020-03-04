using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 每种功法只能提供一种属性值
    /// 单位检索学习功法加成属性
    /// </summary>
    class Function
    {
        private int _level;

        public Function()
        {
            Level = 1;
        }

        public string Name { get; set; }
        public TheFiveElements FunType { get; set; }
        public int Level
        {
            get => _level;
            set
            {
                if (value <= 1)
                    _level = 1;
                else
                    _level = value;
            }
        }
        public int Value { get; set; }
        public string FunCard { get; set; }
    }
}
