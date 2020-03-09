using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleRPG
{
    class Story1_1RoomScript:RoomScript
    {
        public override void Runing()
        {
            DeBugRun();
            Console.WriteLine("楔子");
            Text();
        }
        public override void OutRuning()
        {
            base.OutRuning();
        }

        public override void SetSelect()
        {
            //base.SetSelect();

            //KeySelects[0] = new KeySelect(ConsoleKey.E, typeof(GameSelectRoom).Name, new StringBuilder().Append("游戏菜单"));
            KeySelects[1] = new KeySelect(Controller.KeyName.EnterKey,  new StringBuilder().Append("进入地图"),typeof(SwordSouthValleyMapScript));
            KeySelects[2] = new KeySelect(Controller.KeyName.BackKey, typeof(BattleRoomScript).Name, new StringBuilder().Append("进入战斗"));
        }

        public void Text()
        {
            PrintHelper.PrintStoryText(new StringBuilder().AppendFormat(
               @"{0}
《》传说在遥远的上古，洪荒时代的荒海界一片混沌，四只强大的凶兽由天外逃遁于此。九天外的四位仙人随之降临，将这四只凶兽斩杀。死去凶兽的兽血化作了荒海，凶兽的躯体，在荒海中化为了四大神州。仙人们将死去凶兽的真灵镇压，引九天灵气驱除荒海界的混沌。至此，荒海界诞生出了芸芸众生，以及，被真灵催生出的荒兽·····。
    
《》四位仙人镇守荒海界数千年后离去，留四卷灵诀于荒海先民，设 剑、兽、宝、珠四大灵宗存其传承，以期有缘者能借此开化成仙，踏入九天。荒海修真一脉，至此伊始。随着岁月更迭，沧海桑田，上古时的“四灵诀”早已被演化推演成不计其数的修真功法，而四大灵宗，也在历史的长河中不断分解融合，形成了林立于四大神州上的诸多修真门派。

《》天剑宗，位于苍龙神州西面，是苍龙神州上历史最悠久的剑修门派，底蕴深厚，山门广阔。天剑山，作为天剑宗的门派祖地，传说是上古四仙人的一把法剑所化，山势陡峭，直入云霄，远远看去，真仿若一把从天而降的巨剑直插入大地上的玉溪山脉之中。山脉被巨剑斩断的地方，形成了两个山谷，位于天剑山的南北两侧。剑南山谷、剑北山谷、天剑山，一山两谷，气象万千，共同组成了天剑宗雄浑壮阔的山门。

《》此时的剑南谷入口处，一群人正停留在山谷外的广场上，他们在地上或坐或躺，各个精疲力竭，喘着粗气。远处的森林处还不时的有人走出，同样筋疲力尽，艰难的向广场这里挪动着步子。

《》天剑宗，每五载开一次山门。山门开启时昭示天下，告有志之士，无论身份，皆可参加入门试炼。通过者，则可进入宗门修行，从此超脱凡尘，踏入修真一脉。天下间，无数英雄豪杰趋之若鹜，而每次借此入宗者却寥寥无几，入宗试炼之难，入门考验之严苛，可见一斑。

《》山门碑上的青年，早已收了法剑，在石碑顶上盘腿坐了下来，目光扫视着广场上的诸人，似乎是回忆起了什么，微微一笑，闭上了双眼，入定修行了起来。

", ""
                ),GameRoom.LineLength);
        }
    }
}
