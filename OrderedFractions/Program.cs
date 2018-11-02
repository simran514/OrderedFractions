using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedFractions
{
	class Program
	{
		static void Main(string[] args)
		{

			int x = LCM(5, 8);
			int d = 1000000;
			List<int> temp = new List<int>();

			//populate list with all the d's
			for (int i = 0; i < d; i++)
			{
				temp.Add(i + 1);
			}
			
			//find the lcm
			x = LCM(1, 2);
			for (int i = 2; i < temp.Count; i++)
			{
				x = LCM(x, temp[i]);
			}

			int y = 0;
			int val = 3 * (x / 7);
			for (int i = val-1; i > 0; i--)
			{
				
				foreach (int n in temp)
				{
					if ((i * 10) % (n * 10) != 0)
						y++;

					
				}

				if (y == 1)
					Console.WriteLine("here!");

				y = 0;
			}












			List<Fraction> tmp = OrderedFractions(20);
			Fraction[] results = new Fraction[tmp.Count];

			


			for (int i = 0; i < tmp.Count; i++)
			{
				results[i] = tmp[i];
			}
			/*
			 * 
			 * lcm(a, b, c, d) = lcm(a, lcm(b, lcm(c, d)))
			 * 
			 */

			

			Array.Sort(results, Fraction.CompareBySize);

			Console.WriteLine();

			for (int i = 0; i < results.Length; i++)
			{
				if (results[i].n == 3 && results[i].d == 7)
					Console.WriteLine(results[i - 1].n + "/" + results[i - 1].d);
			}



			Console.ReadKey();
		}

		static bool IsPrime(int n)
		{

		}

		static int GCD(int a, int b)
		{
			if (b == 0)
				return a;
			else
				return GCD(b, a % b);
		}

		static int LCM(int a, int b)
		{

			return Math.Abs(a * b) / GCD(a, b);


			return 0;
		}

		static List<Fraction> OrderedFractions(int dMax)
		{
			List<Fraction> tmp = new List<Fraction>();


			for (int d = 2; d <= dMax; d++)
			{
				for (int n = 1; n < d; n++)
				{
					if (n == 3 && d == 7)
						Console.WriteLine();
					if (HighestCommonFactor(n, d) == 1)
					{
						tmp.Add(new Fraction(n, d));
					}

				}
			}

			return tmp;
		}

		//Works
		static bool IsProperFraction(Fraction f)
		{
			double n = f.n;
			double d = f.d;

			if (n < d && HighestCommonFactor(n, d) == 1)
				return true;

			return false;
		}

		//Works
		static int HighestCommonFactor(double a, double b)
		{
			int tmp = 0;

			double tmpA = 0;
			double tmpB = 0;

			for (int i = 1; i <= a; i++)
			{
				tmpA = a % (i + 1);
				tmpB = b % (i + 1);
				if (a % (i + 1) == 0 && b % (i + 1) == 0)
					return 0;

				if (a % i == 0 && b % i == 0)
					tmp = i;
			}

			return tmp;
		}
	}

	public class Fraction
	{
		public double n;
		public double d;

		public Fraction(double n, double d)
		{
			this.n = n;
			this.d = d;
		}

		public static int CompareBySize(Fraction a, Fraction b)
		{
			double fracA = a.n / a.d;
			double fracB = b.n / b.d;

			return fracA.CompareTo(fracB);
		}
	}
}
