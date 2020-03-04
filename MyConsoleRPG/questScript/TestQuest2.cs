namespace MyConsoleRPG
{
    internal class TestQuest2 : GameQuest
    {
        public TestQuest2()
        {
            Kills.Add(new QuestKill(GameMainRecycle.NpcUnits.Group[typeof(TestEnemy).Name].GetType().Name,5));
            Name = "测试任务2";
            Describe = string.Format("用于测试的任务，击杀{1}个<{0}>用于测试运行。", Kills[0].NpcName, Kills[0].KillCont);
        }
    }
}