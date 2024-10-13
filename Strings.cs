using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTTWorld
{
    public static class Strings
    {
        public static string GetRandom(this string[] orgin)
        {
            Random random = new Random();
            return orgin[random.Next(0, orgin.Length)];
        }
        public static string Intro = "你说得对，但是《MTT》是由liziyu0714自主研发的一款全新开放世界冒险游戏。游戏发生在一个被称作「HZ」的幻想世界，在这里被ln选中的Joker将被授予「数学作业」，引导消愁之力。你将扮演一位名为「{NAME}」的神秘角色，在自由的HZ校园中邂逅性格各异、能力独特的斯人们，和它们一起击败MTT，找回的同时，逐步发掘「HZ」的真相 。";
        public static string[] DoingMathHomeworkInClass = new string[] { "你按着往常的习惯，在{LESSON}课上从书包中熟练地掏出数学作业，写了起来" 
        ,"你看了看老师，掏出了数学作业"
        ,"深吸一口气，你拿出数学作业"
        ,"没有丝毫犹豫，数学作业就到了你的桌子上，压在别的书下面"
        };
        public static string[] DoingMathHomeworkInClassCaught = new string[] {"你被{LESSON}课的老师抓住了，你很伤心"
        ,"门外巡查的老师把你叫了出去，狠狠地训斥"
        ,"班主任从后门走进来，一把抽出你的作业"};
        public static string[] DoingMathHomeworkInClassCaughtByMTT = new string[] {"MTT看到了你在她的课上写作业，非常愤怒。"
        };
        public static string[] ListenCarefully = new string[] {
        "你怀着热情听完了这节课。"};
        public static string[] Listen = new string[] {"你勉强听完了这节课。"
        ,"你平淡地度过了这节课"
        ,"你显然不是听这节课的料"
        ,"你觉得你似乎收获满满，但其实..."
        };
        public static string[] SleepInClass = new string[] { "你在课上提心吊胆的慢慢合上眼。" };
        public static string[] Sleep = new string[] {"你睡着了。但上课铃很快吵醒了你。" };
    }
}
