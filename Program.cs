using Spectre.Console;
using System.Security.Cryptography.X509Certificates;

namespace MTTWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Result = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("选择操作:")
                .PageSize(10)
                .AddChoices(new[] { "载入存档","新游戏" }));
            if(Result == "新游戏")
            {
                var Name = AnsiConsole.Prompt(new TextPrompt<string>("输入你的名字:"));
                AnsiConsole.Write(new Markup(Strings.Intro.Replace("{NAME}",Name)));
                AnsiConsole.WriteLine("\n按任意键继续");
                Console.ReadKey();
                GameLoop(new(Name));
            }
            else
            {
                
            }
        }
        static void GameLoop(PlayerState state)
        {
            while (true)
            {
                for(int i = 1; i <= 25; i++)
                {
                    AnsiConsole.Clear();
                    var table = new Table();
                    table.AddColumn("属性名");
                    table.AddColumn("属性值");
                    table.Border(TableBorder.Rounded);
                    table.AddRow("计算能力", state.Values.CalculateAbility.ToString())
                        .AddRow("逻辑能力", state.Values.LogicalAbility.ToString())
                        .AddRow("思维能力", state.Values.ThinkingAbility.ToString())
                        .AddRow("阅读能力", state.Values.ReadingAbility.ToString())
                        .AddRow("做题经验", state.Values.Experience.ToString())
                        .AddRow("身体状态", state.Values.PhysicalState.ToString())
                        .AddRow("心理状态", state.Values.MentalState.ToString());

                    AnsiConsole.Write(table);
                    // 课  课  课  课 饭 午练 午休 课    课    课    课  晚饭 晚1    晚2    晚3    晚4
                    // 1 2 3 4 5 6 7  8  9    10 11 12 13 14 15 16 17   18  19 20 21  22  23  24 25
                    if (i % 2 == 1)
                    {
                        state.Condition = "InClass;";
                        AnsiConsole.Write($"这是第{i / 2 + 1}节课。");
                        if (i == 9)
                        {
                            state.Condition += "Noon;";
                            AnsiConsole.WriteLine("（午练）");
                        }
                        if(i == 19 || i == 21 || i == 23 || i == 25)
                        {
                            state.Condition += "Evening;";
                            AnsiConsole.WriteLine("（晚自习）");
                        }
                            
                    }
                    else
                    {
                        state.Condition = "Break;";
                        AnsiConsole.WriteLine("这是一个课间。");
                        if(i == 8)
                        {
                            state.Condition += "Meal;Lunch;";
                            AnsiConsole.WriteLine("是吃午饭的时候了。");
                        }
                        if(i == 10)
                        {
                            state.Condition += "Sleep;";
                            AnsiConsole.WriteLine("这是午休时间。");
                        }
                        if(i == 18)
                        {
                            state.Condition += "Meal;Dinner;";
                            AnsiConsole.WriteLine("吃晚饭的时间到了。");
                        }
                        if(i == 20 || i == 22 || i == 24)
                        {
                            state.Condition += "EveningBreak;";
                        }
                    }
                    Card[] cardToChoose = new Card[] { state.Pool.GetNext(state.Condition), state.Pool.GetNext(state.Condition), state.Pool.GetNext(state.Condition), state.Pool.GetNext(state.Condition), state.Pool.GetNext(state.Condition) };
                    var Choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .Title("你可以选择自己的操作:")
                        .AddChoices<string>(cardToChoose[0].CardDescription, cardToChoose[1].CardDescription, cardToChoose[2].CardDescription, cardToChoose[3].CardDescription, cardToChoose[4].CardDescription)
                        );
                    foreach( var card in cardToChoose )
                    {
                        if (card.CardDescription == Choice)
                        {
                            card.Happened(state);
                            break;
                        }
                    }
                    AnsiConsole.WriteLine("\n按任意键继续");
                    Console.ReadKey();
                }
                AnsiConsole.Clear();
                Console.WriteLine("今天结束了。");
                if (state.Values.MentalState < 0)
                    Console.WriteLine("你的心理状态已经处于危险值。");
                if (state.Values.PhysicalState < 0)
                    Console.WriteLine("你的身体状态已经处于危险值。");

            }

        }
    }
}
