using System;

namespace praktika_6
{
    public class Program
    {
        public static int a1;
        public static int a2;
        public static int a3;
        public static int n;
        public static int e;
        static void Main(string[] args)
        {
            a1 = InputNumber("Введите первый элемент последовательности");
            a2 = InputNumber("Введите второй элемент последовательности");
            a3 = InputNumber("Введите третий элемент последовательности");
            n = InputNumber("Введите количество искомых элементов", 1);
            e = InputNumber("Введите число, которое должно быть меньше разности искомых элементов с предыдущими",0);
            long[] all = new long[2];
            all[0] = a1;
            all[1] = a2;
            long[] search = new long[n];
            int[] num = new int[n];
            all = Findall(all, search, num, out search, out num);
            Print(all, search, num);
            Console.ReadKey();
        }

        static public int InputNumber(string ForUser, int left = int.MinValue, int right = int.MaxValue)
        {
            bool ok = true;
            int number = 0;
            do
            {
                Console.WriteLine(ForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number <= right) ok = false;
                    else
                    {
                        Console.WriteLine("Введите число от {0} до {1}!", left, right);
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный ввод числа!");
                }
            } while (ok);
            return number;
        }
        public static long Rekursia(int k)
        {
            switch (k)
            {
                case 1: return a1;
                case 2: return a2;
                case 3: return a3;
                default: return (Rekursia(k - 1) + 2 * Rekursia(k - 2) * Rekursia(k - 3));
            }            
        }
        public static long[] Findall(long[] all, long[] search, int[] num, out long[] elements, out int[] numbers)
        {
            int n_temp = n;
            int pos = 0;
            for (int i = 2; n_temp != 0; i++)
            {
                if (i > 2)
                {
                    long[] temp = new long[all.Length + 1];
                    all.CopyTo(temp, 0);
                    all = new long[temp.Length];
                    temp.CopyTo(all, 0);
                }
                all[i - 1] = Rekursia(i);
                if (Math.Abs(Rekursia(i) - Rekursia(i - 1)) > e)
                {
                    search[pos] = Rekursia(i);
                    num[pos] = i;
                    pos++;
                    n_temp--;
                }
            }
            elements = new long[search.Length];
            search.CopyTo(elements, 0);
            numbers = new int[num.Length];
            num.CopyTo(numbers, 0);
            return all;
        }
        public static void Print(long[] allElements, long[] search, int[] num)
        {
            Console.WriteLine("\nВсе элементы: ");
            foreach (long x in allElements) Console.Write(x + " ");
            Console.WriteLine("\nИскомые элементы: ");
            foreach (long x in search) Console.Write(x + " ");
            Console.WriteLine("\nНомера искомых элементов: ");
            foreach (int x in num) Console.Write(x + " ");
        }
    }
}
