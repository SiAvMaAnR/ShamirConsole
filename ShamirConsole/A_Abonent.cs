﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShamirConsole
{
    static class A_Abonent
    {
        static private int[] NumberEncrypt;
        static private int[] FirstNumberEncrypt;
        static private int[] SecondNumberEncrypt;

        static private long E;
        static private long P;
        static private long D;

        static public int[] GetNumberEncrypt()
        {
            return NumberEncrypt;
        }

        static public bool isNormalE(long e)
        {
            if (Shamir.GCD(e, P - 1) == 1)
            {
                E = e;
                return true;
            }
            else return false;
        }

        static public void SetP(long p)
        {
            P = p;
        }

        static public void SetE()
        {
            do
            {
                A_Abonent.PrintLog("Ввод Еa: ", false);
                E = Convert.ToInt64(Console.ReadLine());
            }
            while (!A_Abonent.isNormalE(E));
            //A_Abonent.PrintLog($"E = {E} удовлетворяет условию НОД(Е, Р-1)!", true);
        }

        static public void SetD()
        {
            Shamir.extendedGCD(E, P - 1, out long x, out long y, out long d);
            D = x + (P - 1);
            PrintLog($"D = {D}", true);
        }

        static public void PrintE()
        {
            PrintLog($"Закрытый ключ абонента: E = {E}", true);
        }

        static public void PrintNumberEncrypt()
        {
            PrintLog($"Текст в числовом представлении: ", false);
            foreach (var item in NumberEncrypt)
                Console.Write($"{item} ");
            Console.WriteLine();
        }

        static public void TextToNumberEncrypt(string Text)
        {
            NumberEncrypt = Shamir.TextToNumberEncrypt(Text);
        }

        static public void PrintLog(string str, bool endl)
        {
            if (endl)
                Console.WriteLine("| Абонент A | " + str);
            else
                Console.Write("| Абонент A | " + str);
        }

        static public int[] FirstStepE(int[] C)
        {
            FirstNumberEncrypt = new int[C.Length];
            for (int i = 0; i < C.Length; i++)
            {
                FirstNumberEncrypt[i] = (int)Shamir.reSquaring(C[i], E, P);//c=m^e(mod n)
            }
            return FirstNumberEncrypt;
        }

        static public int[] SecondStepD(int[] C)
        {
            SecondNumberEncrypt = new int[C.Length];
            for (int i = 0; i < C.Length; i++)
            {
                SecondNumberEncrypt[i] = (int)Shamir.reSquaring(C[i], D, P);//c=m^e(mod n)
            }
            return SecondNumberEncrypt;
        }
    }
}
