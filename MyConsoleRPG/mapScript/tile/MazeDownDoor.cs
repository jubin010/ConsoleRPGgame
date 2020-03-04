namespace MyConsoleRPG
{
    internal class MazeDownDoor : MapTile
    {
        public MazeDownDoor()
        {
            TileType = TileTypes.mazeDoor;
            
        }

        public override void TileEvent()
        {
            GoWhere = new GoWhereScript(InWhere.GetType(), InWhere.Tiles[0].Loc.TileX, InWhere.Tiles[0].Loc.TileY + 1);
            base.TileEvent();
            
        }
    }
}