using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShamirConsole
{
    class Program
    {
        static public  string text = "DOS";
        static public long p = 23;


        static void Main(string[] args)
        {
            Console.WriteLine("=====================================================================================================================");
            A_Abonent.PrintLog($"Исходное сообщение: {text}", true);

            A_Abonent.PrintLog($"Введите Ea, что-бы НОД(Еа, {p - 1}) = 1", true);
            A_Abonent.SetP(p);//Передаем p абоненту А
            A_Abonent.SetE();//Вводим Еа у абонента А
            A_Abonent.SetD();//Формируем D абонента А


            B_Abonent.PrintLog($"Введите Eb, что-бы НОД(Еb, {p - 1}) = 1", true);
            B_Abonent.SetP(p);//Передаем p абоненту В
            B_Abonent.SetE();//Вводим Еа у абонента В
            B_Abonent.SetD();//Формируем D абонента В


            A_Abonent.PrintE();//Выводим закрытый ключ абонента А
            B_Abonent.PrintE();//Выводим закрытый ключ абонента В


            A_Abonent.TextToNumberEncrypt(text);//Текст в числовом представлении
            A_Abonent.PrintNumberEncrypt();//Вывод текста  в числ. представлении  


            long[]C1 = A_Abonent.FirstStepE(A_Abonent.GetNumberEncrypt());////////////////////////////////////////////////////////////////////////
            //C1 = new long[] { 1, 2, 3, 5 };
            A_Abonent.PrintLog("Текст в числовом представлении C1: " + Shamir.NumberEncryptToString(C1), true);
            A_Abonent.PrintLog("Текст в символьном представлении С1: " + Shamir.NumberEncryptToTextWithSpace(C1), true);

            long[] C2 = B_Abonent.FirstStepE(C1);
            B_Abonent.PrintLog("Текст в числовом представлении C2: " + Shamir.NumberEncryptToString(C2), true);
            B_Abonent.PrintLog("Текст в символьном представлении С2: " + Shamir.NumberEncryptToTextWithSpace(C2), true);

            long[] C3 = A_Abonent.SecondStepD(C2);
            A_Abonent.PrintLog("Текст в числовом представлении C3: " + Shamir.NumberEncryptToString(C3), true);
            A_Abonent.PrintLog("Текст в символьном представлении С3: " + Shamir.NumberEncryptToTextWithSpace(C3), true);
            
            long[] C4 = B_Abonent.SecondStepD(C3);
            B_Abonent.PrintLog("Текст в числовом представлении C4: " + Shamir.NumberEncryptToString(C4), true);
            B_Abonent.PrintLog("Текст в символьном представлении С4: " + Shamir.NumberEncryptToTextWithSpace(C4), true);

            B_Abonent.PrintLog($"Полученное сообщение: {Shamir.NumberEncryptToText(C4)}", true);
            Console.WriteLine("=====================================================================================================================");

        }
    }
}
