using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SouthValleyMazeScript :MazeMapScript
    {
  
        public override void MapSet()
        {
            MapName = "南林秘境";
            MapChar = new char[,]
             {
                { '、','、','、','、','门','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','门' },
                { '门','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','、','、','、','、','、' },
                { '、','、','、','、','、','门','、','、','、','、' },

             };
            StarX = 2;
            StarY = 6;

            
        }
        public override void TileSet()
        {
            Tiles.Add(new TestBattleTile());
            Tiles.Add(new SouthernForestTile());
            Tiles.Add(new SouthernForestTile());
            Tiles.Add(new SouthernForestTile());
            Tiles.Add(new SouthernForestTile());
            Tiles.Add(new SouthernForestTile());
            Tiles.Add(new SouthernSteleTile());
            Tiles.Add(new SouthernSteleTile());
            Tiles.Add(new SouthernSteleTile());
            Tiles.Add(new SouthernSteleTile());
            Tiles.Add(new SouthernSteleTile());


            TileToMap = new MapTile[,]
            {
                { null,null,null,null,Tiles[0],null,null,null,null,null },
                { null,null,null,null,Tiles[4],null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,Tiles[4],Tiles[3] },
                { Tiles[2],Tiles[4],null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,null,null,null,null,null },
                { null,null,null,null,null,Tiles[4],null,null,null,null },
                { null,null,null,null,null,Tiles[1],null,null,null,null },
            };

        }

    }
}
