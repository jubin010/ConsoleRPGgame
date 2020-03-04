namespace MyConsoleRPG
{
    internal class TestQuest3 : GameQuest
    {
        public TestQuest3()
        {
            Kills.Add(new QuestKill(GameMainRecycle.NpcUnits.Group[typeof(TestEnemy).Name].GetType().Name,1));
            Name = "测试任务";
            Describe = string.Format("用于测试的任务，击杀{1}个<{0}>用于测试运行打发打发垃圾堆了估计案例爱丽丝的感觉阿桑的歌就爱上了大概案件数量的噶啥的两个空间爱上了大哥爱上了大哥。", Kills[0].NpcName, Kills[0].KillCont);
        }
    }
}