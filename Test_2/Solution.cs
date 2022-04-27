using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SimpleCode
{
    class Solution
    {
        Dictionary<string, string> noVisit = new Dictionary<string, string>();// создаем словарь, куда будем заносить запрещенные хосты

        /// Фукция GetValue для работы со строками из массиво А и В 
        /// <param name="enter"> строка из массивва</param>
        /// <returns arr> Возвращает подстроку которая либо соответствует хосту который есть в словаре noVisit, либо всю строку enter </returns>
        private string GetValue(string enter)
        {
            string[] mas = enter.Split('.');// делим строку на части и заносим в массив строк
            int a = 0;// счетчик
            int g = mas.Length - 1;//длина массива строк(= количетсву хостов наследников ) 
            string arr = mas[g];// начинать проверку будем с корневого хоста
            while (a < g && !(noVisit.ContainsKey(arr))) // выйдем из цикла если дошли до конца массива, либо если этот хост есть в словаре noVisit
            {
                a += 1;// увеличиваем счётчик
                arr = arr.Insert(0, $"{mas[g - a]}.");// добавляем один хост наследник
            }
            return arr;// возвращем строку которая соотсветсвует условию цикла
        }
        public int[] solution(string[] A, string[] B)
        {
            List<int> otvet = new List<int>();// создаем список, куда будем добавлять номера строк хостов из массива A, которые можно поситить

            foreach (string i in B)// в начале проходимся по массиву запрещенных хостов, чтобы занести их в словарь
            {
                string str = GetValue(i); // получаем строку с именем хоста которая либо равна i, либо строку хоста предка который уже запрещен 
                if (!noVisit.ContainsKey(str))// проверка от колизий
                    noVisit.Add(str, "");// если этот хост (или один из хостов предков) не в словаре, значит мы его еще не запретили, пожтому добавляем его
            }
            for (int i = 0; i < A.Length; i++)// проходимся по массиву хостов которые необходимо проверить
            {
                string str = GetValue(A[i]);// получаем строку с именем хоста которая либо равна i, либо строку хоста предка который уже запрещен   
                if (!noVisit.ContainsKey(str))// тут уже проверка на наличие хоста с именем str, если его нет значит ресурс можно посетить
                    otvet.Add(i);
            }
            return otvet.ToArray();// возвращаем массив номеров строк хостов из массива А которые можно посетить
        }
    }
}