using System.Collections.Generic;
using System.Globalization;
using AmusementPark.models.attractions;

namespace AmusementPark.models;

public class Park
{
    public string ParkName {get; set;}
    public string ParkAddress {get; set;}

    private string parkWorkingHours = "не задано";
    public string ParkWorkingHours
    {
        get => parkWorkingHours;
        set
        {
            //Проверка, что заданная строка в формате HH:mm - HH:mm
            DateTime startTime;
            DateTime endTime;
            string[] formats = { "HH:mm", "H:mm" }; // Форматы, которые ожидаются
            string[] timeRange = value.Split('-');
            if (timeRange.Length == 2 &&
                DateTime.TryParseExact(timeRange[0].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out startTime) &&
                DateTime.TryParseExact(timeRange[1].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out endTime))
            {
                // Если обе строки успешно преобразованы в формат времени
                // Можно установить новые рабочие часы
                parkWorkingHours = value;
            }
        }
    }
    private AttractionCollection<AttractionModel> AttractionsList { get;}
    
    //Получение последнего id
    private static int lastId = 0;
    public static int LastId => ++lastId;
    
    public Park(string parkName, string parkAddress, string parkWorkingHours)
    {
        this.ParkName = parkName;
        this.ParkAddress = parkAddress;
        this.ParkWorkingHours = parkWorkingHours;
        this.AttractionsList = new AttractionCollection<AttractionModel>();
    }

    public override string ToString()
    {
        return $"Название: {ParkName}\nАдрес: {ParkAddress}\nВремя работы: {ParkWorkingHours}";
    }

    public void AddAttraction(AttractionModel attraction)
    {
        this.AttractionsList.Add(attraction);
    }

    public void AddAttraction(AttractionModel[] attractions)
    {
        foreach (var attraction in attractions)
            AddAttraction(attraction);
    }

    public bool RemoveAttraction(int attractionId)
    {
        return AttractionsList.Remove(GetAttractionById(attractionId));
    }
    
    public bool RemoveAttraction(AttractionModel attraction)
    {
        return AttractionsList.Remove(attraction);
    }

    public AttractionModel? GetAttractionById(int id)
    {
        return this.AttractionsList.Find((model => model.Id == id));
    }

    //Чтобы нельзя было добавить/Удалить аттракцион из списка
    public AttractionModel[] GetAllAttractions()
    {
        return new List<AttractionModel>(AttractionsList).ToArray();
    }

    public bool ExistAttraction(int id)
    {
        return GetAttractionById(id) != null;
    }
    
    public bool BuyTicket(Visitor visitor, int attractionId)
    {
        var attraction = GetAttractionById(attractionId);
        if (attraction == null) return false;
        double price = attraction.Price;
        var type = TicketType.Adult;
        if (visitor.Age < 14)
        {
            price /= 2;
            type = TicketType.Child;
        }
        visitor.AddTicket(new Ticket($"Билет на аттракцион \"{attraction.Name}\"", price, type, attractionId));
        return true;
    }
}