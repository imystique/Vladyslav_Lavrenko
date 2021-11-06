using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test1()
        {
            List<object> s = new List<object>{ 1, 2, 'a', '1' };
            List<object> s1 = new List<object> { 1, 2 };
            Assert.AreEqual(s1, Func_Task_1(s));
        }
        [Test]
        public void Test2()
        {
            List<object> s = new List<object> { -1, 1, 2, -2, 'a', 'b', "aasf", '1', "123", 231, -15, -342 };
            List<object> s1 = new List<object> { 1, 2, 231 };
            Assert.AreEqual(s1, Func_Task_1(s));
        }
        [Test]
        public void Test3()
        {
            string s = "stress";
            Assert.AreEqual('t', First_Non_Repeating_Letter(s));
        }
        [Test]
        public void Test4()
        {
            string s = "sTreSS";
            Assert.AreEqual('T', First_Non_Repeating_Letter(s));
        }
        [Test]
        public void Test5()
        {
            int a = 7;
            Assert.AreEqual(7, Digital_Root(a));
        }
        [Test]
        public void Test6()
        {
            int a = 132189;
            Assert.AreEqual(6, Digital_Root(a));
        }
        [Test]
        public void Test7()
        {
            int a = -132189;
            Assert.AreEqual(6, Digital_Root(a));
        }
        [Test]
        public void Test8()
        {
            int a = 5;
            Assert.AreEqual(4, Func_Task_4(a));
        }
        [Test]
        public void Test9()
        {
            int a = 8;
            Assert.AreEqual(3, Func_Task_4(a));
        }
        [Test]
        public void Test10()
        {
            List<KeyValuePair<string, string>> l = new List<KeyValuePair<string, string>> { 
                new KeyValuePair<string, string>("ALFRED", "CORWILL"), new KeyValuePair<string, string>("FRED", "CORWILL"),
                new KeyValuePair<string, string>("RAPHAEL", "CORWILL"), new KeyValuePair<string, string>("WILFRED", "CORWILL"), 
                new KeyValuePair<string, string>("BARNEY", "TORNBULL"), new KeyValuePair<string, string>("BETTY", "TORNBULL"),
                new KeyValuePair<string, string>("BJON", "TORNBULL")};
            string s = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            Assert.AreEqual(l, Func_Task_5(s));
        }
        [Test]
        public void Test11()
        {
            List<KeyValuePair<string, string>> l = new List<KeyValuePair<string, string>> {
            new KeyValuePair<string, string>("ANASTASIA", "AVKSENTIEVA"), new KeyValuePair<string, string>("VLAD", "LAVRENKO"),
            new KeyValuePair<string, string>("VLAD", "SHEVCHENKO"), new KeyValuePair<string, string>("SLAVA", "US") };
            string s = "Slava:Us;Anastasia:Avksentieva;Vlad:Lavrenko;Vlad:Shevchenko";
            Assert.AreEqual(l, Func_Task_5(s));
        }
        [Test]
        public void Test12()
        {
            int a = 2017;
            Assert.AreEqual(2071, BiggerNum(a));
        }
        [Test]
        public void Test13()
        {
            int a = 9;
            Assert.AreEqual(-1, BiggerNum(a));
        }
        [Test]
        public void Test14()
        {
            uint a = 32;
            Assert.AreEqual("0.0.0.32", Func_Extra_Task_2(a));
        }
        [Test]
        public void Test15()
        {
            uint a = 156752;
            Assert.AreEqual("0.2.100.80", Func_Extra_Task_2(a));
        }
        public List<object> Func_Task_1(List<object> list)
        {
            List<object> filtered = list.Where(x => (x is int)).ToList();
            for (int i = filtered.Count - 1; i >= 0; i--)
            {
                if (Convert.ToInt64(filtered[i]) < 0) filtered.RemoveAt(i);
            }
            Console.WriteLine("Task 1: " + string.Join(", ", filtered));
            return filtered;
        }
        public char First_Non_Repeating_Letter(string str)
        {
            //string a = "STress";
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                        break;
                    else
                    {
                        Console.WriteLine("Task 2: " + str[i]);
                        return str[i];
                    }
                }
            }
            return '\0';
        }
        public long Digital_Root(long number)
        {
            number = Math.Abs(number);
            long Sum = 0;
            for (; number != 0; number /= 10)
            {
                Sum += number % 10;
            }
            if (Sum > 10)
                Sum = Digital_Root(Sum);
            return Sum;
        }
        public int Func_Task_4(int num)
        {
            int[] arr = { 1, 3, 6, 2, 2, 0, 4, 5 };
            int flag = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == num)
                        flag++;
                }
            }
            Console.WriteLine("Task 4: " + flag);
            return flag;
        }
        public List<KeyValuePair<string, string>> Func_Task_5(string s)
        {
            s = s.ToUpper();
            //Console.WriteLine(s);
            List<string> s1 = s.Split(';').ToList();
            List<KeyValuePair<string, string>> s2 = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < s1.Count; i++)
            {
                KeyValuePair<string, string> temp = new KeyValuePair<string, string>(s1[i].Split(':')[0], s1[i].Split(':')[1]);
                s2.Add(temp);
                //Console.WriteLine(temp.Key + " --- " + temp.Value);
            }
            var s2_sorted = s2.OrderBy(s => s.Value).ThenBy(s => s.Key).ToList();
            Console.WriteLine("Task 5: ");
            for (int i = 0; i < s2_sorted.Count; i++)
                Console.WriteLine(s2_sorted[i]);
            return s2_sorted;
        }
        public void swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public int BiggerNum(int num)
        {
            string str = num.ToString();
            char[] ch = str.ToCharArray();
            int i, j;

            for (i = ch.Length - 1; i > 0; i--)
            {
                if (ch[i] > ch[i - 1])
                    break;
            }

            if (i == 0)
            {
                return -1;
            }

            else
            {
                int temp = i;
                for (j = i + 1; j < ch.Length; j++)
                {
                    if ((ch[j] < ch[temp]) && (ch[j] > ch[i - 1]))
                    {
                        temp = j;
                    }
                }
                swap(ch, i - 1, temp);
                Array.Sort(ch, i, ch.Length - i);
                str = new string(ch);
                Console.WriteLine("Extra Task 1: " + str);
                return Convert.ToInt32(str);
            }

        }
        public string Func_Extra_Task_2(uint num)
        {
            string ip = Convert.ToString(num, 2);
            int flag = 0;
            for (int i = ip.Length; i < 32; i++)
                ip = ip.Insert(0, "0");
            for (int i = 0; i < ip.Length; i++)
            {
                if ((i % 8 == 0) && (i != 0))
                {
                    if (flag == 3) break;
                    ip = ip.Insert(i + flag, ".");
                    flag++;
                }
            }
            //Console.WriteLine(ip);
            string[] temp = ip.Split('.');
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = Convert.ToUInt64(temp[i], 2).ToString();
            }
            ip = string.Join('.', temp);
            Console.WriteLine("Extra Task 2: " + ip);
            return ip;
        }
    }
}
