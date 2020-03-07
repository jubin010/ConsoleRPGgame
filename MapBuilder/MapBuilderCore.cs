using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapBuilder
{
    class MapBuilderCore
    {
        public MapBuilderCore()
        {
            Tiles = new List<TileBrush>(20);
            EmptyGroud = new TileBrush('、', 999);
            EndDesign = false;
            Brush = new TileBrush('S', 1000);
        }

        public struct TileBrush
        {
            public TileBrush(char tileChar, int tileIndex) : this()
            {
                TileChar = tileChar;
                TileIndex = tileIndex;
            }

            public char TileChar { get; set; }
            public int TileIndex { get; set; }
        }




        //地图文件名
        public  string FileName { get; set; }
        //地图名
        public string MapName { get; set; }

        //光标位置位置
        public  int X { get; set; }
        public  int Y { get; set; }
        //字符地图
        public  char[,] MapChar { get; set; }
        public string[,] MapTileString { get; set; }

        //地图大小
        public  int XLength { get; set; }
        public  int YLength { get; set; }

        //图块笔刷组
        public List<TileBrush> Tiles { get; set; }
        //当前选择的笔刷
        public TileBrush Brush { get; set; }
        //空地笔刷
        public TileBrush EmptyGroud { get; set; }
        //笔刷号
        public int BrushIndex { get; set; }

        //结束设计
        public bool EndDesign { get; set; }

        public bool InTileWindow { get; set; }
        public bool Delete { get; private set; }

        public void Runing()
        {
            
            MapSetting();

            while (!EndDesign)
            {
                MapDesign();
                if (!EndDesign)
                {
                    InTileWindow = true;
                    TileWindow();
                }
            } 
            CreatTheCS();
        }

        private void MapSetting()
        {
            Console.WriteLine("请输入地图文件名(英文首字母大写)");
            FileName = Console.ReadLine();
            Console.WriteLine("请输入地图名字");
            MapName = Console.ReadLine();
            Console.WriteLine("请输入地图横幅");
            XLength = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入地图纵幅");
            YLength = int.Parse(Console.ReadLine());
            MapChar = new char[YLength, XLength];
            MapTileString = new string[YLength, XLength];
            for (int i = 0; i < MapChar.GetLength(0); i++)
            {
                for (int ii = 0; ii < MapChar.GetLength(1); ii++)
                {
                    MapChar[i, ii] = EmptyGroud.TileChar;
                    MapTileString[i, ii] = "null";
                }
            }
        }

        //图块添加设置窗口
        private void TileWindow()
        {
            while (InTileWindow)
            {
                Console.Clear();
                SelectTile();
                if(InTileWindow && !Delete)
                AddTile();
            }
        }

        private void AddTile()
        {
            
            Console.WriteLine("请输入图块字符(全角)");
            string s = Console.ReadLine();
            char[] cs = s.ToCharArray();
            Console.WriteLine("请输入对应图块序号");
            int index = int.Parse( Console.ReadLine() );
            foreach (var item in cs)
            {
                Tiles.Add(new TileBrush(item, index));
            }
           
            
        }

        private void SelectTile()
        {
            if (Tiles.Count < 1)
            {
                Delete = false;
                Console.WriteLine("无可用地图块，请添加");
                return;
            }
            Console.WriteLine("<上><下>选择图块,<左>返回地图,<A>添加图块,<右>删除图块");
            BrushIndex = PrintSelectText(Tiles, BrushIndex);
        }

        //地图设计
        private void MapDesign()
        {
            Console.Clear();
            

            Console.WriteLine("坐标< X:{0}  Y:{1} >", X, Y);
            Console.WriteLine(FileName);
            Console.WriteLine("{0}<{1}*{2}>", MapName, XLength, YLength);
            Console.WriteLine("<上><下><左><右>移动光标,<E>图块笔刷,<S>光标,<空格>空白笔刷");
            int start = Console.CursorTop;
            DrawMap(start);
            //Console.WriteLine();
            KeyToControl(start);
        }

        //绘制地图
        private void DrawMap(int start)
        {
            ConsoleColor BaseColor = Console.ForegroundColor;
            for (int i = 0; i < MapChar.GetLength(0); i++)
            {
                for (int ii = 0; ii < MapChar.GetLength(1); ii++)
                {
                    char k;
                    if (X == ii & Y == i)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        if (Brush.TileIndex == 1000)
                            k = '始';
                        else
                            k = Brush.TileChar;
                    }
                    else
                    {
                        Console.ForegroundColor = BaseColor;
                        k = MapChar[i, ii];
                    }

                    if (ii < MapChar.GetLength(1) - 1)
                    {
                        Console.Write(k);
                    }
                    else
                    {
                        Console.WriteLine(k);
                    }
                }
            }
            Console.CursorLeft = 2 * X;
            Console.CursorTop = start + Y;
        }

        /// <summary>
        /// 创建CS文件
        /// </summary>
        private void CreatTheCS()
        {
            StringBuilder stringBuilder = new StringBuilder(500);
            stringBuilder.AppendLine("namespace MyConsoleRPG");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendFormat("class {0}:MapScript", FileName);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("{");
            stringBuilder.AppendLine("public override void MapSet()");
            stringBuilder.AppendLine("{");
            stringBuilder.AppendFormat("MapName = \"{0}\";", MapName);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine("MapChar = new char[,]");
            stringBuilder.AppendLine("{");
            for (int i = 0; i < MapChar.GetLength(0); i++)
            {
                for (int ii = 0; ii < MapChar.GetLength(1); ii++)
                {
                    if (ii == 0)
                    {

                        stringBuilder.AppendFormat("{1}\'{0}\',", MapChar[i, ii].ToString(), "{");
                    }
                    else if (ii == MapChar.GetLength(1) - 1)
                    {
                        stringBuilder.AppendFormat("\'{0}\'{1},", MapChar[i, ii].ToString(), "}");
                        stringBuilder.AppendLine();
                    }
                    else
                    {
                        stringBuilder.AppendFormat("\'{0}\',", MapChar[i, ii].ToString());
                    }
                }
            }
            stringBuilder.AppendLine("};");
            stringBuilder.AppendLine("StarX = 2;");
            stringBuilder.AppendLine("StarY = 5;");
            stringBuilder.AppendLine("}");

            stringBuilder.AppendLine("public override void TileSet()");
            stringBuilder.AppendLine("{");

            foreach (var item in Tiles)
            {
                stringBuilder.AppendFormat("//Tiles.Add({0}).{1}", item.TileIndex, item.TileChar.ToString());
                stringBuilder.AppendLine();
            }
            
            stringBuilder.AppendLine("TileToMap = new MapTile[,]"); 
            stringBuilder.AppendLine("{");
            for (int i = 0; i < MapTileString.GetLength(0); i++)
            {
                for (int ii = 0; ii < MapTileString.GetLength(1); ii++)
                {
                    if (ii == 0)
                    {

                        stringBuilder.AppendFormat("{1}{0},", MapTileString[i, ii], "{");
                    }
                    else if (ii == MapTileString.GetLength(1) - 1)
                    {
                        stringBuilder.AppendFormat("{0}{1},", MapTileString[i, ii], "}");
                        stringBuilder.AppendLine();
                    }
                    else
                    {
                        stringBuilder.AppendFormat("{0},", MapTileString[i, ii]);
                    }
                }
            }
            stringBuilder.AppendLine("};");





            stringBuilder.AppendLine("}");



            stringBuilder.AppendLine("");
            stringBuilder.AppendLine("");

            stringBuilder.AppendLine("}");
            stringBuilder.AppendLine("}");
            

            string path = string.Format("{0}\\{1}.cs", System.IO.Directory.GetCurrentDirectory(), FileName);
            WriteFile(path, stringBuilder.ToString());
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        public static void WriteFile(string Path, string Strings)
        {

            if (!System.IO.File.Exists(Path))
            {
                //Directory.CreateDirectory(Path);

                System.IO.FileStream f = System.IO.File.Create(Path);
                f.Close();
                f.Dispose();
            }
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();


        }

        public static void PrintWriteColor(char s, ConsoleColor c)
        {
            ConsoleColor BaseColor = Console.ForegroundColor;
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ForegroundColor = BaseColor;

        }

        //光标移动后重新绘制移动前后地图块
        private  void UpdateTile(int start, int mx, int my)
        {
            Console.CursorLeft = 2 * X;
            Console.CursorTop = start + Y;
            if (Brush.TileIndex >=1000)
            {
                
            }
            else
            {
                MapChar[Y, X] = Brush.TileChar;
                if (Brush.TileIndex == 999)
                    MapTileString[Y, X] = "null";
                else
                    MapTileString[Y, X] = string.Format("Tiles[{0}]", Brush.TileIndex);
            }
            Console.Write(MapChar[Y, X]);
            Y += my;
            X += mx;
            Console.CursorLeft = 2 * X;
            Console.CursorTop = start + Y;
            if (Brush.TileIndex == 999)
            {
                PrintWriteColor('N', ConsoleColor.Red);
            }
            else
            {
                PrintWriteColor(Brush.TileChar, ConsoleColor.Red);
            }
        }

        /// <summary>
        /// 地图按键相关操作方法
        /// </summary>
        /// <param name="start">地图初始绘制行号</param>
        private void KeyToControl(int start)
        {
            while (true)
            {
                ConsoleKey kk = Console.ReadKey(true).Key;

                if (kk == ConsoleKey.UpArrow)
                {
                    if (Y - 1 >= 0)
                    {
                        UpdateTile(start, 0, -1);
                    }
                }
                else if ( kk == ConsoleKey.LeftArrow)
                {
                    if (X - 1 >= 0)
                    {
                        UpdateTile(start, -1, 0);
                    }
                }
                else if ( kk == ConsoleKey.DownArrow)
                {
                    if (Y + 1 <= MapChar.GetLength(0) - 1)
                    {
                        UpdateTile(start, 0, 1);
                    }
                }
                else if ( kk == ConsoleKey.RightArrow)
                {
                    if (X + 1 <= MapChar.GetLength(1) - 1)
                    {
                        UpdateTile(start, 1, 0);
                    }

                }



                if (kk == ConsoleKey.E)
                {
                    break;
                }
                if(kk == ConsoleKey.End)
                {
                    EndDesign = true;
                    break;
                }
                if(kk == ConsoleKey.S)
                {
                    Brush = new TileBrush('S',1000);
                    UpdateTile(start, 0, 0);
                }
                if(kk == ConsoleKey.Spacebar)
                {
                    Brush = EmptyGroud;
                    UpdateTile(start, 0, 0);
                }
                Console.CursorTop = 0;
                Console.CursorLeft = 0;
                Console.Write("                               ");
                Console.CursorLeft = 0;
                Console.Write("坐标< X:{0}  Y:{1} >",X,Y);
                Console.CursorLeft = 2 * X;
                Console.CursorTop = start + Y;

            }
        }

        //图块选择
        public  int PrintSelectText(List<TileBrush> array, int s)
        {
            if (s == 999)
            {
                s = 0;
            }
            int SelectIndex = s;
            if (SelectIndex >= array.Count - 1)
            {
                SelectIndex = array.Count - 1;
            }
            else if (SelectIndex <= 0)
            {
                SelectIndex = 0;
            }
            
            int line = Console.CursorTop;
            bool goOut = false;
            foreach (var item in array)
            {
                Console.WriteLine("  {0}<{1}>", item.TileChar,item.TileIndex);
            }
            while (array.Count > 0 && goOut == false)
            {
                Console.SetCursorPosition(0, SelectIndex + line);
                Console.Write("=>");
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.SetCursorPosition(0, SelectIndex + line);
                Console.Write("  ");
                Delete = false;
                switch (key)
                {
                   
                    case ConsoleKey.DownArrow:
                        SelectIndex += 1;
                        break;
                    
                    case ConsoleKey.UpArrow:
                        SelectIndex -= 1;
                        break;
                    
                    case ConsoleKey.RightArrow:
                        Delete = true;
                        goOut = true;
                        break;
                    
                    case ConsoleKey.LeftArrow:
                        InTileWindow = false;
                        goOut = true;
                        break;

                    case ConsoleKey.A:
                        goOut = true;
                        Console.Clear();
                        break;
                }
                if (SelectIndex >= array.Count - 1)
                {
                    SelectIndex = array.Count - 1;
                }
                else if (SelectIndex <= 0)
                {
                    SelectIndex = 0;
                }

                if (Delete)
                {
                    array.RemoveAt(SelectIndex);
                }
                if (!InTileWindow)
                {
                    Brush = Tiles[SelectIndex];
                }
            }
            
            return SelectIndex;
        }
    }
}
