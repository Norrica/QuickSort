using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Sort
{
	class Program
	{
		private static void QuickSort(int[] a, int i, int j)
		{
			if (i<j)
			{
				int c = Divide(a, i, j);
				QuickSort(a, i, c - 1);
                QuickSort(a, c, j);
            }
		}
		private static int Divide(int[] a, int i, int j)
		{
			int x = (a[i] + a[j]) / 2;
			while (i<=j)
			{
				while (a[i] < x)
				{
					i++;
				}
				while (a[j] > x)
				{
					j--;
				}
				if (i<=j)
				{
					int tmp = a[i];
					a[i] = a[j];
					a[j] = tmp;
					i++;j--;
				}
			}
			return i;			
		}
		private static void TestThree()
		{
			int[] a = new int[3];
			var rnd = new Random();
			Console.WriteLine("Сортировка массива из 3-х элементов:\nИсходный массив из 3-х элементов:");
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = 3 - i;
				Console.Write(a[i]);
				Console.Write("\t");
			}
			Console.WriteLine("\nРезультат сортировки:");
			QuickSort(a, 0, a.Length-1);
			
			for (int i = 0; i < a.Length; i++)
			{
				Console.Write(a[i]);
				Console.Write("\t");
			}
		}
		private static void TestHundred()
		{
			int[] a = new int[100];
			
			Console.WriteLine("\nСортировка ста одинаковых элементов");
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = 10;				
			}
			Console.WriteLine("Результат сортировки:");
			QuickSort(a, 0, a.Length - 1);

			for (int i = 0; i < a.Length; i++)
			{
				Console.Write(a[i]);
				Console.Write("\t");
			}
		}
		private static void TestThousand()
		{
			int[] a = new int[1000];
			var rnd = new Random();
			Console.WriteLine("\nСотртировка тысячи элементов:");
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = rnd.Next(0,100);
			}
			QuickSort(a, 0, a.Length - 1);
			for (int j = 0; j < a.Length-1; j++)
			{
				if (a[j] > a[j + 1])
				{
					Console.WriteLine("Работает некорректно");
				}
				if (j == a.Length - 2)
				{
					Console.WriteLine("Работает корректно");
				}
			}
			
		}
		private static void TestEmpty()
		{
			Console.WriteLine("Обработка пустого массива");
			int[] a = new int[0];
			var rnd = new Random();			
			QuickSort(a, 0, a.Length - 1);
			Console.WriteLine("Если вы видите данное сообщение, обработка произведена корректно");
		}
		private static void TestHuge()
		{
			int[] a = new int[100000000];//К сожалению, у меня намного меньше 8-ми ГБ оперативной памяти
			var rnd = new Random();
			Console.WriteLine("Сортировка большого массива:");
			for (int i = 0; i < a.Length; i++)
			{
				a[i] = rnd.Next(1,41254);
			}
			Thread.Sleep(1000);
			Console.WriteLine("Работает не так быстро как хотелось бы");
			QuickSort(a, 0, a.Length - 1);
			for (int j = 0; j < a.Length - 1; j++)
			{
				if (a[j] > a[j + 1])
				{
					Console.WriteLine("И работает некорректно");
				}
				if (j == a.Length - 2)
				{
					Console.WriteLine("Но работает корректно");
				}
			}
		}
		static void Main(string[] args)
		{
			TestThree();
			TestHundred();
			TestThousand();
			TestEmpty();
			TestHuge();
			Console.Read();
		}
	}
}

