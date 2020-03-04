using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 单位功法组类，记录单位学习和当前运行的功法
    /// </summary>
    class UnitFunctions
    {
        /// <summary>
        /// 当前每类运行的一个功法，触发功法主动
        /// </summary>
        public Function GoldFunction { get; set; }
        public Function WoodFunction { get; set; }
        public Function WaterFunction { get; set; }
        public Function FireFunction { get; set; }
        public Function SoilFunction { get; set; }

        /// <summary>
        /// 当前学习过的功法组，触发功法被动
        /// </summary>
        public List<Function> LearnedGoldFuns { get; set; }
        public List<Function> LearnedWoodFuns { get; set; }
        public List<Function> LearnedWaterFuns { get; set; }
        public List<Function> LearnedFireFuns { get; set; }
        public List<Function> LearnedSoilFuns { get; set; }


        public UnitFunctions()
        {
            LearnedGoldFuns = new List<Function>(50);
            LearnedWoodFuns = new List<Function>(50);
            LearnedWaterFuns = new List<Function>(50);
            LearnedFireFuns = new List<Function>(50);
            LearnedSoilFuns = new List<Function>(50);
            //GoldFunction = LearnedGoldFuns[0];
            //WoodFunction = LearnedWoodFuns[0];
            //WaterFunction = LearnedWaterFuns[0];
            //FireFunction = LearnedFireFuns[0];
            //SoilFunction = LearnedSoilFuns[0];

        }

    }
}
