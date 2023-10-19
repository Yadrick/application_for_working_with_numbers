using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace application_for_working_with_numbers
{
    class Program
    {
        static string INITIAL_WORDS = "Програма ищет уникальные числа, остаток от деления на 4 у которых равняется 3.\n" +
            "Получившийся набор будет отсортирован в порядке убывания\nи сохранен в файл result.txt, " +
            "в каталоге с рассматриваемыми текстовыми файлами.\n";
        static void Main(string[] args)
        {
            
            Console.WriteLine(INITIAL_WORDS);


            string folder_path = Getting_folder_path();
            //Если необходимо сгенерировать n-е количество файлов с рандомным числом строк в пределах 100-1000, 
            //где числа принимают значения от 1 до 1000, то следует раскомментировать строку ниже с методом Autofill_file_numbers.
            //Autofill_file_numbers(folder_path);

            List<string> list_directories = Getting_all_file_path(folder_path);
            List<int>  list_numbers = Reading_files(list_directories);

            Console.WriteLine();
            Console.WriteLine($"Всего чисел в файлах: {list_numbers.Count}");

            var uniqueElements = list_numbers.Distinct().ToList();
            Console.WriteLine($"Количество уникальных чисел: {uniqueElements.Count}");

            List<int> final_list = new List<int>();

            foreach (var item in uniqueElements)
            {
                if (item % 4 == 3)
                {
                    final_list.Add(item);                }
            }

            final_list.Sort();
            final_list.Reverse();

            Console.WriteLine($"Количество подходящих чисел по условию: {final_list.Count}");

            Saving_results(folder_path, final_list);
            
        }

        public static string Getting_folder_path()
        {
            Console.WriteLine("Введите путь к каталогу, в котором нахоодятся текстовые файлы для анализа: ");
            string folderPath = Console.ReadLine();

            return folderPath;
        }


        public static List<string> Getting_all_file_path(string folderPath)
        {

            string fileExtension = ".txt";

            List<string> directory_text_Files = new List<string>();

            if (Directory.Exists(folderPath))
            {
                directory_text_Files = Directory.GetFiles(folderPath, $"*{fileExtension}").Where(file => file.ToLower().EndsWith(fileExtension)).ToList();
            }
            else
            {
                Console.WriteLine("Указанная папка не существует.");
            }

            return directory_text_Files;
        }


        public static List<int> Reading_files(List<string> directory_text_Files)
        {
            
            List<int> list_numbers_from_files = new List<int>();
            string line;

            foreach (string file_directory in directory_text_Files)
            {
                try
                {

                    StreamReader sr = new StreamReader($"{file_directory}");
                    line = sr.ReadLine();

                    while (line != null)
                    {
                        if (int.TryParse(line, out int number))
                        {
                            list_numbers_from_files.Add(number);
                        }
                        
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
            }
            return list_numbers_from_files;
        }


        public static void Autofill_file_numbers(string path)
        {
            try
            {
                Console.WriteLine("Какое количество файлов с числами вы хотите сосздать?");
                string count_files_string = Console.ReadLine();
                int count_files = 0;

                while (true)
                {
                    if (int.TryParse(count_files_string, out int number))
                    {
                        count_files = number;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Вы ввели не число, попробуйте снова.");
                    }
                }

                

                for (int i = 0; i < count_files; i++)
                {
                    StreamWriter sw = new StreamWriter($"{path}\\testing_data{i}.txt");
                    Random rnd = new Random();


                    int count_line = rnd.Next(100, 1000);
                    int number = 0;

                    for (int j = 0; j < count_line; j++)
                    {
                        number = rnd.Next(1, 1000);
                        sw.WriteLine(number);
                    }
                    sw.Close();
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }


        public static void Saving_results(string path, List<int> final_list)
        {
            try
            {
                StreamWriter sw = new StreamWriter($"{path}\\result.txt");

                foreach (var item in final_list)
                {
                    sw.WriteLine(item);
                }

                sw.Close();
                Console.WriteLine("Получившийся результат сохранен в введенном вами каталоге в файле result.txt.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
