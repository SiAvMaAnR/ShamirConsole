using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ShamirConsole
{
	static class Shamir
	{
		static private string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		static private int[] numericConversion;
		static private string stringConversion;

		static public void extendedGCD(long a, long b, out long x, out long y, out long d)//Расширенный алгоритм Евклида
		{
			long q, r, x1, x2, y1, y2;


			if (b == 0)
			{
				d = a;
				x = 1;
				y = 0;
				return;
			}
			x2 = 1; y2 = 0;
			x1 = 0; y1 = 1;

			while (b > 0)
			{
				q = a / b; r = a - q * b;
				x = x2 - q * x1; y = y2 - q * y1;
				a = b; b = r;
				x2 = x1; x1 = x; y2 = y1; y1 = y;
			}
			d = a; x = x2; y = y2;
		}

		static public long GCD(long A, long B)//Поиск НОД | Алгоритм Евклида
		{
			while (B != 0)
				(A, B) = (B, A % B);
			return A;
		}

		static public int[] TextToNumberEncrypt(string Text)//Текст в набор чисел
		{
			numericConversion = new int[Text.Length];
			for (int i = 0; i < Text.Length; i++)//Числовой вид сообщения
			{
				for (int j = 0; j < Alphabet.Length; j++)
				{
					if (Text[i] == Alphabet[j])
					{
						numericConversion[i] = j+1; break;
					}
				}
			}
			return numericConversion;
		}

		static public string NumberEncryptToText(int[] NumberEncrypt)//Набор чисел в текст
        {
			stringConversion = "";
            for (int i = 0; i < NumberEncrypt.Length; i++)
            {
				stringConversion += Alphabet[NumberEncrypt[i] - 1];
            }
			return stringConversion;
		}
		
		static public string NumberEncryptToTextWithSpace(int[] NumberEncrypt)//Набор чисел в текст
        {
			stringConversion = "";
            for (int i = 0; i < NumberEncrypt.Length; i++)
            {
				stringConversion += Alphabet[NumberEncrypt[i] - 1] + " ";
            }
			return stringConversion;
		}

		public static BigInteger reSquaring(BigInteger m, BigInteger e, BigInteger n)//c=m^e(mod n)
		{
			BigInteger E = e;

			int i;
			for (i = 1; E != 1; i++)//Проверка количества элементов
				E = E / 2;

			BigInteger[] bynaryN = new BigInteger[i];

			E = e;
			for (int j = 0; j < i; j++)//Степень в бинарном представлении
			{
				bynaryN[j] = E % 2;
				E = E / 2;
			}

			BigInteger b = m % n;
			for (int j = 1; j < i; j++)//Возведение в степень
			{
				b = BigInteger.ModPow(b, 2, n);
				if (bynaryN[j] == 1)
					m = (m * b) % n;
			}
			return m;
		}

		public static string NumberEncryptToString(int[]NE)
        {
			string str = "";
            foreach (var item in NE)
            {
				str += item + " ";
            }
			return str;
        }
	}
}


