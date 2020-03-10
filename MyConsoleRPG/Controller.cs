using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 玩家控制设置类 
    /// </summary>
    static class   Controller
    {
        public enum KeyName
        {
            UpKey,
            DownKey,
            LeftKey,
            RightKey,
            EnterKey, 
            BackKey,
            MenuKey,
            NullKey,
        }
        public static Dictionary<KeyName, ConsoleKey> ControllerKeys { get; set; } = new Dictionary<KeyName, ConsoleKey>(7);

        public static void LoadKeySet()
        {
            string filePath = string.Format("{0}\\{1}.json", Directory.GetCurrentDirectory(), "KeySetting");
            if (!File.Exists(filePath))
            {
                ControllerKeys.Add(KeyName.UpKey, ConsoleKey.UpArrow);
                ControllerKeys.Add(KeyName.DownKey, ConsoleKey.DownArrow);
                ControllerKeys.Add(KeyName.LeftKey, ConsoleKey.LeftArrow);
                ControllerKeys.Add(KeyName.RightKey, ConsoleKey.RightArrow);
                ControllerKeys.Add(KeyName.EnterKey, ConsoleKey.Z);
                ControllerKeys.Add(KeyName.BackKey, ConsoleKey.X);
                ControllerKeys.Add(KeyName.MenuKey, ConsoleKey.Spacebar);
            }
            else
            {
                string json = JsonHelper.GetMyJson(Directory.GetCurrentDirectory(), "KeySetting");
                ControllerKeys = JsonConvert.DeserializeObject<Dictionary<KeyName, ConsoleKey>>(json);
            }
            
        }

        public static KeyName ReadKeyDown()
        {
            while (true)
            {
                ConsoleKey keyDown = Console.ReadKey(true).Key;
                foreach (var item in ControllerKeys)
                {
                    if (item.Value == keyDown)
                    {
                        return item.Key;
                    }
                }
            }
        }
      

    }
}
