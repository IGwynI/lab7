using System;

public static class CheckInput
{
    public static int ReadInt(string message)
    {
        int result = 0;
        bool valid = false;
        string input;
        while (!valid)
        {
            Console.Write(message);
            input = Console.ReadLine();
            if (int.TryParse(input, out result))
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }
        return result;
    }

    public static string ReadFilePath(string message)
    {
        string path = "";
        bool valid = false;
        while (!valid)
        {
            Console.Write(message);
            path = Console.ReadLine();
            path = path.Trim();
            if (path.Length >= 2 && path[0] == '"' && path[path.Length - 1] == '"')
            {
                path = path.Substring(1, path.Length - 2);
            }
            if (!string.IsNullOrWhiteSpace(path))
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: путь не может быть пустым.");
            }
        }
        return path;
    }

    public static int ReadPositiveInt(string message)
    {
        int number;
        bool valid = false;
        do
        {
            number = ReadInt(message);
            if (number > 0)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: число должно быть больше 0.");
            }
        } while (!valid);
        return number;
    }

    public static int ReadNonNegativeInt(string message)
    {
        int number;
        bool valid = false;
        do
        {
            number = ReadInt(message);
            if (number >= 0)
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("Ошибка: число не может быть отрицательным.");
            }
        } while (!valid);
        return number;
    }
}