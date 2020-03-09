using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class BattleRoomScript : RoomScript
    {
        public bool IsPlayerRound { get; private set; }
        public int SelectIndex { get; private set; }
        public bool Result { get; private set; }
        public GameUnit Player { get; set; }
        public GameUnit Enemy { get; set; }
        private int s_pHp;
        private int s_eHp;
        private int s_energy;
        private int _eEnergy;

        public BattleRoomScript()
        {
            GiveLast = false;
            Player = GameMainRecycle.PlayerInfo.PlayerUnit;
            Enemy = GameMainRecycle.NpcUnits.Group[typeof(TestEnemy).Name];
            RoundResult = new StringBuilder(200);
            
            NowCardGroup = new List<Card>(50);
            ENowCardGroup = new List<Card>(50);
            HandCardGroup = new List<Card>(15);
            EHandCardGroup = new List<Card>(15);

            //DrawCard(5);
            PlayerPerks = new List<Perk>(15);
            EnemyPerks = new List<Perk>(15);

            Inventories = new List<Inventory>(20);
            InverntoryName = new List<string>(20);
        }

        public int PHp
        {
            get => s_pHp;
            set
            {
                if (value < 0)
                {
                    s_pHp = 0;
                }
                else
                {
                    s_pHp = value;
                }
            }
        }
        public int EHp
        {
            get
            {
                return s_eHp;
            }

            set
            {
                if (value < 0)
                    s_eHp = 0;
                else
                    s_eHp = value;
            }
        }
        public int PShield { get; set; }
        public int EShield { get; set; }
        public int MaxEnergy { get; set; }
        public int Energy
        {
            get => s_energy; set
            {
                if (value < MaxEnergy)
                    s_energy = value;
                else
                    s_energy = MaxEnergy;
            }
        }
        public int EMaxEnergy { get; set; }
        public int EEnergy
        {
            get => _eEnergy;
            set
            {
                if (value > EMaxEnergy)
                {
                    _eEnergy = EMaxEnergy;
                }
                else
                _eEnergy = value;
            }
        }

        public enum AIstates
        {
            集赞灵 = 0,
            消耗灵 = 1,
            打法卡 = 2,
            打灵卡 = 3,
            结束 = 4,
        }
        public AIstates AIstate { get; set; }

        public StringBuilder RoundResult { get; set; }
        public List<Card> EHandCardGroup { get; set; }
        public List<Card> ENowCardGroup { get; set; }
        public List<Card> HandCardGroup { get; set; }
        public List<Card> NowCardGroup { get; set; }
        public List<Perk> PlayerPerks { get; set; }
        public List<Perk> EnemyPerks { get; set; }

        public List<Inventory> Inventories { get; set; }
        public List<string> InverntoryName { get; set; }


        public int Round { get; set; }

        public override void SetSelect()
        {
            //base.SetSelect();
        }
        public override void OutRuning()
        {
            base.OutRuning();
            Inventories.Clear();

        }

        public override void Runing()
        {
            DeBugRun();
            ReLoading();
            GetBattleDate();

            while (OutRoom == null)
            {
                IsPlayerRound = true;
                ThePlayerRound();
                if (!Result)
                {
                    IsPlayerRound = false;
                    TheEnemyRound();
                }
                if (Result)
                    TheResultRound();
            }
        }

        private void ReLoading()
        {
            NowCardGroup.Clear();
            ENowCardGroup.Clear();
            HandCardGroup.Clear();
            EHandCardGroup.Clear();
            RoundResult.Clear();
            OutRoom = null;
            Result = false;
            Round = 0;
            Energy = 0;
            EEnergy = 0;
            PShield = 0;
            EShield = 0;
        }

        private void GetBattleDate()
        {
            //player
            PHp = Player.UnitHp;
            MaxEnergy = Player.UnitMaxLing;
            NowCardGroup.AddRange(Player.UnitCards.ToArray());

            //enemy
            //
            EHp = Enemy.UnitHp;
            EMaxEnergy = Enemy.UnitMaxLing;
            ENowCardGroup.AddRange(Enemy.UnitCards.ToArray());


            
        }

        private void AutoPlayCardAi()
        {
            if (EMaxEnergy == 0)
                AIstate = AIstates.集赞灵;
            else if (EEnergy == EMaxEnergy)
                AIstate = AIstates.消耗灵;
            else
                AIstate = AIstates.集赞灵;
            while (AIstate != AIstates.结束 && EHandCardGroup.Count > 0)
            {
                if (PHp <= 0 || EHp <= 0)
                {
                    AIstate = AIstates.结束;
                }
                switch (AIstate)
                {
                    case AIstates.集赞灵:
                        bool have = false;
                        foreach (var item in EHandCardGroup)
                        {
                            if (item.EnergyCost == 0)
                            {
                                have = true;
                            }
                        }
                        if (have)
                        {
                            for (int i = 0; i < EHandCardGroup.Count; i++)
                            {
                                if (EHandCardGroup[i].EnergyCost == 0)
                                {
                                    AiPlayCard(i);
                                    break;
                                }
                            }
                            if (EEnergy == EMaxEnergy && EMaxEnergy != 0)
                                AIstate = AIstates.消耗灵;
                        }
                        else
                        {
                            AIstate = AIstates.消耗灵;
                            if (EEnergy == 0)
                            {
                                AIstate = AIstates.结束;
                            }
                        }
                        break;
                    case AIstates.消耗灵:
                        bool have1 = false;
                        foreach (var item in EHandCardGroup)
                        {
                            if (item.EnergyCost <= EEnergy && item.EnergyCost > 0)
                            {
                                have1 = true;
                            }
                        }
                        if (have1)
                        {
                            AIstate = AIstates.打灵卡;
                            foreach (var item in EHandCardGroup)
                            {
                                if (item.EnergyCost <= EEnergy && item.CardType == Card.CardTypes.法)
                                {
                                    AIstate = AIstates.打法卡;
                                }
                            }
                        }
                        else
                        {
                            AIstate = AIstates.结束;
                            foreach (var item in EHandCardGroup)
                            {
                                if (item.EnergyCost == 0)
                                {
                                    AIstate = AIstates.集赞灵;
                                }
                            }
                        }
                        break;
                    case AIstates.打法卡:
                        for (int i = 0; i < EHandCardGroup.Count; i++)
                        {
                            if (EHandCardGroup[i].EnergyCost <= EEnergy && EHandCardGroup[i].CardType == Card.CardTypes.法)
                            {
                                AiPlayCard(i);
                                break;
                            }
                        }
                        AIstate = AIstates.集赞灵;
                        if (EEnergy == EMaxEnergy && EMaxEnergy != 0)
                            AIstate = AIstates.消耗灵;
                        break;
                    case AIstates.打灵卡:
                        for (int i = 0; i < EHandCardGroup.Count; i++)
                        {
                            if (EHandCardGroup[i].EnergyCost <= EEnergy && EHandCardGroup[i].CardType == Card.CardTypes.灵)
                            {
                                AiPlayCard(i);
                                break;
                            }
                        }
                        AIstate = AIstates.集赞灵;
                        if (EEnergy == EMaxEnergy && EMaxEnergy != 0)
                            AIstate = AIstates.消耗灵;  
                        break;
                    case AIstates.结束:
                        break;

                }
            }
        }
        private void AutoPlayCardPlayer()
        {
            if (MaxEnergy == 0)
                AIstate = AIstates.集赞灵;
            else if (Energy == MaxEnergy)
                AIstate = AIstates.消耗灵;
            else
                AIstate = AIstates.集赞灵;
            while (AIstate != AIstates.结束 && HandCardGroup.Count > 0)
            {
                if (PHp <= 0 || EHp <= 0)
                {
                    AIstate = AIstates.结束;
                }
                switch (AIstate)
                {
                    case AIstates.集赞灵:
                        bool have = false;
                        foreach (var item in HandCardGroup)
                        {
                            if (item.EnergyCost == 0)
                            {
                                have = true;
                            }
                        }
                        if (have)
                        {
                            for (int i = 0; i < HandCardGroup.Count; i++)
                            {
                                if (HandCardGroup[i].EnergyCost == 0)
                                {
                                    AiPlayCard(i);
                                    break;
                                }
                            }
                            if (Energy == MaxEnergy && MaxEnergy != 0)
                                AIstate = AIstates.消耗灵;
                        }
                        else
                        {
                            AIstate = AIstates.消耗灵;
                            if (Energy == 0)
                            {
                                AIstate = AIstates.结束;
                            }
                        }
                        break;
                    case AIstates.消耗灵:
                        bool have1 = false;
                        foreach (var item in HandCardGroup)
                        {
                            if (item.EnergyCost <= Energy && item.EnergyCost > 0)
                            {
                                have1 = true;
                            }
                        }
                        if (have1)
                        {
                            AIstate = AIstates.打灵卡;
                            foreach (var item in HandCardGroup)
                            {
                                if (item.EnergyCost <= Energy && item.CardType == Card.CardTypes.法)
                                {
                                    AIstate = AIstates.打法卡;
                                }
                            }
                        }
                        else
                        {
                            AIstate = AIstates.结束;
                            foreach (var item in HandCardGroup)
                            {
                                if (item.EnergyCost == 0)
                                {
                                    AIstate = AIstates.集赞灵;
                                }
                            }
                        }
                        break;
                    case AIstates.打法卡:
                        for (int i = 0; i < HandCardGroup.Count; i++)
                        {
                            if (HandCardGroup[i].EnergyCost <= Energy && HandCardGroup[i].CardType == Card.CardTypes.法)
                            {
                                AiPlayCard(i);
                                break;
                            }
                        }
                        AIstate = AIstates.集赞灵;
                        if (Energy == MaxEnergy && MaxEnergy != 0)
                            AIstate = AIstates.消耗灵;
                        break;
                    case AIstates.打灵卡:
                        for (int i = 0; i < HandCardGroup.Count; i++)
                        {
                            if (HandCardGroup[i].EnergyCost <= Energy && HandCardGroup[i].CardType == Card.CardTypes.灵)
                            {
                                AiPlayCard(i);
                                break;
                            }
                        }
                        AIstate = AIstates.集赞灵;
                        if (Energy == MaxEnergy && MaxEnergy != 0)
                            AIstate = AIstates.消耗灵;
                        break;
                    case AIstates.结束:
                        break;

                }
            }
        }


        private void TheResultRound()
        {
            PrintUnitData();
            Console.WriteLine("战斗结束");
            if (PHp == EHp)
            {
                Console.WriteLine("你被<{0}>击杀，魂魄消散于天地间", Enemy.Name);
                Console.WriteLine();
                Console.WriteLine("修行之路本逆天，半道而亡亦寻常");
                Console.WriteLine();
                Console.WriteLine("按\"{0}\"返回开始界面",Controller.ControllerKeys[Controller.KeyName.BackKey]);
                OutRoom = GameMainRecycle.RoomScripts.Group[typeof(StartRoomScript).Name];
                while (true)
                {
                    Controller.KeyName key = Controller.ReadKeyDown();
                    if (key == Controller.KeyName.BackKey)
                        break;
                }
            }
            else if (PHp == 0)
            {
                Console.WriteLine("你被<{0}>击杀，魂魄消散于天地间",Enemy.Name);
                Console.WriteLine();
                Console.WriteLine("修行之路本逆天，半道而亡亦寻常");
                Console.WriteLine();
                Console.WriteLine("按\"{0}\"返回开始界面", Controller.ControllerKeys[Controller.KeyName.BackKey]);
                OutRoom = GameMainRecycle.RoomScripts.Group[typeof(StartRoomScript).Name];
                while (true)
                {
                    Controller.KeyName key = Controller.ReadKeyDown();
                    if (key == Controller.KeyName.BackKey)
                        break;
                }
            }
            else
            {
                Console.WriteLine("你击败了<{0}>获得胜利", Enemy.Name);
                Console.WriteLine("按\"{0}\"取得战利品", Controller.ControllerKeys[Controller.KeyName.EnterKey]);
                OutRoom = LastRoom;
                LastRoom.RetureRoom = true;
                if(OutRoom.GetType() == typeof(MapRoomScript))
                {
                    MapRoomScript mapRoom = (MapRoomScript)OutRoom;
                    mapRoom.Script.NowMapChar[mapRoom.SeeY, mapRoom.SeeX] = '、';
                    if (mapRoom.Script.MapType == MapScript.MapTypes.maze)
                    {
                        Player.UnitHp = PHp;
                    }
         
                }
                while (true)
                {
                    Controller.KeyName key = Controller.ReadKeyDown();
                    if (key == Controller.KeyName.EnterKey)
                        break;
                }
                GetInverntory();
                UpDateQuest();
                
            }
            
        }

        private void UpDateQuest()
        {
            GameQuest pq = GameMainRecycle.PlayerInfo.PlayerQuest;
            
            
            if (pq != null)
            {
                foreach (var item in pq.Kills)
                {
                    if (item.NpcName == Enemy.GetType().Name)
                    {
                        item.NowKillCont += 1;
                    }
                }
            }

            
        }

        private void TheEnemyRound()
        {
            Console.Clear();
            DrawCard(7);
            #region AI
            AutoPlayCardAi();

            #endregion

            EHandCardGroup.Clear();//结束打卡清空手牌
            PrintUnitData();
            Console.Write(RoundResult.ToString());
            Console.WriteLine();
            Console.WriteLine("敌方回合结束({0})继续",Controller.ControllerKeys[Controller.KeyName.BackKey]);
            while (true)
            {
                Controller.KeyName key = Controller.ReadKeyDown();
                if (key == Controller.KeyName.BackKey)
                {
                    RoundResult.Clear();
                    break;
                }
            }
            if (PHp <= 0 || EHp <= 0)
            {
                Result = true;
            }
            else
                Result = false;
        }

        private void ThePlayerRound()
        {
            InToPlayerRound();
            while (HandCardGroup.Count > 0)
            {
                int line = PrintRoundText();
                bool goOut = false;
                while (HandCardGroup.Count > 0 && goOut == false)
                {
                    goOut = SelectAndPlayCard(line);
                    if (Result)
                        return;
                }
            }

            EndPlayRound();


        }

        private void EndPlayRound()
        {
            PrintUnitData();
            Console.Write(RoundResult.ToString());
            Console.WriteLine();
            Console.WriteLine("玩家回合结束按({0})退出",Controller.ControllerKeys[Controller.KeyName.BackKey]);
            while (true)
            {
                Controller.KeyName key = Controller.ReadKeyDown();
                if (key == Controller.KeyName.BackKey)
                {
                    RoundResult.Clear();
                    break;
                }
            }
            if (PHp <= 0 || EHp <= 0)
            {
                Result = true;
            }
            else
                Result = false;

        }

        private void GetInverntory()
        {
            //Inventories.Clear();
            
            DrawInverntory(5);
            int s = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("战利品：");

                if(Inventories.Count > 0)
                {
                    InverntoryName.Clear();
                    foreach (var item in Inventories)
                    {
                        InverntoryName.Add(item.Name);
                    }
                    
                    s = PrintHelper.PrintSelectText(InverntoryName, s);
                    if (s > Inventories.Count)
                    {
                        break;
                    }
                    else
                    {
                        switch (Inventories[s].InType)
                        {
                            case Inventory.InventoryType.equipment:
                            case Inventory.InventoryType.funbook:
                                GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Add((Inventory)Inventories[s].Clone());
                                Inventories.RemoveAt(s);
                                break;
                            case Inventory.InventoryType.resource:
                            case Inventory.InventoryType.stone:
                                bool have = false;
                                foreach (var item in GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys)
                                {
                                    if (item.GetType() == Inventories[s].GetType())
                                    {
                                        have = true;
                                        Resource resource_p = (Resource)item;
                                        Resource resource_get = (Resource)Inventories[s];
                                        resource_p.Amount += resource_get.Amount;
                                    }
                                }
                                if (!have)
                                {
                                    GameMainRecycle.PlayerInfo.PlayerUnit.Inventorys.Add((Inventory)Inventories[s].Clone());
                                }
                                Inventories.RemoveAt(s);
                                break;
                            default:
                                break;
                        }
                        
                    }

                }
                else
                {
                    break;
                }
                



            }
        }

        private bool SelectAndPlayCard(int line)
        {
            bool goOut = false;
            Console.SetCursorPosition(0, SelectIndex + 1 + line);
            Console.Write("=>");
            Console.SetCursorPosition(22, line + 1);
            Console.Write("                                                                                 ");
            Console.SetCursorPosition(22, line + 1);
            Console.Write(HandCardGroup[SelectIndex].Describe);
            if (HandCardGroup[SelectIndex].EnergyCost > Energy)
            {

                Console.SetCursorPosition(20, line);
                Console.Write("描述:(灵气不足无法打出)");
            }
            else
            {
                Console.SetCursorPosition(20, line);
                Console.Write("描述:                           ");
            }
            Controller.KeyName key = Controller.ReadKeyDown();
            Console.SetCursorPosition(0, SelectIndex + 1 + line);
            Console.Write("  ");
            switch (key)
            {
                case Controller.KeyName.UpKey:
                    SelectIndex -= 1;
                    break;
                case Controller.KeyName.DownKey:
                    SelectIndex += 1;
                    break;
                case Controller.KeyName.RightKey:
                case Controller.KeyName.EnterKey:
                    goOut = PlayOneCard();
                    if (PHp <= 0 || EHp <= 0)
                    {
                        Result = true;
                    }
                    break;
                case Controller.KeyName.LeftKey:
                case Controller.KeyName.BackKey:
                    AutoPlayCardPlayer();
                    HandCardGroup.Clear();
                    goOut = true;
                    break;
                case Controller.KeyName.MenuKey:
                    break;
            }
            if (SelectIndex >= HandCardGroup.Count - 1)
            {
                SelectIndex = HandCardGroup.Count - 1;
            }
            else if (SelectIndex <= 0)
            {
                SelectIndex = 0;
            }

            return goOut;
        }

        private int PrintRoundText()
        {
            PrintUnitData();
            int line = Console.CursorTop;
            Console.Write("卡牌：");
            Console.SetCursorPosition(20, line);
            Console.WriteLine("描述:");
            foreach (var item in HandCardGroup)
            {
                Console.WriteLine("  ({1}){0}({2})", item.Name, item.EnergyCost, item.CardType);
            }

            return line;
        }

        private void Shuffle(List<Card> cards)
        {
            ShuffleHelper.ShuffleList(cards);
        }

        private void ShuffleInverntory()
        {
            ShuffleHelper.ShuffleList(Enemy.Inventorys);
        }

        public void DrawCard(int cont)
        {
            for (int i = 0; i < cont; i++)
            {
                List<Card> Howcards;
                if (IsPlayerRound)
                    Howcards = NowCardGroup;
                else
                    Howcards = ENowCardGroup;

                Shuffle(Howcards);
                if (IsPlayerRound)
                    HandCardGroup.Add(Howcards[0]);
                else
                    EHandCardGroup.Add(Howcards[0]);

                Howcards.RemoveAt(0);
                if (Howcards.Count <= 0)
                {
                    if (IsPlayerRound)
                        Howcards.AddRange(Player.UnitCards.ToArray());
                    else
                        Howcards.AddRange(Enemy.UnitCards.ToArray());
                }
            }


        }

        private void DrawInverntory(int cont)
        {
            for (int i = 0; i < cont; i++)
            {
                ShuffleInverntory();
                if(Enemy.Inventorys.Count>0)
                Inventories.Add(Enemy.Inventorys[0]);
            }
        }

        private void InToPlayerRound()
        {
            SelectIndex = 0;
            //Energy = 3;
            DrawCard(7);
            Round += 1;
        }

        private void PrintUnitData()
        {
            Console.Clear();
            Console.Write("玩家: {0}", Player.Name);
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("敌方: {0}   回合数：{1}", Enemy.Name, Round);
            Console.Write("生命：");
            Console.WriteLine("{0}/{1}", PHp,Player.UnitMaxHp);
            //PhealBar();
            Console.SetCursorPosition(20, 1);
            Console.Write("生命：");
            Console.WriteLine("{0}/{1}",EHp,Enemy.UnitMaxHp);
            //Console.WriteLine();
            Console.Write("护甲: ");
            Console.WriteLine(PShield);
            Console.SetCursorPosition(20, 2);
            Console.Write("护甲: ");
            Console.WriteLine(EShield);
            Console.Write("能量: ");
            Console.WriteLine("{0}/{1}", Energy, MaxEnergy);
            Console.SetCursorPosition(20, 3);
            Console.Write("能量: ");
            Console.WriteLine("{0}/{1}", EEnergy, EMaxEnergy);
            Console.Write("玩家被动:");
            foreach (var item in PlayerPerks)
            {
                Console.Write("{0}, ", item.Symbol);
            }
            Console.WriteLine();

            Console.WriteLine();

        }

        private void PhealBar()
        {
            Console.Write(" <");
            int ph = (int)(((float)PHp / (float)Player.UnitMaxHp) * 10);
            for (int i = 0; i < ph; i++)
            {
                Console.Write("/");
            }
            for (int ii = 0; ii < 10 - ph; ii++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(">");
        }

        private bool PlayOneCard()
        {
            if (HandCardGroup[SelectIndex].EnergyCost <= Energy)
            {
                Energy -= HandCardGroup[SelectIndex].EnergyCost;
                HandCardGroup[SelectIndex].RunResult();
                HandCardGroup.RemoveAt(SelectIndex);
                PrintUnitData();
                Console.Write(RoundResult.ToString());
                Console.WriteLine();
                Console.WriteLine("按({0})继续",Controller.ControllerKeys[Controller.KeyName.BackKey]);
                while (true)
                {
                    Controller.KeyName key0 = Controller.ReadKeyDown();
                    if (key0 == Controller.KeyName.BackKey)
                    {
                        break;
                    }
                }
                RoundResult.Clear();
                return true;
            }
            else
                return false;
        }

        private void AiPlayCard(int HandIndex)
        {
            if (!IsPlayerRound)
            {
                if (EHandCardGroup[HandIndex].EnergyCost <= EEnergy)
                {
                    EEnergy -= EHandCardGroup[HandIndex].EnergyCost;
                    EHandCardGroup[HandIndex].RunResult();
                    EHandCardGroup.RemoveAt(HandIndex);
                }
            }
            else
            {
                if (HandCardGroup[HandIndex].EnergyCost <= Energy)
                {
                    Energy -= HandCardGroup[HandIndex].EnergyCost;
                    HandCardGroup[HandIndex].RunResult();
                    HandCardGroup.RemoveAt(HandIndex);
                }
            }
            
        }



    }
}
