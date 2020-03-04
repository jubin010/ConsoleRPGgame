using System;

namespace MyConsoleRPG
{
    class CardSkill: ICloneable
    {
     

        public string Describe { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Atk { get; set; }
        public int Shield { get; set; }
        public int Hurt { get; set; }
        public int Ling { get; set; }
        public BattleRoomScript GameCore { get; set; }
        public Card OwnerCard { get; set; }



        public  void RunSkill()
        {
            GameCore = (BattleRoomScript)GameMainRecycle.RoomScripts.Group[typeof(BattleRoomScript).Name];
            RunScript();
            if(Describe != "")
                GameCore.RoundResult.AppendLine(Describe);
            Describe = "";
        }

        public virtual void RunScript()
        {

        }

        public JsonSkill ToJsonSkill()
        {
            JsonSkill json = new JsonSkill
            {
                SkillName = GetType().Name,
                Name = Name,
                Describe = Describe,
                Symbol = Symbol,
                Atk = Atk,
                Shield = Shield,
                Hurt = Hurt,
                Ling = Ling
            };
            return json;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}