using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCard
{
    class GameCore
    {
        private static int s_pHp;
        private static int s_eHp;
        private static int s_energy;

        public static int PHp
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
        public static int EHp
        {
            get => s_eHp;
            set
            {
                if (value < 0)
                    s_eHp = 0;
                else
                    s_eHp = value;
            }
        }
        public static int PShield { get; set; }
        public static int EShield { get; set; }
        public static int MaxEnergy { get; set; }
        public static int Energy
        {
            get => s_energy; set
            {
                if (value < MaxEnergy)
                    s_energy = value;
                else
                    s_energy = MaxEnergy;
            }
        }
        public static int EnemyRoundCont { get; set; }
        public static int Round { get; set; }
        public static StringBuilder Result { get; set; }
        public List<Card> HandCardGroup { get; set; }
        public List<Card> PlayerCardGroup { get; set; }
        public List<Card> NowCardGroup { get; set; }
        public List<Card> EnemyCardGroup { get; set; }
        public static List<Perk> PlayerPerks { get; set; }
        public static GameCore Selfcore { get; set; }

        public GameCore()
        {
            MaxEnergy = 5;
            Selfcore = this;
            EnemyRoundCont = 0;
            PHp = 50;
            EHp = 500;
            PShield = 0;
            EShield = 0;
            Energy = 0;
            EnemyCardGroup = new List<Card>(20)
            {
                new EAtkCard(),
                new EShieldCard(),
                new EAllCard(),

            };
            PlayerCardGroup = new List<Card>(20)
            {
                new AtkCard(),
                new AtkCard(),
                new AtkCard(),
                new AtkCard(),
                new AtkCard(),
                new ShieldCard(),
                new ShieldCard(),
                new ShieldCard(),
                new ShieldCard(),
                new BestAtkCard(),
                //new PerkCard(),
                
            };
            NowCardGroup = new List<Card>(20);
            NowCardGroup.AddRange(PlayerCardGroup.ToArray());
            HandCardGroup = new List<Card>(10);
            //DrawCard(5);
            PlayerPerks = new List<Perk>(15)
            {
                new AtkGetEnergy(),
                //new GetOneCardByPlay(this),
            };
            Result = new StringBuilder(200);

        }


        private void Shuffle(List<Card> cards)
        {
            int len = cards.Count;
            for (int i = 0; i < len; i++)
            {
                int index = new Random().Next(len);
                Card temp = cards[index];
                cards[index] = cards[i];
                cards[i] = temp;
            }
        }

        public void DrawCard(int cont)
        {
            for (int i = 0; i < cont; i++)
            {
                Shuffle(NowCardGroup);
                HandCardGroup.Add(NowCardGroup[0]);
                NowCardGroup.RemoveAt(0);
                if (NowCardGroup.Count <= 0)
                {
                    NowCardGroup.AddRange(PlayerCardGroup.ToArray());
                }
            }


        }


    }
}
