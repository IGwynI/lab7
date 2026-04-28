using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            FileTasks.FillFileWithNumbersOnePerLine("Привет Андрей/Как дела?/тебе 2", 5, 0, 10);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}\n");
        }
        
        
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

            Console.WriteLine("\nТип int:");
            List<int> intList = CollectionTasks.GenerateRandomIntList(8, 1, 5);
            Console.Write("Исходный список: ");
            CollectionTasks.PrintList(intList);
            int intValue = 3;
            CollectionTasks.RemoveAllFromList(intList, intValue);
            Console.Write($"После удаления {intValue}: ");
            CollectionTasks.PrintList(intList);

            Console.WriteLine("\nТип double:");
            List<double> doubleList = new List<double> { 2.5, 3.0, 1.22, 3.1, 4.7, 3.0, 1.22, 2.5 };
            Console.Write("Исходный список: ");
            CollectionTasks.PrintList(doubleList);
            double doubleValue = 1.22;
            CollectionTasks.RemoveAllFromList(doubleList, doubleValue);
            Console.Write($"После удаления {doubleValue}: ");
            CollectionTasks.PrintList(doubleList);

            Console.WriteLine("\nТип char:");
            List<char> charList = CollectionTasks.GenerateRandomCharList(8, 'a', 'e');
            Console.Write("Исходный список: ");
            CollectionTasks.PrintList(charList);
            char charValue = 'c';
            CollectionTasks.RemoveAllFromList(charList, charValue);
            Console.Write($"После удаления '{charValue}': ");
            CollectionTasks.PrintList(charList);

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

            Console.WriteLine("\nТип int:");
            LinkedList<int> intLL = CollectionTasks.GenerateRandomIntLinkedList(10, 1, 3);
            Console.Write("Исходный список: ");
            CollectionTasks.PrintLinkedList(intLL);
            int eInt = 2;
            CollectionTasks.ReverseBetweenInLinkedList(intLL, eInt);
            Console.Write($"После переворота между первым и последним '{eInt}': ");
            CollectionTasks.PrintLinkedList(intLL);

            Console.WriteLine("\nТип double:");
            LinkedList<double> doubleLL = new LinkedList<double>(new[] { 2.89, 1.5, 3.0, 2.0, 4.0, 2.89, 5.0 });
            Console.Write("Исходный список: ");
            CollectionTasks.PrintLinkedList(doubleLL);
            double eDouble = 2.89;
            CollectionTasks.ReverseBetweenInLinkedList(doubleLL, eDouble);
            Console.Write($"После переворота между первым и последним '{eDouble}': ");
            CollectionTasks.PrintLinkedList(doubleLL);

            Console.WriteLine("\nТип char:");
            LinkedList<char> charLL = CollectionTasks.GenerateRandomCharLinkedList(10, 'a', 'c');
            Console.Write("Исходный список: ");
            CollectionTasks.PrintLinkedList(charLL);
            char eChar = 'b';
            CollectionTasks.ReverseBetweenInLinkedList(charLL, eChar);
            Console.Write($"После переворота между первым и последним '{eChar}': ");
            CollectionTasks.PrintLinkedList(charLL);

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