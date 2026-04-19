using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class CollectionTasks
{
    private static readonly Random _random = new Random();

    /// <summary>
    /// ---------- Задание 6 ----------
    /// </summary>
    public static void RemoveAllFromList(List<int> list, int value)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list),
                "Список не может быть null.");
        }

        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == value)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static List<int> GenerateRandomList(int count, int minValue, int maxValue)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < count; i++)
        {
            list.Add(_random.Next(minValue, maxValue + 1));
        }
        return list;
    }


    public static void PrintList(List<int> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }
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

    /// <summary>
    /// ---------- Задание 7 ----------
    /// </summary>
    public static void ReverseBetweenInLinkedList(LinkedList<int> list, int e)
    {
        if (list == null)
        {
            throw new ArgumentNullException(nameof(list), 
                "Список не может быть null.");
        }
        if (list.Count < 2)
        {
            return;
        }

        LinkedListNode<int> first = null;
        LinkedListNode<int> last = null;

        LinkedListNode<int> current = list.First;
        bool foundFirst = false;
        while (current != null && !foundFirst)
        {
            if (current.Value == e)
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
            if (current.Value == e)
            {
                last = current;
                foundLast = true;
            }
            current = current.Previous;
        }

        if (first != null && last != null && first != last && first.Next != last)
        {
            List<int> temp = new List<int>();
            LinkedListNode<int> node = first.Next;
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

    public static LinkedList<int> GenerateRandomLinkedList(int count, int minValue, int maxValue)
    {
        LinkedList<int> list = new LinkedList<int>();
        for (int i = 0; i < count; i++)
        {
            list.AddLast(_random.Next(minValue, maxValue + 1));
        }
        return list;
    }

    public static void PrintLinkedList(LinkedList<int> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }
        LinkedListNode<int> current = list.First;
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

    /// <summary>
    /// ---------- Задание 8 ----------
    /// </summary>
    public static void AnalyzeFilmViewers(string[] films, HashSet<string>[] viewers)
    {
        if (films == null || viewers == null)
        {
            throw new ArgumentNullException("Массивы не могут быть null.");
        }

        int n = viewers.Length;
        Console.WriteLine("Результаты анализа просмотров фильмов:");
        for (int f = 0; f < films.Length; f++)
        {
            string film = films[f];
            int count = 0;
            for (int v = 0; v < n; v++)
            {
                if (viewers[v].Contains(film))
                {
                    count++;
                }
            }

            string category;
            if (count == n)
            {
                category = "посмотрели все";
            }
            else if (count == 0)
            {
                category = "никто не посмотрел";
            }
            else
            {
                category = "посмотрели некоторые";
            }

            Console.WriteLine($"- {film}: {category} ({count} из {n})");
        }
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
        for (int v = 0; v < viewersCount; v++)
        {
            viewers[v] = new HashSet<string>();
            int watchedCount = gen.Next(1, filmsCount + 1);
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

        Dictionary<char, int> letterCount = new Dictionary<char, int>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] words = SplitIntoWords(line);
                for (int w = 0; w < words.Length; w++)
                {
                    string word = words[w].ToLower();
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
                        if (letterCount.ContainsKey(c))
                        {
                            letterCount[c] = letterCount[c] + 1;
                        }
                        else
                        {
                            letterCount[c] = 1;
                        }
                    }
                }
            }
        }

        List<char> result = new List<char>();
        foreach (KeyValuePair<char, int> pair in letterCount)
        {
            if (pair.Value > 1)
            {
                result.Add(pair.Key);
            }
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
        {
            throw new FileNotFoundException("Файл не найден.", filePath);
        }

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
                if (lineNumber == 1)
                {
                    if (!int.TryParse(line.Trim(), out totalEmployeesExpected) ||
                        totalEmployeesExpected < 0)
                    {
                        throw new FormatException("Первая строка должна содержать " +
                            "неотрицательное целое число (количество сотрудников).");
                    }
                    continue;
                }

                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                int lastSpaceIndex = line.LastIndexOf(' ');
                if (lastSpaceIndex <= 0)
                {
                    throw new FormatException($"Строка {lineNumber} " +
                        $"имеет неверный формат: {line}");
                }

                string phone = line.Substring(lastSpaceIndex + 1).Trim();
                string phoneDigits = phone.Replace("-", "");
                if (phoneDigits.Length != 7)
                {
                    throw new FormatException($"Некорректный номер" +
                        $" телефона в строке {lineNumber}: {phone}");
                }

                string departmentCode = phoneDigits.Substring(0, 5);

                if (departmentCount.ContainsKey(departmentCode))
                {
                    departmentCount[departmentCode] = departmentCount[departmentCode] + 1;
                }
                else
                {
                    departmentCount[departmentCode] = 1;
                }

                processedEmployees++;
            }
        }

        if (processedEmployees != totalEmployeesExpected)
        {
            throw new InvalidDataException($"Количество обработанных сотрудников" +
                $" ({processedEmployees}) не совпадает с " +
                $"заявленным в файле ({totalEmployeesExpected}).");
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