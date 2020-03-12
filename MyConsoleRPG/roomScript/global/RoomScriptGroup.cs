using System.Collections.Generic;

namespace MyConsoleRPG
{
    /// <summary>
    /// 房间脚本序列化类，主循环将实例化一次，用于加载脚本进入游戏，新写的脚本要在此进行添加注册
    /// </summary>
    class RoomScriptGroup
    {
        public Dictionary<string, RoomScript> Group { get; set; }
        public RoomScriptGroup()
        {
            Group = new Dictionary<string, RoomScript>
            {
                { typeof(StartRoomScript).Name, new StartRoomScript() },
                {typeof(NewGameRoomScript).Name,new NewGameRoomScript() },
                {typeof(OldGameRoomScript).Name,new OldGameRoomScript() },
                { typeof(EndRoomScript).Name, new EndRoomScript() },
                { typeof(NoSaveEndRoomScript).Name, new NoSaveEndRoomScript() },
                { typeof(StoryRoomScript).Name, new StoryRoomScript() },
                { typeof(InformationRoomScript).Name, new InformationRoomScript() },
                {typeof(MapRoomScript).Name,new MapRoomScript() },
                {typeof(MapMoveRoomScript).Name,new MapMoveRoomScript() },
                {typeof(UnitInfoRoom).Name,new UnitInfoRoom() },
                {typeof(PlayerInventoryRoom).Name,new PlayerInventoryRoom() },
                {typeof(InverntoryInfoRoom).Name,new InverntoryInfoRoom() },
                {typeof(InventorySwitchRoom).Name,new InventorySwitchRoom() },
                {typeof(BattleRoomScript).Name,new BattleRoomScript() },
                {typeof(GameSelectRoom).Name,new GameSelectRoom() },
                {typeof(MapToBattleRoom).Name,new MapToBattleRoom() },
                 {typeof(OutMazeRoomScript).Name,new OutMazeRoomScript() },
                 {typeof(QuestInfoRoomScript).Name,new QuestInfoRoomScript() },
                {typeof(QuestShopRoomScript).Name,new QuestShopRoomScript() },
                {typeof(ControllerSetRoomScript).Name,new ControllerSetRoomScript() }
            };
        }
    }
}
