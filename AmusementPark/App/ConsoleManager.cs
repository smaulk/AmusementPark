using System;

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
            if (double.TryParse(Console.ReadLine(), out num))
                return num;
            Console.WriteLine("Введите число!");
        }
    }
}