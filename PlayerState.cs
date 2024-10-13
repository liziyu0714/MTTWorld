using System.Diagnostics.CodeAnalysis;

namespace MTTWorld;

public class PlayerState
{
    public string Name { get; set; }
    public PlayerValues Values;
    public PlayerCardPool Pool { get; set; }

    public string LessonName { get; set; }
    public string Condition { get; set; }

    public PlayerState(string name)
    {
        Name = name;
        Values = new PlayerValues();
        Pool = new PlayerCardPool();
        LessonName = "";
        Condition = "";
        Pool.Cards.Add(new CardListenCarefully());
        Pool.Cards.Add(new CardWriteMathsHomework());
        Pool.Cards.Add(new CardListen());
        Pool.Cards.Add(new CardSleep());
        Pool.Cards.Add(new CardSleepBreak());
    }

}



public class PlayerCardPool
{
    public List<Card> Cards {  get; set; }
    public Card GetNext(string Condition)
    {
        int rateSum = 0;
        Cards.ForEach(c => { if(Condition.Contains(c.Condition)) rateSum += c.HappenRate; });
        if(rateSum == 0)
            return new Card() { CardDescription="卡池已空。"};
        Random random = new Random();
        while(true)
        {
            int selected = random.Next(0, rateSum);
            int nowValue = 0;
            foreach (var item in Cards)
            {
                if(Condition.Contains(item.Condition))
                {
                    if (selected <= nowValue + item.HappenRate)
                        return item;
                    nowValue += item.HappenRate;
                }
                
            }
        }
        throw new Exception();
    }

    public PlayerCardPool()
    {
        Cards = new List<Card>();
    }
}

public struct PlayerValues
{
    public int CalculateAbility;
    public int LogicalAbility;
    public int ThinkingAbility;
    public int ReadingAbility;
    public int Experience;
    public int WritingAppearance;
    public int Luck;
    public int PhysicalState;
    public int MentalState;
    public int Charm;
    public int Value1;
    public int Value2;
    public int this[int i]
    {
        readonly get
        {
            switch (i)
            {
                case 0:
                    return CalculateAbility;
                case 1: 
                    return LogicalAbility;
                case 2: 
                    return ThinkingAbility;
                case 3: 
                    return ReadingAbility;
                case 4: 
                    return Experience;
                case 5: 
                    return WritingAppearance;
                case 6: 
                    return Luck;
                case 7: 
                    return PhysicalState;
                case 8:
                    return Charm;
                case 9:
                    return Value1;
                case 10:
                    return Value2;

            }
            return 0;
        }
        set
        {
            switch (i)
            {
                case 0:
                    CalculateAbility = value;
                    break;
                case 1:
                    LogicalAbility = value;
                    break;
                case 2:
                    ThinkingAbility = value;
                    break;
                case 3:
                    ReadingAbility = value;
                    break;
                case 4:
                    Experience = value;
                    break;
                case 5:
                    WritingAppearance = value;
                    break;
                case 6:
                    Luck = value;
                    break;
                case 7:
                    PhysicalState = value;
                    break;
                case 8:
                    Charm = value;
                    break;
                case 9:
                    Value1 = value;
                    break;
                case 10:
                    Value2 = value;
                    break;

            }
        }
    }
}