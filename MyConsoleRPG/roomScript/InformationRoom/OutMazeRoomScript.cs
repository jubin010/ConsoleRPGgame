namespace MyConsoleRPG
{
    /// <summary>
    /// 退出迷宫房间
    /// </summary>
    internal class OutMazeRoomScript:InformationRoomScript
    {
        public override void SetSelect()
        {
            
        }

        public override void Runing()
        {
            MapRoomScript mapRoom = (MapRoomScript)LastRoom.LastRoom;
            mapRoom.Script = mapRoom.MapScripts[ GameMainRecycle.PlayerInfo.Psave.MapScript];
            mapRoom.X = GameMainRecycle.PlayerInfo.Psave.Px;
            mapRoom.Y = GameMainRecycle.PlayerInfo.Psave.Py;
            OutRoom = mapRoom;
        }
    }
}