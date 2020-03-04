namespace MyConsoleRPG
{
    internal class StartMapDoorTile : MapTile
    {
        public StartMapDoorTile()
        {
            TileType = TileTypes.go;
            GoWhere = new GoWhereScript( typeof(StartMapScript),5,2);
            TileText = "返回山门广场";
        }
    }
}