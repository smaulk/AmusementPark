using System;
using System.Globalization;
using AmusementPark.models;

namespace AmusementPark;

public class ParkApp
{
    private Park park;
    private ConsoleManager cm;

    public ParkApp(Park park)
    {
        this.park = park;
        this.cm = new ConsoleManager();
    }

    public void Run()//Запуск и главное меню
    {
            string[] menuItems = new[]
            {
                "Информация о парке", "Просмотр аттракционов", "Закрыть программу"
            };
            
        while (true)
        {
            var menuId = cm.MenuDisplay(menuItems, "Главное меню");
            switch (menuId)
            {
                case 1:
                    ViewParkData();
                    break;
                case 2:
                    ViewAttractions();
                    break;
                case 3:
                    cm.Message("Закрытие программы");
                    return;
            }
        }
    }

    private void ViewParkData() //Вывод данных парка
    {
        cm.Echo(park.ToString());
        
        string[] menuItems = new[]
        {
            "В главное меню", "Изменить название", "Изменить адрес", "Изменить время работы"
        };

        var menuId = cm.MenuDisplay(menuItems);
        
        while (true)
        {
            switch (menuId)
            {
                case 1:
                    Run();
                    break;
                case 2:
                    var newName = cm.GetString("Введите новое название парка:");
                    park.ParkName = newName;
                    cm.Echo("Название успешно изменено!\n");
                    ViewParkData();
                    break;
                case 3:
                    var newAdress = cm.GetString("Введите новый адрес парка:");
                    park.ParkAddress = newAdress;
                    cm.Echo("Адрес успешно изменен!\n");
                    ViewParkData();
                    break;
                case 4:
                    var newWorkingHours = cm.GetString("Введите новое время работы (hh:mm - hh:mm)");
                    park.ParkWorkingHours = newWorkingHours;
                    ViewParkData();
                    break;
            }
        }
        
    }
    
    private void ViewAttractions()// Вывод списка аттракционов парка
    {
        foreach (var attraction in park.GetAllAttractions())
            cm.Echo(attraction.ToString());
        
        string[] menuItems = new[]
        {
            "В главное меню", "Добавить аттракцион", "Выбрать аттракцион"
        };

        var menuId = cm.MenuDisplay(menuItems);

        while (true)
        {
            switch (menuId)
            {
                case 1:
                    Run();
                    break;
            }
        }
    }

    private void CreateAttractionMenu()//Меню создания аттракциона
    {
        
    }
    
}