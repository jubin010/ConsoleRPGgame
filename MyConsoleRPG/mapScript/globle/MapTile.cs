using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    
    /// <summary>
    /// //地图图块（所有不能让主角通过的方块）基类，一旦主角碰到会展示相关信息和运行对应脚本
    /// </summary>
    class MapTile
    {
        public MapTile()
        {
            Units = new List<GameUnit>(10);
            NullTileLocs = new List<TileLoc>(300);
            Quests = new List<string>(100);
        }

        public enum TileTypes
        {
            info = 1,
            go = 2,
            battle = 3,
            mazeDoor = 4,
            quest = 5,
        }
        public struct TileLoc
        {
            public TileLoc(int tileX, int tileY)// : this()
            {
                TileX = tileX;
                TileY = tileY;
            }

            public int TileX { get; set; }
            public int TileY { get; set; }
        }


        public TileLoc Loc { get; set; }//图块坐标位置
        public TileTypes TileType { get; set; }//图块类型
        public  string GoRoom { get; set; }//图块出发后由地图房间会去往的房间（介绍房间或地图房间等）
        public GoWhereScript GoWhere { get; set; }//地图转换图块去往得地图
        public string TileText { get; set; }//图块的介绍信息
        public MapRoomScript MapRoom { get; set; }//地图房间
        public MapScript InWhere { get; set; }//图块所在的地图



        //战斗图块相关
        public List<GameUnit> Units { get; set; }

        //迷宫图块相关
        public List<TileLoc> NullTileLocs { get; set; }
        public char TileChar { get; set; }

        //任务图块相关
        public List<string> Quests { get; set; }

        /// <summary>
        /// 触发图块后运行的事件
        /// </summary>
        public virtual void TileEvent()
        {
            MapRoom =(MapRoomScript) GameMainRecycle.RoomScripts.Group[typeof(MapRoomScript).Name];
            //图块特有事件
            if (this is IEventTile e)
            {
                e.SpecialEvents();
            }
           
            switch (TileType)
            {
                case TileTypes.info:
                    GoRoom = typeof(InformationRoomScript).Name;
                    break;
                case TileTypes.go:
                    GoRoom = typeof(MapMoveRoomScript).Name;
                    MapMoveRoomScript room_go = (MapMoveRoomScript)GameMainRecycle.RoomScripts.Group[GoRoom];
                    room_go.GoWhere = GoWhere.GoWhere;
                    MapRoom.MapScripts[GoWhere.GoWhere.Name].StarX = GoWhere.NextStarX;
                    MapRoom.MapScripts[GoWhere.GoWhere.Name].StarY = GoWhere.NextStarY;
                    break;
                case TileTypes.battle:
                    ShuffleUnits();
                    GoRoom = typeof(MapToBattleRoom).Name;
                    MapToBattleRoom room_battle = (MapToBattleRoom)GameMainRecycle.RoomScripts.Group[GoRoom];
                    room_battle.Enemy = Units[0];
                    TileText = Units[0].Name;
                    break;
                case TileTypes.mazeDoor:
                    //构建迷宫
                    GoRoom = typeof(MapRoomScript).Name;
                    MapRoom.Script = InWhere;
                    InWhere.StarX = GoWhere.NextStarX;
                    InWhere.StarY = GoWhere.NextStarY;
                    MapRoom.ReLoad();
                    GetAndShuffleNullTile(InWhere);
                    AddRandomTile(20,InWhere);
                    break;
                case TileTypes.quest:
                    GoRoom = typeof(QuestShopRoomScript).Name;
                    QuestShopRoomScript questRoom =(QuestShopRoomScript)  GameMainRecycle.RoomScripts.Group[GoRoom];
                    questRoom.Quests = Quests;
                    break;
                default:
                    break;
            }

            


            //图块出发后由地图房间会去往的房间
            MapRoom.OutRoom 
                = GameMainRecycle.RoomScripts.Group[GoRoom];

            //更改介绍信息为图块介绍信息
            GameMainRecycle.InfoText = TileText;
                
        }

       

        public  void AddRandomTile(int cont,MapScript where)
        {
            Random random = new Random();
            for (int ii = 0; ii < cont; ii++)
            {
                int index = random.Next(5, InWhere.Tiles.Count);
               where.TileToMap[NullTileLocs[ii].TileY, NullTileLocs[ii].TileX] = where.Tiles[index];
               where.NowMapChar[NullTileLocs[ii].TileY, NullTileLocs[ii].TileX] = where.Tiles[index].TileChar;
            }
        }

        public  void GetAndShuffleNullTile(MapScript where)
        {
            NullTileLocs.Clear();
            NullTileLocs.AddRange(where.MapNullTileLocs.ToArray());
            ShuffleHelper.ShuffleList(NullTileLocs);
        }

        private void ShuffleUnits()
        {
            ShuffleHelper.ShuffleList(Units);
        }

    }
}
