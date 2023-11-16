using System;
using System.Globalization;
using AmusementPark.models;

namespace AmusementPark;

public class ConsoleManager
{

    public void Echo(string str = "")
    {
        Console.WriteLine(str);
    }

    public void Message(string message = "")
    {
        if(message != "") Console.WriteLine(message);
        Console.WriteLine("\nНажмите любую кнопку...");
        Console.ReadLine();
    }

    //Принимает массив элементов меню и возвращает id пункта меню
    public int MenuDisplay(string[] menuItems, string menuName = "")
    {
        if (menuItems.Length == 0) return -1;
        //Вывод меню в консоль
        Console.WriteLine(menuName);
        for (int i = 0; i < menuItems.Length; i++)
            Console.WriteLine($"{i + 1}. {menuItems[i]}");
        
        //Считывание id меню
        int id = GetInt("\nВведите нужный пункт меню:");
        while (id < 1 || id > menuItems.Length)
            id = GetInt("Введите номер из заданного меню!");
        
        return id;
    }

    public string GetString(string message)
    {
        Console.WriteLine(message);
        return Console.ReadLine() ?? "";
    }

    public int GetInt(string message)
    {
        Console.WriteLine(message);
        
        while (true)
        {
            int num;
            if (int.TryParse(Console.ReadLine(), out num))
                return num;
            Console.WriteLine("Введите целое число!");
        }
    }

    public double GetDouble(string message)
    {
        Console.WriteLine(message);
        
        while (true)
        {
            double num;
            if (double.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out num))
                return num;
            Console.WriteLine("Введите число!");
        }
    }

    public bool GetBool(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("(Введите 0 если нет, и 1 если да)");

        while (true)
        {
            var str = Console.ReadLine();
            if (str == "0" || str == "1")
                return str != "0";
            Console.WriteLine("Введите 0 если нет, и 1 если да:");
        }
    }
    
    public AttractionType GetAttractonType(string message)
    {
        Console.WriteLine(message);
        var types = new string[]
        {
            "Для детей", "Экстремальный", "Спортивный", "Развлекательный", "Неизвестный"
        };
        var typeID = MenuDisplay(types);
        
        switch (typeID)
        {
            case 1:
                return AttractionType.ForChildren;
            case 2:
                return AttractionType.Extreme;
            case 3:
                return AttractionType.Sports;
            case 4:
                return AttractionType.Entertainment;
            case 5:
                return AttractionType.Unidentified;
        }

        return AttractionType.Unidentified;
    }
}