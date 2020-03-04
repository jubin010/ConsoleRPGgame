namespace MyConsoleRPG
{
    internal class MazeRightDoor : MapTile
    {
        public MazeRightDoor()
        {
            TileType = TileTypes.mazeDoor;
            
        }

        public override void TileEvent()
        {
            GoWhere = new GoWhereScript(InWhere.GetType(), InWhere.Tiles[2].Loc.TileX + 1, InWhere.Tiles[2].Loc.TileY);
            base.TileEvent();
            
        }
    }
}