using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

public static class FileTasks
{
    private static readonly Random _random = new Random();

    /// <summary>
    /// ---------- Задание 1 ----------
    /// </summary>
    public static void FillFileWithNumbersOnePerLine(
        string filePath, 
        int count, 
        int minValue, 
        int maxValue)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            for (int i = 0; i < count; i++)
            {
                int number = _random.Next(minValue, maxValue + 1);
                writer.WriteLine(number);
            }
        }
    }

    public static bool ContainsNumber(string filePath, int b)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Файл не найден.", filePath);
        }

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            bool found = false;
            while (!found && (line = reader.ReadLine()) != null)
            {
                if (int.TryParse(line.Trim(), out int number) && number == b)
                {
                    found = true;
                }
            }
            return found;
        }
    }

    /// <summary>
    /// ---------- Задание 2 ----------
    /// </summary>
    public static void FillFileWithNumbersMultiplePerLine(
        string filePath, 
        int numbersPerLine,
        int lineCount, 
        int minValue, 
        int maxValue)
    {
        using (StreamWriter writer = new StreamWriter(filePath, false))
        {
            for (int i = 0; i < lineCount; i++)
            {
                string line = "";
                for (int j = 0; j < numbersPerLine; j++)
                {
                    if (j > 0)
                    {
                        line += " ";
                    }
                    line += _random.Next(minValue, maxValue + 1).ToString();
                }
                writer.WriteLine(line);
            }
        }
    }

    public static int SumMultiplesOfK(string filePath, int k)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Файл не найден.", filePath);
        }
        if (k == 0)
        {
            throw new ArgumentException
                ("Делитель k не может быть равен нулю.", nameof(k));
        }

        int sum = 0;
        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(new char[] { ' ', '\t' }, 
                    StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < parts.Length; i++)
                {
                    if (int.TryParse(parts[i], out int number) && number % k == 0)
                    {
                        sum += number;
                    }
                }
            }
        }
        return sum;
    }

    /// <summary>
    /// ---------- Задание 3 ----------
    /// </summary>
    public static void CopyLinesWithoutDigits(
        string sourcePath, 
        string destinationPath)
    {
        if (!File.Exists(sourcePath))
            throw new FileNotFoundException
                ("Исходный файл не найден.", sourcePath);

        using (StreamReader reader = 
            new StreamReader(sourcePath))
        using (StreamWriter writer = 
            new StreamWriter(destinationPath, false))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!ContainsAnyDigit(line))
                {
                    writer.WriteLine(line);
                }
            }
        }
    }

    private static bool ContainsAnyDigit(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// ---------- Задание 4 ----------
    /// </summary>
    public static void FillBinaryFileWithInts(
        string filePath, 
        int count, 
        int minValue, 
        int maxValue)
    {
        using (BinaryWriter writer = 
            new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(_random.Next(minValue, maxValue + 1));
            }
        }
    }

    public static void RemoveDuplicatesFromBinaryFile(
        string sourcePath, 
        string destinationPath)
    {
        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException("Исходный файл не найден.", sourcePath);
        }

        List<int> uniqueNumbers = new List<int>();

        using (BinaryReader reader = 
            new BinaryReader(File.OpenRead(sourcePath)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                bool found = false;
                for (int i = 0; i < uniqueNumbers.Count; i++)
                {
                    if (uniqueNumbers[i] == number)
                    {
                        found = true;
                        i = uniqueNumbers.Count;
                    }
                }
                if (!found)
                {
                    uniqueNumbers.Add(number);
                }
            }
        }

        using (BinaryWriter writer = 
            new BinaryWriter(File.Open(destinationPath, FileMode.Create)))
        {
            for (int i = 0; i < uniqueNumbers.Count; i++)
            {
                writer.Write(uniqueNumbers[i]);
            }
        }
    }

    public static void PrintBinaryFileInts(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }

        using (BinaryReader reader = new BinaryReader(File.OpenRead(filePath)))
        {
            Console.Write("Содержимое бинарного файла: ");
            bool first = true;
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int number = reader.ReadInt32();
                if (!first)
                    Console.Write(", ");
                Console.Write(number);
                first = false;
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// ---------- Задание 5 ----------
    /// </summary>
    public static void FillToysBinaryFile(string filePath, int count)
    {
        List<Toy> toys = new List<Toy>();
        string[] names = { 
            "Кукла", 
            "Машинка", 
            "Конструктор", 
            "Мяч", 
            "Пазл", 
            "Робот", 
            "Кубики", 
            "Настольная игра" };

        for (int i = 0; i < count; i++)
        {
            string name = names[_random.Next(names.Length)] + 
                " " + _random.Next(1, 100);
            int price = _random.Next(100, 5001);
            int minAge = _random.Next(0, 10);
            int maxAge = minAge + _random.Next(0, 10);
            if (maxAge > 18)
            {
                maxAge = 18;
            }
            toys.Add(new Toy(name, price, minAge, maxAge));
        }

        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        string xmlString;
        using (StringWriter textWriter = new StringWriter())
        {
            serializer.Serialize(textWriter, toys);
            xmlString = textWriter.ToString();
        }

        byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlString);
        using (BinaryWriter writer = 
            new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            writer.Write(xmlBytes.Length);
            writer.Write(xmlBytes);
        }
    }


    public static void PrintSuitableToysFromBinary(string filePath, int maxPrice)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Файл с игрушками не найден.", filePath);
        }

        List<Toy> toys;
        using (BinaryReader reader = new BinaryReader(File.OpenRead(filePath)))
        {
            int length = reader.ReadInt32();
            byte[] xmlBytes = reader.ReadBytes(length);
            string xmlString = Encoding.UTF8.GetString(xmlBytes);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
            using (StringReader textReader = new StringReader(xmlString))
            {
                toys = (List<Toy>)serializer.Deserialize(textReader);
            }
        }

        Console.WriteLine($"Игрушки с ценой <= {maxPrice} " +
            $"руб., подходящие детям 5 лет:");
        bool found = false;
        for (int i = 0; i < toys.Count; i++)
        {
            Toy toy = toys[i];
            if (toy.Price <= maxPrice && toy.MinAge <= 5 && toy.MaxAge >= 5)
            {
                Console.WriteLine($"- {toy.Name} (Цена: {toy.Price} руб., " +
                    $"Возраст: {toy.MinAge}-{toy.MaxAge})");
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("Подходящих игрушек не найдено.");
    }
}