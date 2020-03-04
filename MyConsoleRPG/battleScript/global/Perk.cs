namespace MyConsoleRPG
{
    class Perk
    {
        public string Describe { get; set; }
        public string Symbol { get; set; }
        public CardSkill TriggerSkill { get; set; }
        public enum TriggerWays
        {
            ATK = 0,
            Shield = 1,
            PlayCard = 2,
        }

        public TriggerWays Way { get; set; }

        public virtual void TriggerPerk()
        {
             BattleRoomScript battleRoom = (BattleRoomScript)GameMainRecycle.RoomScripts.Group[typeof(BattleRoomScript).Name];
             battleRoom.RoundResult.AppendLine(Describe);
        }
    }
}