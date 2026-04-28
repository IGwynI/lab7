using System;

public struct Toy
{
    private string _name;
    private int _price;
    private int _minAge;
    private int _maxAge;

    public string Name
    {
        get 
        { 
            return _name; 
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Название игрушки не может быть пустым.");
            }
            _name = value;
        }
    }

    public int Price
    {
        get 
        { 
            return _price; 
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Цена не может быть отрицательной.");
            }
            _price = value;
        }
    }

    public int MinAge
    {
        get 
        { 
            return _minAge; 
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException
                    ("Минимальный возраст не может быть отрицательным.");
            }
            _minAge = value;
        }
    }

    public int MaxAge
    {
        get 
        { 
            return _maxAge; 
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException
                    ("Максимальный возраст не может быть отрицательным.");
            }
            _maxAge = value;
        }
    }

    public Toy(string name, int price, int minAge, int maxAge)
    {
        _name = null;
        _price = 0;
        _minAge = 0;
        _maxAge = 0;
        Name = name;
        Price = price;
        MinAge = minAge;
        MaxAge = maxAge;
        if (minAge > maxAge)
        {
            throw new ArgumentException
                ("Минимальный возраст не может быть больше максимального.");
        }
    }
}