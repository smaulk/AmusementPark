using System;
using System.Globalization;
using AmusementPark.models;
using AmusementPark.models.attractions;

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
            "Информация о парке", "Просмотр аттракционов", "Просмотр посетителей", "Закрыть программу"
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
                    
                    break;
                case 4:
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
        
        switch (menuId)
        {
            case 1: //В главное меню
                return;
            case 2: //Изменение названия парка
                var newName = cm.GetString("Введите новое название парка:");
                park.ParkName = newName;
                cm.Echo("Название успешно изменено!\n");
                return;
            case 3: //Изменение адреса парка
                var newAdress = cm.GetString("Введите новый адрес парка:");
                park.ParkAddress = newAdress;
                cm.Echo("Адрес успешно изменен!\n");
                return;
            case 4: //Изменение времени работы парка
                var newWorkingHours = cm.GetString("Введите новое время работы (hh:mm - hh:mm)");
                park.ParkWorkingHours = newWorkingHours;
                return;
        }
        
    }
    
    private void ViewAttractions()// Вывод списка аттракционов парка
    {
        var attractions = park.GetAllAttractions();
        foreach (var attraction in attractions)
            cm.Echo($"{attraction.Id} - {attraction}");

        string[] menuItems = new[]
        {
            "В главное меню", "Добавить аттракцион", "Выбрать аттракцион"
        };

        var menuId = cm.MenuDisplay(menuItems);
        
        switch (menuId)
        {
            case 1: //В главное меню
                return;
            case 2: //Создание аттрациона
                CreateAttractionMenu();
                return;
            case 3: //Выбор аттракциона
                int attId = cm.GetInt("Введите id нужного аттракциона:");
                while (!park.ExistAttraction(attId))
                    attId = cm.GetInt("Введите id существующего аттракциона!");
                SelectAttractionMenu(attId);
                return;
        }
        
    }

    private void CreateAttractionMenu()//Меню создания аттракциона
    {
        string[] menuItems = new[]
        {
            "Карусель", "Колесо обозрения", "Картинг", "Лабиринт страха", "Мини-гольф", "Американские горки", "Тир"
        };

        var menuId = cm.MenuDisplay(menuItems, "Выберите нужный аттракцион для создания:");

        var data = GetAttractionModelData();

        switch (menuId)
        {
            case 1:
                park.AddAttraction(new Carousel(
                    cm.GetAttractonType("Введите тип аттракциона:") ,
                    (string)data[0], (double)data[1], (int)data[2],
                    (int)data[3],(double)data[4], 
                    cm.GetBool("Карусель является наземной?"),
                    cm.GetString("Введите вид сидения:")));
                break;
            case 2:
                park.AddAttraction(new FerrisWheel(
                    (string)data[0], (double)data[1], (int)data[2],
                    (int)data[3],(double)data[4], 
                    cm.GetDouble("Введите высоту Колеса в метрах:"),
                    cm.GetInt("Введите вместимость кабины (кол-во чел.):")));
                break;
            case 3:
                park.AddAttraction(new GoKart(
                    (string)data[0], (double)data[1], (int)data[2],
                    (int)data[3],(double)data[4], 
                    cm.GetInt("Введите количество кругов:"),
                    cm.GetDouble("Введите длину трека в метрах:"),
                    cm.GetDouble("Введите максимальную скорость:")));
                break;
            case 4:
                park.AddAttraction(new HorrorMaze(
                    (string)data[0], (double)data[1], (int)data[2],
                    (int)data[3],(double)data[4], 
                    cm.GetString("Введите тематику лабиринта:"),
                    cm.GetInt("Введите уровень страха (в промежутке 1-10):")));
                break;
            case 5:
                park.AddAttraction(new MiniGolf(
                    (string)data[0], (double)data[1], (int)data[2],
                    (int)data[3],(double)data[4], 
                    cm.GetInt("Введите количество лунок:"),
                    cm.GetString("Введите тип поверхности:")));
                break;
            case 6:
                park.AddAttraction(new RollerCoaster(
                    (string)data[0], (double)data[1], (int)data[2],
                    (int)data[3],(double)data[4], 
                    cm.GetDouble("Введите длину трека в метрах:"),
                    cm.GetDouble("Введите максимальную скорость:"),
                    cm.GetInt("Введите вместимость вагона (кол-во чел.):")));
                break;
            case 7:
                park.AddAttraction(new ShootingRange(
                    (string)data[0], (double)data[1], (int)data[2],
                    (int)data[3],(double)data[4], 
                    cm.GetInt("Введите количество целей:"),
                    cm.GetString("Введите вид оружия:")));
                break;
        }
        cm.Message("Аттракцион успешно создан!");
        
    }

    private object[] GetAttractionModelData()//Получение массива с данными для создания аттракционов
    {
        return new object[]
        {
            cm.GetString("Введите название:"),
            cm.GetDouble("Введите цену:"),
            cm.GetInt("Введите минимальный возраст:"),
            cm.GetInt("Введите максимальное количество посетителей:"),
            cm.GetDouble("Введите длительность посещения в минутах:")
        };
    }

    private void SelectAttractionMenu(int attractionId)//Меню после выбора аттракциона
    {
        var attraction = park.GetAttractionById(attractionId);
        cm.Echo(attraction?.GetInfo());
        
        string[] menuItems = new[]
        {
            "В главное меню", "Удалить аттракцион",
        };

        var menuId = cm.MenuDisplay(menuItems);

        switch (menuId)
        {
            case 1:
                return;
            case 2:
                park.RemoveAttraction(attractionId);
                cm.Message($"Аттракцион \"{attraction.Name}\" удален!");
                return;
        }
    }
}