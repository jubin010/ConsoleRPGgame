namespace MyConsoleRPG
{
    internal class MazeLeftDoor : MapTile
    {
        public MazeLeftDoor()
        {
            TileType = TileTypes.mazeDoor;
            
        }

        public override void TileEvent()
        {
            GoWhere = new GoWhereScript(InWhere.GetType(), InWhere.Tiles[3].Loc.TileX - 1, InWhere.Tiles[3].Loc.TileY);
            base.TileEvent();
            
        }
    }
   
}