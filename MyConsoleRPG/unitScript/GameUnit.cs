using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    /// <summary>
    /// 游戏单位类
    /// </summary>
    class GameUnit
    {
        public string Name { get; set; }

        public int Rank { get; set; }
        private int unitHp;
        private List<Card> _unitCards;
        private int _gold;
        private int _wood;
        private int _water;
        private int _fire;
        private int _soil;
        private int _unitMaxLing;
        private List<Inventory> _inventorys;


        //限制生命值
        public int UnitHp
        {
            get => unitHp;
            set
            {
                if (value <= 0)
                    unitHp = 0;
                else if (value >= UnitMaxHp)
                    unitHp = UnitMaxHp;
                else
                    unitHp = value;
            }
        }
        public int UnitMaxLing
        {
            get
            {
                UpdateMaxLing();
                return _unitMaxLing;
            }

            set => _unitMaxLing = value;
        }

        private void UpdateMaxLing()
        {
            _unitMaxLing = 0;
            switch (Equipments.UnitWeapon.WeaponType)
            {
                case TheFiveElements.Gold:
                    _unitMaxLing = Gold / 5;
                    break;
                case TheFiveElements.Wood:
                    _unitMaxLing = Wood / 5;
                    break;
                case TheFiveElements.Water:
                    _unitMaxLing = Water / 5;
                    break;
                case TheFiveElements.Fire:
                    _unitMaxLing = Fire / 5;
                    break;
                case TheFiveElements.Soil:
                    _unitMaxLing = Soil / 5;
                    break;

            }
        }

        public int UnitMaxHp { get; set; }
        public int UnitATK { get; set; }
        public int UnitHIT { get; set; }
        public int UnitDex { get; set; }
        public bool IsDeath { get; set; }
        public int Gold
        {
            get
            {
                UpdateFiveElement(TheFiveElements.Gold);
                return _gold;
            }
            set => _gold = value;
        }
        public int Wood
        {
            get
            {
                UpdateFiveElement(TheFiveElements.Wood);
                return _wood;
            }

            set => _wood = value;
        }
        public int Water
        {
            get
            {
                UpdateFiveElement(TheFiveElements.Water);
                return _water;
            }

            set => _water = value;
        }
        public int Fire
        {
            get
            {
                UpdateFiveElement(TheFiveElements.Fire);
                return _fire;
            }

            set => _fire = value;
        }
        public int Soil
        {
            get
            {
                UpdateFiveElement(TheFiveElements.Soil);
                return _soil;
            }

            set => _soil = value;
        }
        public UnitEquipments Equipments { get; set; }
        public List<Function> Functions { get; set; }
        public List<Inventory> Inventorys
        {
            get
            {
                for (int ii = 0; ii < _inventorys.Count; ii++)
                {
                    if(_inventorys[ii].InType == Inventory.InventoryType.resource)
                    {
                        Resource temp = (Resource)_inventorys[ii];
                        if(temp.Amount <= 0)
                        {
                            _inventorys.RemoveAt(ii);
                        }
                    }
                }
                return _inventorys;
            }
            set
            {
                _inventorys = value;
            }
        }
        public List<Card> UnitCards
        {
            get
            {
                UpdateUnitCards();
                return _unitCards;
            }
            set => _unitCards = value;
        }

        public GameUnit()
        {
            Equipments = new UnitEquipments();
            Functions = new List<Function>(50);
            Inventorys = new List<Inventory>(50);
            UnitCards = new List<Card>(100);
            SetBaseFun();
        }


        [Newtonsoft.Json.JsonConstructor]
        public GameUnit(UnitEquipments unitEquipments)
        {
            Equipments = unitEquipments;
        }

        public void Die()
        {
            UnitHp = 0;
            IsDeath = true;
        }

        public void UpdateUnitCards()
        {
            _unitCards.Clear();
            _unitCards.AddRange(Equipments.UnitWeapon.WeaponCards);
            foreach (var item in Functions)
            {
                if (item.FunCard != null)
                {
                    _unitCards.Add(GameMainRecycle.Cards.Group[ item.FunCard]);
                }
            }
        }

        private void UpdateFiveElement(TheFiveElements elements)
        {
            switch (elements)
            {
                case TheFiveElements.Gold:
                    _gold = 0;
                    foreach (var item in Functions)
                    {
                        if (item.FunType == elements)
                        {
                            _gold += item.Value * item.Level;
                        }
                    }
                    break;
                case TheFiveElements.Wood:
                    _wood = 0;
                    foreach (var item in Functions)
                    {
                        if (item.FunType == elements)
                        {
                            _wood += item.Value * item.Level;
                        }
                    }
                    break;
                case TheFiveElements.Water:
                    _water = 0;
                    foreach (var item in Functions)
                    {
                        if (item.FunType == elements)
                        {
                            _water += item.Value * item.Level;
                        }
                    }
                    break;
                case TheFiveElements.Fire:
                    _fire = 0;
                    foreach (var item in Functions)
                    {
                        if (item.FunType == elements)
                        {
                            _fire += item.Value * item.Level;
                        }
                    }
                    break;
                case TheFiveElements.Soil:
                    _soil = 0;
                    foreach (var item in Functions)
                    {
                        if (item.FunType == elements)
                        {
                            _soil += item.Value * item.Level;
                        }
                    }
                    break;

            }

        }

        public virtual void SetBaseFun()
        {

        }



    }
}
