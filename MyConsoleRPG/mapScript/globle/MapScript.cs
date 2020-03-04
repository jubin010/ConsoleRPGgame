using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 游戏地图脚本基类，在地图房间加载不同地图脚本实现不同地图
    /// </summary>
    class MapScript
    {
        public enum MapTypes
        {
            city,
            maze
        }
        
        public MapTypes MapType { get; set; }//地图类型
        public char[,] MapChar { get; set; }//地图以二维字符画的形式储存展示
        public List<MapTile> Tiles { get; set; }//地图所需图块保存数组
        public MapTile[,] TileToMap { get; set; }//将图块信息与字符对应的数组
        public char[,] NowMapChar { get; set; }
        public List<MapTile.TileLoc> MapNullTileLocs { get; set; }
        

        //主角地图起始位置
        public int StarX { get; set; }
        public int StarY { get; set; }

        //地图名称
        public string MapName { get; set; }

        public  MapScript()
        {
            MapType = MapTypes.city;
            Tiles = new List<MapTile>(20);
            InherentTile();
            TileSet();
            MapNullTileLocs = new List<MapTile.TileLoc>(TileToMap.Length);
            GetXY();
            MapSet();
            NowMapChar = new char[MapChar.GetLength(0), MapChar.GetLength(1)];
            Array.Copy(MapChar, NowMapChar, MapChar.Length);
        }

        //固有地图块
        public virtual void InherentTile()
        {
            
        }

        private void GetXY()
        {
            for (int i = 0; i < TileToMap.GetLength(0); i++)
            {
                for (int ii = 0; ii < TileToMap.GetLength(1); ii++)
                {
                    if (TileToMap[i, ii] != null)
                    {
                        TileToMap[i, ii].InWhere = this;
                        TileToMap[i, ii].Loc = new MapTile.TileLoc(ii,i);
                    }
                    else
                    {
                        MapNullTileLocs.Add(new MapTile.TileLoc(ii, i));
                    }
                }
            }
        }//获取图块位置

        /// <summary>
        /// 创建添加和设定地图图块
        /// </summary>
        public virtual void TileSet()
        {

        }

        /// <summary>
        /// 创建地图字符画，并添加图块信息
        /// </summary>
        public virtual void MapSet()
        {

        }
    }
}
