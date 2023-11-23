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
    
    private readonly Func<AttractionModel, AttractionModel, int> _compareId = (x, y) => x.Id.CompareTo(y.Id);
    private readonly Func<AttractionModel, AttractionModel, int> _compareName = (x, y) => String.Compare(x.Name, y.Name, StringComparison.Ordinal);
    private readonly Func<AttractionModel, AttractionModel, int> _comparePrice = (x, y) => x.Price.CompareTo(y.Price);
    private readonly Func<AttractionModel, AttractionModel, int> _compareMaxVisitors = (x, y) => y.MaxVisitors.CompareTo(x.MaxVisitors);
    private readonly Func<AttractionModel, AttractionModel, int> _compareAgeRestriction = (x, y) => x.AgeRestriction.CompareTo(y.AgeRestriction);
    
    public void Run()//Запуск и главное меню
    {
        string[] menuItems = new[]
        {
            "Информация о парке", "Просмотр аттракционов", "Просмотр посетителей", "Расчеты", "Закрыть программу"
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
                    ViewVisitors();
                    break;
                case 4:
                    ViewCalculations();
                    break;
                case 5:
                    cm.Message("Закрытие программы");
                    return;
            }
        }

    }

    private void ViewParkData() //Вывод данных парка
    {
        
        string[] menuItems = new[]
        {
            "В главное меню", "Изменить название", "Изменить адрес", "Изменить время работы"
        };
        
        while (true)
        {
            cm.Echo(park.ToString());
            var menuId = cm.MenuDisplay(menuItems);
            switch (menuId)
            {
                case 1: //В главное меню
                    return;
                case 2: //Изменение названия парка
                    var newName = cm.GetString("Введите новое название парка:");
                    park.ParkName = newName;
                    cm.Echo("Название успешно изменено!\n");
                    break;
                case 3: //Изменение адреса парка
                    var newAdress = cm.GetString("Введите новый адрес парка:");
                    park.ParkAddress = newAdress;
                    cm.Echo("Адрес успешно изменен!\n");
                    break;
                case 4: //Изменение времени работы парка
                    var newWorkingHours = cm.GetString("Введите новое время работы (hh:mm - hh:mm)");
                    park.ParkWorkingHours = newWorkingHours;
                    break;
            }
        }
    }
    
    private void ViewAttractions()// Вывод списка аттракционов парка
    {

        string[] menuItems = new[]
        {
            "В главное меню", "Добавить аттракцион", "Выбрать аттракцион", "Сортировать"
        };

        while (true)
        {
            EchoAttractions();
            var menuId = cm.MenuDisplay(menuItems);
            switch (menuId)
            {
                case 1: //В главное меню
                    return;
                case 2: //Создание аттрациона
                    CreateAttractionMenu();
                    break;
                case 3: //Выбор аттракциона
                    SelectAttractionMenu(GetExistAttraction(cm.GetInt("Введите id нужного аттракциона:")));
                    break;
                case 4:
                    SelectSortingMenu();
                    break;
            }
        }

    }

    private void EchoAttractions(int minVisitorAge = 999)
    {
        var attractions = park.GetAllAttractions();
        foreach (var attraction in attractions)
        {
            if(minVisitorAge >= attraction.AgeRestriction)
                cm.Echo($"{attraction.Id} - {attraction}");
        }
    }

    private AttractionModel GetExistAttraction(int attId, int minVisitorAge = 999)
    {
        AttractionModel? attraction = park.GetAttractionById(attId);
        while (attraction == null || attraction.AgeRestriction > minVisitorAge)
            attraction = park.GetAttractionById(cm.GetInt("Введите id аттракциона из списка!"));
        return attraction;
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

    private void SelectAttractionMenu(AttractionModel? attraction)//Меню после выбора аттракциона
    {
        if (attraction == null)
        {
            cm.Message("Аттракцион не найден!");
            return;
        }
        cm.Echo(attraction.GetInfo());
        
        string[] menuItems = new[]
        {
            "Назад", "Удалить аттракцион",
        };

        var menuId = cm.MenuDisplay(menuItems);

        switch (menuId)
        {
            case 1:
                return;
            case 2:
                var answer = cm.GetBool("Вы уверены?");
                if(!answer) break;
                if(park.RemoveAttraction(attraction)) cm.Message($"Аттракцион \"{attraction.Name}\" удален!");
                else cm.Message("Произошла ошибка при удалении!");
                return;
        }
    }

    private void ViewVisitors()
    {

        string[] menuItems = new[]
        {
            "В главное меню", "Добавить посетителя", "Выбрать посетителя"
        };

        while (true)
        {
            EchoVisitors();
            var menuId = cm.MenuDisplay(menuItems);
            switch (menuId)
            {
                case 1:
                    return;
                case 2:
                    var visitorName = cm.GetString("Введите имя посетителя:");
                    var visitorAge = cm.GetInt("Введите возраст посетителя:");
                    park.AddVisitor(new Visitor(visitorName, visitorAge));
                    cm.Message("Посетитель успешно создан!");
                    break;
                case 3:
                    SelectVisitorMenu(GetExistVisitor(cm.GetInt("Введите id нужного посетителя:")));
                    break;
            }
        }
    }

    private void EchoVisitors()
    {
        var visitors = park.GetAllVisitors();
        for (int i = 0; i < visitors.Length; i++)
            cm.Echo($"{i+1} - {visitors[i]}");
    }

    private Visitor GetExistVisitor(int visitorId)
    {
        while (!park.ExistVisitor(visitorId - 1))
            visitorId = cm.GetInt("Введите id существующего посетителя!");
        return park.GetVisitorById(visitorId - 1)!;
    }
    
    private void SelectVisitorMenu(Visitor? visitor)
    {
        if (visitor == null)
        {
            cm.Message("Посетитель не найден!");
            return;
        }
        string[] menuItems = new[]
        {
            "Назад","Удалить посетителя", "Изменить имя", "Изменить возраст", "Просмотр билетов", "Купить билет"
        };
        
        while (true)
        {
            cm.Echo(visitor.ToString());

            var menuId = cm.MenuDisplay(menuItems);
            switch (menuId)
            {
                case 1:
                    return;
                case 2:
                    var answer = cm.GetBool("Вы уверены?");
                    if(!answer) break;
                    if(park.RemoveVisitor(visitor)) cm.Message("Посетитель был удален!");
                    else cm.Message("Произошла ошибка при удалении!");
                    return;
                case 3:
                    visitor.Name = cm.GetString("Введите новое имя посетителя:");
                    cm.Message("Имя успешно изменено!");
                    break;
                case 4:
                    visitor.Age = cm.GetInt("Введите новый возраст посетителя:");
                    cm.Message("Возраст успешно изменен!");
                    break;
                case 5:
                    if (visitor.TicketCount == 0) cm.Message("У посетителя нет билетов!");
                    else
                    {
                        foreach (var ticket in visitor.GetTickets())
                            cm.Echo(ticket.ToString());
                        cm.Message();
                    }
                    break;
                case 6:
                    EchoAttractions(visitor.Age);
                    if (park.BuyTicket(visitor, GetExistAttraction(cm.GetInt("Введите id нужного аттракциона:"), visitor.Age)))
                        cm.Message("Билет успешно куплен!");
                    else cm.Message("Ошибка при покупке билета!");
                    break;
            }
        }
    }

    
    private void ViewCalculations()
    {
        var visitors = new List<Visitor>();
        var attractions = new List<AttractionModel>();

        if (park.GetAllVisitors().Length == 0 || park.GetAllAttractions().Length == 0)
        {
            cm.Message("Посетители или аттракционы отсутсвуют!");
            return;
        }
        
        //Получение посетителей и аттракционов
        cm.Echo("Выберите посетителей:");
        EchoVisitors();
        var minAge = 999;
        while (true)
        {
            var num = cm.GetInt("Введите id посетителя (для завершения введите 0):");
            if(num == 0) break;
            var visitor = GetExistVisitor(num);
            if (visitors.Contains(visitor)) cm.Echo("Данный посетитель уже выбран!");
            else
            {
                visitors.Add(visitor);
                if (minAge > visitor.Age) minAge = visitor.Age;
            }
        }
        
        
        cm.Echo("\nВыберите аттракционы:");
        EchoAttractions(minAge);
        while (true)
        {
            var num = cm.GetInt("Введите id аттракциона (для завершения введите 0):");
            if(num == 0) break;
            var attraction = GetExistAttraction(num, minAge);
            if (attractions.Contains(attraction)) cm.Echo("Данный аттракцион уже выбран!");
            else attractions.Add(attraction);
        }
        cm.Echo("\nВы выбрали:");
        cm.Echo("\nПосетители:");
        foreach (var visitor in visitors)
            cm.Echo(visitor.ToString());
        cm.Echo("\nАттракционы:");
        foreach (var attraction in attractions)
            cm.Echo(attraction.ToString());
        
        //Вычисления
        int countChildVisitors = 0;
        foreach (var visitor in visitors)
            if (visitor.Age < 14) countChildVisitors++;
        int countAdultVisitors = visitors.Count - countChildVisitors;
        
        
        double totalDurationInMin = 0;
        double totalSumPrice = 0;
        foreach (var attraction in attractions)
        {
            int numberVisitsForGroup = (int)Math.Ceiling((double)visitors.Count / attraction.MaxVisitors);
            double durationInMin = numberVisitsForGroup * attraction.DurationAttractionInMin;
            totalDurationInMin += durationInMin;
            totalSumPrice += countAdultVisitors * attraction.Price + countChildVisitors * (attraction.Price / 2);
        }
        
        cm.Echo($"\nДлительность посещения аттракционов для группы: {totalDurationInMin} мин.\n" +
                $"Общая сумма билетов для группы: {totalSumPrice} руб.\n" +
                $"Количество посетителей: {visitors.Count}\n" +
                $"Количество посетителей с детским билетом: {countChildVisitors}\n" +
                $"Количество аттракционов: {attractions.Count}\n");
        
        
        //Покупка билетов
        var buyTickets = cm.GetBool("Купить билеты посетителям на данные аттракционы?");
        if(!buyTickets) return;
        foreach (var attraction in attractions)
        {
            foreach (var visitor in visitors)
            {
                cm.Echo(park.BuyTicket(visitor, attraction)
                    ? $"Билет на аттракцион {attraction.Name} для {visitor.Name} куплен!"
                    : $"При покупке билета на аттракцион {attraction.Name} для {visitor.Name} произошла ошибка!");
            }
        }
        
    }


    private void SelectSortingMenu()
    {
        string[] menuItems = new[]
        {
            "Назад","Сортировать по id", "Сортировать по имени", "Сортировать по цене",
            "Сортировать по вместимости", "Сортировать по возрастному ограничению"
        };
        
        var menuId = cm.MenuDisplay(menuItems);
        switch (menuId)
        {
            case 1:
                return;
            case 2:
                park.SortAttractions(_compareId);
                break;
            case 3:
                park.SortAttractions(_compareName);
                break;
            case 4:
                park.SortAttractions(_comparePrice);
                break;
            case 5:
                park.SortAttractions(_compareMaxVisitors);
                break;
            case 6:
                park.SortAttractions(_compareAgeRestriction);
                break;
        }
        cm.Message("Аттракционы успешно отсортированы!");
    }
}