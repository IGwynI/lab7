using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        /// <summary>
        /// ---------- Задание 1 ----------
        /// </summary>
        try
        {
            Console.WriteLine("--- Задание 1 ---");
            string file1 = CheckInput.ReadFilePath("Введите путь для файла с числами: ");
            int count1 = CheckInput.ReadPositiveInt("Введите количество чисел: ");
            int min1 = CheckInput.ReadInt("Введите минимальное значение: ");
            int max1 = CheckInput.ReadInt("Введите максимальное значение: ");
            FileTasks.FillFileWithNumbersOnePerLine(file1, count1, min1, max1);
            int b = CheckInput.ReadInt("Введите число b для поиска: ");
            bool contains = FileTasks.ContainsNumber(file1, b);
            Console.WriteLine($"Число {b} {(contains ? "найдено" : "не найдено")} в файле.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 2 ----------
        /// </summary>
        try
        {
            Console.WriteLine("--- Задание 2 ---");
            string file2 = CheckInput.ReadFilePath("Введите путь для файла с числами: ");
            int numsPerLine = CheckInput.ReadPositiveInt("Введите количество чисел в строке: ");
            int lines = CheckInput.ReadPositiveInt("Введите количество строк: ");
            int min2 = CheckInput.ReadInt("Введите минимальное значение: ");
            int max2 = CheckInput.ReadInt("Введите максимальное значение: ");
            FileTasks.FillFileWithNumbersMultiplePerLine(file2, numsPerLine, lines, min2, max2);
            int k = CheckInput.ReadInt("Введите число k (делитель): ");
            while (k == 0)
            {
                Console.WriteLine("k не может быть 0.");
                k = CheckInput.ReadInt("Введите число k (делитель): ");
            }
            int sum = FileTasks.SumMultiplesOfK(file2, k);
            Console.WriteLine($"Сумма чисел, кратных {k}, равна {sum}.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 3 ----------
        /// </summary>
        try
        {
            Console.WriteLine("--- Задание 3 ---");
            string source3 = CheckInput.ReadFilePath("Введите путь к исходному текстовому файлу: ");
            string dest3 = CheckInput.ReadFilePath("Введите путь к целевому файлу: ");
            FileTasks.CopyLinesWithoutDigits(source3, dest3);
            Console.WriteLine("Строки без цифр скопированы.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 4 ----------
        /// </summary>
        try
        {
            Console.WriteLine("--- Задание 4 ---");
            string binSource = CheckInput.ReadFilePath("Введите путь к исходному бинарному файлу: ");
            int count4 = CheckInput.ReadPositiveInt("Введите количество чисел: ");
            int min4 = CheckInput.ReadInt("Введите минимальное значение: ");
            int max4 = CheckInput.ReadInt("Введите максимальное значение: ");
            FileTasks.FillBinaryFileWithInts(binSource, count4, min4, max4);
            string binDest = CheckInput.ReadFilePath("Введите путь для файла без дубликатов: ");
            FileTasks.RemoveDuplicatesFromBinaryFile(binSource, binDest);
            Console.WriteLine("Файл без повторных вхождений создан.");
            Console.WriteLine("Исходный бинарный файл:");
            FileTasks.PrintBinaryFileInts(binSource);
            Console.WriteLine("Файл без дубликатов:");
            FileTasks.PrintBinaryFileInts(binDest);
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 5 ----------
        /// </summary>
        try
        {
            Console.WriteLine("--- Задание 5 ---");
            string xmlFile = CheckInput.ReadFilePath("Введите путь к файлу с игрушками: ");
            int toyCount = CheckInput.ReadPositiveInt("Введите количество игрушек: ");
            FileTasks.FillToysBinaryFile(xmlFile, toyCount);
            int maxPrice = CheckInput.ReadNonNegativeInt("Введите максимальную цену k (руб.): ");
            FileTasks.PrintSuitableToysFromBinary(xmlFile, maxPrice);
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 6 ----------
        /// </summary>
        try
        {
            Console.WriteLine("--- Задание 6 ---");
            int listCount = CheckInput.ReadPositiveInt("Введите количество элементов списка: ");
            int min6 = CheckInput.ReadInt("Введите минимальное значение: ");
            int max6 = CheckInput.ReadInt("Введите максимальное значение: ");
            List<int> list6 = CollectionTasks.GenerateRandomList(listCount, min6, max6);
            Console.Write("Исходный список: ");
            CollectionTasks.PrintList(list6);
            int valueToRemove = CheckInput.ReadInt("Введите значение для удаления: ");
            CollectionTasks.RemoveAllFromList(list6, valueToRemove);
            Console.Write("Список после удаления: ");
            CollectionTasks.PrintList(list6);
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 7 ----------
        /// </summary>
        try
        {
            Console.WriteLine("\n--- Задание 7 ---");
            int list7Count = CheckInput.ReadPositiveInt("Введите количество элементов LinkedList: ");
            int min7 = CheckInput.ReadInt("Введите минимальное значение: ");
            int max7 = CheckInput.ReadInt("Введите максимальное значение: ");
            LinkedList<int> linkedList = CollectionTasks.GenerateRandomLinkedList(list7Count, min7, max7);
            Console.Write("Исходный список: ");
            CollectionTasks.PrintLinkedList(linkedList);
            int e = CheckInput.ReadInt("Введите элемент E: ");
            CollectionTasks.ReverseBetweenInLinkedList(linkedList, e);
            Console.Write("Список после переворота между первым и последним вхождением E: ");
            CollectionTasks.PrintLinkedList(linkedList);
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 8 ----------
        /// </summary>
        try
        {
            Console.WriteLine("\n--- Задание 8 ---");
            int viewersCount = CheckInput.ReadPositiveInt("Введите количество зрителей: ");
            int filmsCount = CheckInput.ReadPositiveInt("Введите количество фильмов: ");

            CollectionTasks.GenerateFilmData(viewersCount, filmsCount, out string[] films, out HashSet<string>[] viewers);
            for (int v = 0; v < viewersCount; v++)
            {
                Console.WriteLine($"Зритель {v + 1} посмотрел: {string.Join(", ", viewers[v])}");
            }
            CollectionTasks.AnalyzeFilmViewers(films, viewers);
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 9 ----------
        /// </summary>
        try
        {
            Console.WriteLine("\n--- Задание 9 ---");
            string textFile9 = CheckInput.ReadFilePath("Введите путь к текстовому файлу: ");
            CollectionTasks.PrintVoicedConsonantsFromFile(textFile9);
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        /// <summary>
        /// ---------- Задание 10 ----------
        /// </summary>
        try
        {
            Console.WriteLine("\n--- Задание 10 ---");
            string employeesFile = CheckInput.ReadFilePath("Введите путь к файлу с данными о сотрудниках: ");
            double avg = CollectionTasks.AverageEmployeesPerDepartment(employeesFile);
            Console.WriteLine($"Среднее количество сотрудников в одном подразделении: {avg:F2}");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
    }
}