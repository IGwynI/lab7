using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class CollectionTasks
{
    private static readonly Random _random;
    static CollectionTasks()
    {
        _random = new Random();
    }

    /// <summary>
    /// ---------- Задание 6 ----------
    /// </summary>
    public static void RemoveAllFromList<T>(List<T> list, T value)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "Список не может быть null.");
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (EqualityComparer<T>.Default.Equals(list[i], value))
            {
                list.RemoveAt(i);
            }
        }
    }

    public static List<int> GenerateRandomIntList(int count, int minValue, int maxValue)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
        {
            list.Add(_random.Next(minValue, maxValue + 1));
        }
        return list;
    }

    public static List<double> GenerateRandomDoubleList(int count, double minValue, double maxValue)
    {
        List<double> list = new List<double>();
        for (int i = 0; i < count; i++)
        {
            double value = minValue + (_random.NextDouble() * (maxValue - minValue));
            list.Add(value);
        }
        return list;
    }

    public static List<char> GenerateRandomCharList(int count, char minValue, char maxValue)
    {
        List<char> list = new List<char>();
        for (int i = 0; i < count; i++)
        {
            char value = (char)_random.Next(minValue, maxValue + 1);
            list.Add(value);
        }
        return list;
    }

    public static void PrintList<T>(List<T> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Список пуст.");
        }
        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                if (i < list.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// ---------- Задание 7 ----------
    /// </summary>
    public static void ReverseBetweenInLinkedList<T>(LinkedList<T> list, T e)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), "Список не может быть null.");
        }
        if (list.Count < 2)
        {
            return;
        }

        LinkedListNode<T> first = null;
        LinkedListNode<T> last = null;

        LinkedListNode<T> current = list.First;
        bool foundFirst = false;
        while (current != null && !foundFirst)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, e))
            {
                first = current;
                foundFirst = true;
            }
            current = current.Next;
        }

        if (first == null)
        {
            return;
        }

        current = list.Last;
        bool foundLast = false;
        while (current != null && !foundLast)
        {
            if (EqualityComparer<T>.Default.Equals(current.Value, e))
            {
                last = current;
                foundLast = true;
            }
            current = current.Previous;
        }

        if (first != null && last != null && first != last && first.Next != last)
        {
            List<T> temp = new List<T>();
            LinkedListNode<T> node = first.Next;
            while (node != last)
            {
                temp.Add(node.Value);
                node = node.Next;
            }

            node = first.Next;
            for (int i = temp.Count - 1; i >= 0; i--)
            {
                node.Value = temp[i];
                node = node.Next;
            }
        }
    }


    public static LinkedList<int> GenerateRandomIntLinkedList(int count, int minValue, int maxValue)
    {
        LinkedList<int> list = new LinkedList<int>();
        for (int i = 0; i < count; i++)
        {
            list.AddLast(_random.Next(minValue, maxValue + 1));
        }
        return list;
    }

    public static LinkedList<double> GenerateRandomDoubleLinkedList(int count, double minValue, double maxValue)
    {
        LinkedList<double> list = new LinkedList<double>();
        for (int i = 0; i < count; i++)
        {
            double value = minValue + (_random.NextDouble() * (maxValue - minValue));
            list.AddLast(value);
        }
        return list;
    }

    public static LinkedList<char> GenerateRandomCharLinkedList(int count, char minValue, char maxValue)
    {
        LinkedList<char> list = new LinkedList<char>();
        for (int i = 0; i < count; i++)
        {
            char value = (char)_random.Next(minValue, maxValue + 1);
            list.AddLast(value);
        }
        return list;
    }

    public static void PrintLinkedList<T>(LinkedList<T> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Список пуст.");
        }
        else
        {
            LinkedListNode<T> current = list.First;
            bool first = true;
            while (current != null)
            {
                if (!first)
                {
                    Console.Write(", ");
                }
                Console.Write(current.Value);
                first = false;
                current = current.Next;
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// ---------- Задание 8 ----------
    /// </summary>
    public static void AnalyzeFilmViewers(string[] films, HashSet<string>[] viewers)
    {
        if (films == null || viewers == null)
        {
            throw new ArgumentNullException("Массивы не могут быть null.");
        }

        HashSet<string> allFilms = new HashSet<string>();
        for (int i = 0; i < films.Length; i++)
        {
            allFilms.Add(films[i]);
        }

        if (viewers.Length == 0)
        {
            Console.WriteLine("Результаты анализа просмотров фильмов:");
            Console.WriteLine("Все посмотрели: (нет)");
            Console.WriteLine("Некоторые посмотрели: (нет)");
            Console.Write("Никто не посмотрел: ");
            PrintSet(allFilms);
            return;
        }

        HashSet<string> allWatchedSet = new HashSet<string>(viewers[0]);
        HashSet<string> anyWatchedSet = new HashSet<string>(viewers[0]);

        for (int v = 1; v < viewers.Length; v++)
        {
            allWatchedSet.IntersectWith(viewers[v]);
            anyWatchedSet.UnionWith(viewers[v]);
        }

        HashSet<string> noneWatchedSet = new HashSet<string>(allFilms);
        noneWatchedSet.ExceptWith(anyWatchedSet);

        HashSet<string> someWatchedSet = new HashSet<string>(anyWatchedSet);
        someWatchedSet.ExceptWith(allWatchedSet);

        Console.WriteLine("Результаты анализа просмотров фильмов:");
        Console.Write("Все посмотрели: ");
        PrintSet(allWatchedSet);
        Console.Write("Некоторые посмотрели: ");
        PrintSet(someWatchedSet);
        Console.Write("Никто не посмотрел: ");
        PrintSet(noneWatchedSet);
    }

    private static void PrintSet(HashSet<string> set)
    {
        if (set.Count == 0)
        {
            Console.WriteLine("(нет)");
            return;
        }
        List<string> list = new List<string>();
        foreach (string item in set)
        {
            list.Add(item);
        }

        for (int i = 0; i < list.Count - 1; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (string.Compare(list[i], list[j]) > 0)
                {
                    string temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
        Console.WriteLine(string.Join(", ", list));
    }

    public static void GenerateFilmData(int viewersCount, int filmsCount, 
        out string[] films, out HashSet<string>[] viewers)
    {
        films = new string[filmsCount];
        for (int i = 0; i < filmsCount; i++)
        {
            films[i] = "Фильм " + (i + 1);
        }

        viewers = new HashSet<string>[viewersCount];
        Random gen = new Random();
        int watchedCount;
        for (int v = 0; v < viewersCount; v++)
        {
            viewers[v] = new HashSet<string>();
            watchedCount = gen.Next(1, filmsCount + 1);
            for (int w = 0; w < watchedCount; w++)
            {
                string film = films[gen.Next(filmsCount)];
                viewers[v].Add(film);
            }
        }
    }

    /// <summary>
    /// ---------- Задание 9 ----------
    /// </summary>
    public static void PrintVoicedConsonantsFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Файл не найден.", filePath);
        }

        HashSet<char> voiced = new HashSet<char> 
        {
            'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'л', 'м', 'н', 'р'
        };


        HashSet<char> seenOnce = new HashSet<char>();

        HashSet<char> seenMultiple = new HashSet<char>();

        string word;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = SplitIntoWords(line);
                for (int w = 0; w < words.Length; w++)
                {
                    word = words[w].ToLower();
                    HashSet<char> wordLetters = new HashSet<char>();
                    for (int i = 0; i < word.Length; i++)
                    {
                        char c = word[i];
                        if (voiced.Contains(c))
                        {
                            wordLetters.Add(c);
                        }
                    }

                    foreach (char c in wordLetters)
                    {
                        if (seenOnce.Contains(c))
                        {
                            seenOnce.Remove(c);
                            seenMultiple.Add(c);
                        }
                        else if (!seenMultiple.Contains(c))
                        {
                            seenOnce.Add(c);
                        }
                    }
                }
            }
        }

        List<char> result = new List<char>();
        foreach (char c in seenMultiple)
        {
            result.Add(c);
        }

        for (int i = 0; i < result.Count - 1; i++)
        {
            for (int j = i + 1; j < result.Count; j++)
            {
                if (result[i] > result[j])
                {
                    char temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }

        Console.WriteLine("Звонкие согласные, входящие более чем в одно слово:");
        if (result.Count == 0)
        {
            Console.WriteLine("Таких букв не найдено.");
        }
        else
        {
            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i]);
                if (i < result.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }

    private static string[] SplitIntoWords(string line)
    {
        List<string> words = new List<string>();
        string currentWord = "";
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (char.IsLetter(c))
            {
                currentWord += c;
            }
            else
            {
                if (currentWord.Length > 0)
                {
                    words.Add(currentWord);
                    currentWord = "";
                }
            }
        }
        if (currentWord.Length > 0)
        {
            words.Add(currentWord);
        }

        string[] result = new string[words.Count];
        for (int i = 0; i < words.Count; i++)
        {
            result[i] = words[i];
        }
        return result;
    }

    /// <summary>
    /// ---------- Задание 10 ----------
    /// </summary>
    public static double AverageEmployeesPerDepartment(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл не найден.", filePath);

        Dictionary<string, int> departmentCount = new Dictionary<string, int>();

        int totalEmployeesExpected = 0;
        int lineNumber = 0;
        int processedEmployees = 0;

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lineNumber++;
                bool skipLine = false;

                if (lineNumber == 1)
                {
                    if (!int.TryParse(line.Trim(), out totalEmployeesExpected)
                        || totalEmployeesExpected < 0)
                    {
                        throw new FormatException
                            ("Первая строка должна содержать" +
                            " неотрицательное целое число.");
                    }
                    skipLine = true;
                }
                else if (string.IsNullOrWhiteSpace(line))
                {
                    skipLine = true;
                }

                if (!skipLine)
                {
                    int lastSpaceIndex = line.LastIndexOf(' ');
                    if (lastSpaceIndex <= 0)
                    {
                        throw new FormatException
                            ($"Строка {lineNumber} имеет неверный формат: {line}");
                    }

                    string phone = line.Substring(lastSpaceIndex + 1).Trim();
                    string phoneDigits = phone.Replace("-", "");
                    if (phoneDigits.Length != 7)
                    {
                        throw new FormatException
                            ($"Некорректный номер телефона" +
                            $" в строке {lineNumber}: {phone}");
                    }

                    string departmentCode = phoneDigits.Substring(0, 5);

                    if (departmentCount.ContainsKey(departmentCode))
                    {
                        departmentCount[departmentCode] = 
                            departmentCount[departmentCode] + 1;
                    }
                    else
                    {
                        departmentCount[departmentCode] = 1;
                    }

                    processedEmployees++;
                }
            }
        }

        if (processedEmployees != totalEmployeesExpected)
        {
            throw new InvalidDataException
                ($"Количество обработанных сотрудников ({processedEmployees}) " +
                $"не совпадает с заявленным в файле ({totalEmployeesExpected}).");
        }

        if (departmentCount.Count == 0)
        {
            return 0;
        }

        int totalEmployeesSum = 0;
        foreach (int count in departmentCount.Values)
        {
            totalEmployeesSum += count;
        }

        return (double)totalEmployeesSum / departmentCount.Count;
    }
}