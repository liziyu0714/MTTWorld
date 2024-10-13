using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MTTWorld
{
    public class Card
    {
        public static void AddProperty(PlayerState state,int totalValue , int addTarget,int striction)
        {
            int add = 0;
            while (totalValue > 0)
            {
                for (int i = 0; i < striction; i++)
                {
                    if (i == addTarget)
                        add = new Random().Next(0, totalValue + 1);
                    else add = new Random().Next(0, totalValue / 10 + 1);
                    state.Values[i] += add;
                    totalValue -= add;
                }
            }
        }
        public int HappenRate { get; set; }
        public string CardDescription { get; set; } = string.Empty;
        public string Condition {  get; set; } = string.Empty;
        public virtual void Happened(PlayerState player)
        {

        }

    }

    public class OnceCard : Card
    {
        public virtual void HappenOnce(PlayerState player) { }
        public sealed override void Happened(PlayerState player)
        {
            base.Happened(player);
            Happened(player);
            player.Pool.Cards.Remove(this);
        }
    }

    public class CardWriteMathsHomework : Card
    {
        public override void Happened(PlayerState player)
        {
            AnsiConsole.WriteLine(Strings.DoingMathHomeworkInClass.GetRandom().Replace("{LESSON}",player.LessonName));
            AddProperty(player,new Random().Next(0,5),new Random().Next(0,4),5);
            if(new Random().Next(0,5) == 0)
            {
                AnsiConsole.WriteLine(Strings.DoingMathHomeworkInClassCaught.GetRandom().Replace("{LESSON}", player.LessonName));
                player.Values.MentalState -= new Random().Next(1,10);
            }
            else if(new Random().Next(0, 5) == 0 && player.LessonName == "Math")
            {
                AnsiConsole.WriteLine(Strings.DoingMathHomeworkInClassCaughtByMTT.GetRandom());
                player.Values.MentalState -= new Random().Next(10, 20);
                player.Values.PhysicalState -= new Random().Next(1,10);
            }
        }

        public CardWriteMathsHomework() :base()
        {
            Condition = "InClass";
            HappenRate = 100;
            CardDescription = "偷偷写数学作业";
        }
    }
    public class CardListenCarefully : Card
    {
        public CardListenCarefully() : base()
        {
            Condition = "InClass";
            HappenRate = 100;
            CardDescription = "认真听课";
        }
        public override void Happened(PlayerState player)
        {
            AnsiConsole.WriteLine(Strings.ListenCarefully.GetRandom().Replace("{LESSON}",player.LessonName));
            AddProperty(player, new Random().Next(0, 10), 4, 7);
        }
    }

    public class CardListen : Card
    {
        public CardListen() : base()
        {
            Condition = "InClass";
            HappenRate = 1000;
            CardDescription = "听课";
        }
        public override void Happened(PlayerState player)
        {
            AnsiConsole.WriteLine(Strings.Listen.GetRandom().Replace("{LESSON}", player.LessonName));
            AddProperty(player, new Random().Next(0, 5),4, 7);
        }
    }

    public class CardSleep : Card
    {
        public CardSleep() : base()
        {
            Condition = "InClass";
            CardDescription = "上课睡觉";
            HappenRate = 200;
        }
        public override void Happened(PlayerState player)
        {
            AnsiConsole.WriteLine(Strings.SleepInClass.GetRandom().Replace("{LESSON}", player.LessonName));
            player.Values.MentalState += new Random().Next(0, 2);
            player.Values.PhysicalState += new Random().Next(0, 5);
        }
    }

    public class CardSleepBreak : Card
    {
        public CardSleepBreak() : base()
        {
            Condition = "Break";
            CardDescription = "睡觉";
            HappenRate = 200;
        }
        public override void Happened(PlayerState player)
        {
            AnsiConsole.WriteLine(Strings.Sleep.GetRandom().Replace("{LESSON}", player.LessonName));
            player.Values.MentalState += new Random().Next(0, 5);
            player.Values.PhysicalState += new Random().Next(0, 10);
        }
    }
    public class CardToilet : Card
    {
        public CardToilet() : base()
        {
            Condition = "Break";
            CardDescription = "上厕所";
            HappenRate = 200;
        }
        public override void Happened(PlayerState player)
        {
            AnsiConsole.WriteLine(Strings.Sleep.GetRandom().Replace("{LESSON}", player.LessonName));
            player.Values.MentalState += new Random().Next(0, 1);
            player.Values.PhysicalState += new Random().Next(0, 5);
        }
    }
}
