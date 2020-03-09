using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 地图房间脚本类，用于展示运行所有地图脚本
    /// </summary>
    class MapRoomScript : RoomScript
    {
        //地图脚本序列
        public Dictionary<string,MapScript> MapScripts { get; set; }
        
        //主角位置
        public int X { get; set; }
        public int Y { get; set; }

        //查看坐标
        public int SeeX { get; set; }
        public int SeeY { get; set; }
        
        //当前运行的地图脚本
        public MapScript Script { get; set; }
        
        
        

        public MapRoomScript()
        {
            MapScripts = new Dictionary<string, MapScript>();
            LoadMapScript();
            
           
            


        }

        private void LoadMapScript()
        {
            MapScripts.Add(typeof(StartMapScript).Name, new StartMapScript());
            MapScripts.Add(typeof(SwordSouthValleyMapScript).Name, new SwordSouthValleyMapScript());
            MapScripts.Add(typeof(SouthValleyMazeScript).Name, new SouthValleyMazeScript());
            MapScripts.Add(typeof(TestMapScript).Name, new TestMapScript());
        }

        public override void Runing()
        {

            DeBugRun();
            if(Script.MapType == MapScript.MapTypes.city)
            {
                GameMainRecycle.PlayerInfo.PlayerUnit.UnitHp = GameMainRecycle.PlayerInfo.PlayerUnit.UnitMaxHp;
                
            }

            Console.WriteLine("你来到 <{0}>", Script.MapName);
            Console.WriteLine("生命:{0}/{1}",GameMainRecycle.PlayerInfo.PlayerUnit.UnitHp, GameMainRecycle.PlayerInfo.PlayerUnit.UnitMaxHp);
            Console.WriteLine();
            Console.WriteLine("按 <{0}><{1}><{2}><{3}>键来移动主角<你>",Controller.ControllerKeys[Controller.KeyName.UpKey], Controller.ControllerKeys[Controller.KeyName.DownKey], Controller.ControllerKeys[Controller.KeyName.LeftKey], Controller.ControllerKeys[Controller.KeyName.RightKey]);
            Console.WriteLine("向对应物体移动以查看物体相应信息,按 <{0}>进入游戏菜单", Controller.ControllerKeys[Controller.KeyName.MenuKey]);
            Console.WriteLine();

            int start = Console.CursorTop;
            DrawMap();
            KeyToControl(start);
        }

        /// <summary>
        /// 地图按键相关操作方法
        /// </summary>
        /// <param name="start">地图初始绘制行号</param>
        private void KeyToControl(int start)
        {
            bool goOut = false;
            while (!goOut)
            {
                //方向移动主角方法，不能移动的地块尝试出发其事件
                Controller.KeyName kkk = Controller.ReadKeyDown();
                switch (kkk)
                {
                    case Controller.KeyName.UpKey:
                        if (Y - 1 >= 0)
                        {
                            if (Script.NowMapChar[Y - 1, X] == '、')
                            {
                                UpdateTile(start, 0, -1);
                            }
                            else
                            {
                                SeeX = X;
                                SeeY = Y - 1;
                                Script.TileToMap[SeeY, SeeX].TileEvent();
                                goOut = true;
                            }
                        }
                        break;
                    case Controller.KeyName.DownKey:
                        if (Y + 1 <= Script.NowMapChar.GetLength(0) - 1)
                        {
                            if (Script.NowMapChar[Y + 1, X] == '、')
                            {
                                UpdateTile(start, 0, 1);
                            }
                            else
                            {
                                SeeX = X;
                                SeeY = Y + 1;
                                Script.TileToMap[SeeY, SeeX].TileEvent();
                                goOut = true;
                            }
                        }
                        break;
                    case Controller.KeyName.LeftKey:
                        if (X - 1 >= 0)
                        {
                            if (Script.NowMapChar[Y, X - 1] == '、')
                            {
                                UpdateTile(start, -1, 0);
                            }
                            else
                            {
                                SeeX = X - 1;
                                SeeY = Y;
                                Script.TileToMap[SeeY, SeeX].TileEvent();
                                goOut = true;
                            }
                        }
                        break;
                    case Controller.KeyName.RightKey:
                        if (X + 1 <= Script.NowMapChar.GetLength(1) - 1)
                        {
                            if (Script.NowMapChar[Y, X + 1] == '、')
                            {
                                UpdateTile(start, 1, 0);
                            }
                            else
                            {
                                SeeX = X + 1;
                                SeeY = Y;
                                Script.TileToMap[SeeY, SeeX].TileEvent();
                                goOut = true;
                            }
                        }
                        break;
                    case Controller.KeyName.EnterKey:
                        break;
                    case Controller.KeyName.BackKey:
                        break;
                    case Controller.KeyName.MenuKey:
                        OutRoom = GameMainRecycle.RoomScripts.Group[typeof(GameSelectRoom).Name];
                        goOut = true;
                        break;
                }
                Console.CursorTop = 0;
                Console.CursorLeft = 0;

            }
        }

        /// <summary>
        /// 一次性绘制全地图，并绘制主角位置
        /// </summary>
        private void DrawMap()
        {
            ConsoleColor BaseColor = Console.ForegroundColor;
            for (int i = 0; i < Script.NowMapChar.GetLength(0); i++)
            {
                for (int ii = 0; ii < Script.NowMapChar.GetLength(1); ii++)
                {
                    char k;
                    if (X == ii & Y == i)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.Red;
                        k = '你';
                    }
                    else
                    {
                        Console.ForegroundColor = BaseColor;
                        k = Script.NowMapChar[i, ii];
                    }

                    if (ii < Script.NowMapChar.GetLength(1) - 1)
                    {
                        Console.Write(k);
                    }
                    else
                    {
                        Console.WriteLine(k);
                    }
                }
            }
        }

        //主角移动后重新绘制移动前后地图块
        private void UpdateTile(int start,int mx,int my)
        {
            Console.CursorLeft = 2 * X;
            Console.CursorTop = start + Y;
            Console.Write(Script.NowMapChar[Y, X]);
            Y += my;
            X += mx;
            Console.CursorLeft = 2 * X;
            Console.CursorTop = start + Y;
            PrintHelper.PrintWriteColor('你', ConsoleColor.Red);
        }

        //加载不同得新的地图时，对地图进行初始化
        public void ReLoad()
        {
            //初始化玩家位置
            X =Script.StarX;
            Y =Script.StarY;

            //初始化地图绘制
            Array.Copy(Script.MapChar, Script.NowMapChar, Script.MapChar.Length);

            foreach (var item in Script.MapNullTileLocs)
            {
                Script.TileToMap[item.TileY, item.TileX] = null;
            }
        }

        public override void OutRuning()
        {
            base.OutRuning();
            if (Script.MapType == MapScript.MapTypes.city)
            {
                GameMainRecycle.PlayerInfo.Psave.MapScript = Script.GetType().Name;
                //MapScript map = MapScripts[GameMainRecycle.PlayerInfo.PLoc.Script];
                GameMainRecycle.PlayerInfo.Psave.Px = X;
                GameMainRecycle.PlayerInfo.Psave.Py = Y;
            }

        }
        public override void SetSelect()
        {
           
        }
    }
}
