namespace MyConsoleRPG
{
    class TestMapScript : MapScript
    {
        public override void MapSet()
        {
            MapName = "测试地图";
            MapChar = new char[,]
            {
{'林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林'},
{'林','、','、','、','、','、','、','、','南','天','门','、','、','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','、','林','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','山','、','、','、','林','、','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','门','、','、','、','、','、','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','碑','、','、','、','、','、','、','、','、','林','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','林','、','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','、','、','、','、','、','、','、','、','林','、','、','林'},
{'林','、','、','、','、','、','、','、','、','、','、','林','、','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','林'},
{'林','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','、','林'},
{'林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林','林'},
            };
            StarX = 2;
            StarY = 5;
        }
        public override void TileSet()
        {
            Tiles.Add(new SouthernForestTile());//.林
            Tiles.Add(new SouthernDoorTile());//.南
            //Tiles.Add(1).天
            //Tiles.Add(1).门
            Tiles.Add(new SouthernSteleTile());//.山
            //Tiles.Add(2).门
            //Tiles.Add(2).碑
            TileToMap = new MapTile[,]
            {
{Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,Tiles[1],Tiles[1],Tiles[1],null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,Tiles[0],null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,Tiles[2],null,null,null,Tiles[0],null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,Tiles[2],null,null,null,null,null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,Tiles[2],null,null,null,null,null,null,null,null,Tiles[0],null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,Tiles[0],null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,null,null,null,null,null,null,null,Tiles[0],null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,null,null,null,Tiles[0],null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,Tiles[0]},
{Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0],Tiles[0]},
            };
        }


    }
}

