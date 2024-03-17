using Microsoft.VisualBasic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Lesson_008_Bufferization
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            /*SearchFile(args[0], args[1]);
            foreach (string arg in list)
            {
                Console.WriteLine(arg);
            }*/
            HW(@"E:\LessonsGB");

        }
        static List<string> listHW = new List<string>();
        public static void HW(string path)
        {
            listHW.AddRange(Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories));
            List<string> tempList = new List<string>();
            foreach (string file in listHW)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    while (!sr.EndOfStream)
                    {
                        var tempString = sr.ReadToEnd();
                        if (tempString.Contains("Тест"))
                        {
                            tempList.Add(file);
                        }
                    }
                }
            }
            foreach (var item in tempList)
            {
                Console.WriteLine(item);
            }
        }

        public static void Task1(string[] args)
        {
            /*Задача 1
            Напишите консольную утилиту для копирования файлов 
            Пример запуска: utility.exe file1.txt file2.txt*/
            if (args.Length < 2)
            {
                Console.WriteLine("Нет параметров запуска");
            }
            else
            {
                if (!File.Exists(args[0]))
                {
                    using (StreamWriter sw = new StreamWriter(args[0]))
                    {
                        sw.WriteLine("Сгенерированная строка");
                    }
                }
                using (StreamWriter sw = new StreamWriter(args[1]))
                {
                    using (StreamReader sr = new StreamReader(args[0]))
                    {
                        sw.Write(sr.ReadToEnd());
                    }
                }
            }
        }
        /*Задача 2
          Напишите утилиту рекурсивного поиска файлов в заданном каталоге и подкаталогах
          Пример запуска: utility.exe c:\t file1.txt*/
        static List<string> list = new List<string>();
        public static void SearchFile(string path, string nameFile)
        {
            list.AddRange(Directory.GetFiles(path, nameFile, SearchOption.AllDirectories));
            /*var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (Path.GetFileName(file) == nameFile)
                {
                    list.Add(file);
                }
            }
            foreach (var dir in Directory.GetDirectories(path))
            {
                SearchFile(dir, nameFile);
            }*/
        }
        public static void Task3(string[] args)
        {
            /*Задача 3
             * Напишите утилиту читающую тестовый файл и выводящую на экран строки содержащие искомое слово.
             * Пример запуска: utility.exe c:\file1.txt слово*/
            using (StreamReader sr = new StreamReader(args[0]))
            {
                while (!sr.EndOfStream)
                {
                    var tempString = sr.ReadLine();
                    if (tempString.Contains(args[1]))
                    {
                        Console.WriteLine(tempString);
                    }
                }
            }
        }
    }

}
