using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class SwordSouthValleyMapScript : MapScript
    {
        public override void MapSet()
        {
            MapName = "天剑宗南谷镇";
            MapChar = new char[,]
             {
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','务'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '南','、','、','、','、','、','、','兽','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '门','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','迷','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},
                { '、','、','、','、','、','、','、','、','、','、' ,'、','、','、','、','、','、','、','、','、'},

             };
            StarX = 1;
            StarY = 2;
        }

        public override void TileSet()
        {
            Tiles.Add(new SouthernForestTile());//0

            Tiles.Add(new SouthernSteleTile());//1

            Tiles.Add(new StartMapDoorTile());//2

            Tiles.Add(new TestBattleTile());//3

            Tiles.Add(new MazeTile());//4

            Tiles.Add(new QuestBaseTile());//5




            TileToMap = new MapTile[,]
             {
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,Tiles[5]},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { Tiles[2],null,null,null,null,null,null,Tiles[3],null,null ,null,null,null,null,null,null,null,null,null},
                {Tiles[2],null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,Tiles[4],null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},
                { null,null,null,null,null,null,null,null,null,null ,null,null,null,null,null,null,null,null,null},

             };

        }

    }
}
