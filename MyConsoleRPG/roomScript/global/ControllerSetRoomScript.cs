using System;
using System.Collections.Generic;
using System.IO;

namespace MyConsoleRPG
{
    internal class ControllerSetRoomScript : RoomScript
    {
        public ControllerSetRoomScript()
        {
            KeyString = new List<string>(7);
            KeyNames = new List<Controller.KeyName>(7);
        }

        public int SelectIndex { get; set; }
        public List<string> KeyString { get; set; }
        public List<Controller.KeyName> KeyNames { get; set; }
        public override void SetSelect()
        {
            
        }
        public override void Runing()
        {
            GiveLast = false;
            OutRoom = LastRoom;
            KeyString.Clear();
            KeyNames.Clear();
            foreach (var item in Controller.ControllerKeys)
            {
                KeyString.Add(string.Format("<{0}>:   <{1}>",item.Key,item.Value));
                KeyNames.Add(item.Key);
            } 
            SelectIndex = 0;
            DeBugRun();
            SelectIndex = PrintHelper.PrintSelectText(KeyString, SelectIndex);
            if(SelectIndex > KeyString.Count-1)
            {
                string KeySave = Newtonsoft.Json.JsonConvert.SerializeObject(Controller.ControllerKeys);
                JsonHelper.SaveMyJson(Directory.GetCurrentDirectory(), KeySave, "KeySetting");
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("请按下你想要使用的按键");
                Controller.ControllerKeys[KeyNames[SelectIndex]] = Console.ReadKey().Key;
                OutRoom = this;
            }
            
        }
    }
}