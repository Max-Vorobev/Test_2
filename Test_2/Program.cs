using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimpleCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //считываем массивы А и В из файлов
            string[] enter;
            enter = File.ReadAllLines("1.txt");
            string[] forbiddden;
            forbiddden = File.ReadAllLines("2.txt");

            Solution answer = new Solution(); // создаем объект класса Solution 
            int[] arr = answer.solution(enter, forbiddden); //записываем результат в функции в массив int
            foreach (int g in arr)
            {
                Console.Write($"{g} ");// выводим массив с ответом в одну строчку, через пробел
            }
            Console.ReadLine();
        }
    }
}