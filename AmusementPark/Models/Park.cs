using System.Collections.Generic;
using System.Globalization;
using AmusementPark.models.attractions;

namespace AmusementPark.models;

public class Park
{
    public string ParkName {get; set;}
    public string ParkAddress {get; set;}

    private string _parkWorkingHours = "не задано";
    public string ParkWorkingHours
    {
        get => _parkWorkingHours;
        set
        {
            //Проверка, что заданная строка в формате HH:mm - HH:mm
            string[] formats = { "HH:mm", "H:mm" }; // Форматы, которые ожидаются
            string[] timeRange = value.Split('-');
            if (timeRange.Length == 2 &&
                DateTime.TryParseExact(timeRange[0].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var startTime) &&
                DateTime.TryParseExact(timeRange[1].Trim(), formats, CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out var endTime))
            {
                // Если обе строки успешно преобразованы в формат времени
                // Можно установить новые рабочие часы
                _parkWorkingHours = $"{startTime:HH:mm} - {endTime:HH:mm}";
            }
        }
    }
    private AttractionCollection<AttractionModel> AttractionsList { get;}
    private List<Visitor> VisitorsList { get; }

    public int CountAttractions => AttractionsList.Count;
    
    public Park(string parkName, string parkAddress, string parkWorkingHours)
    {
        this.ParkName = parkName;
        this.ParkAddress = parkAddress;
        this.ParkWorkingHours = parkWorkingHours;
        this.AttractionsList = new AttractionCollection<AttractionModel>();
        this.VisitorsList = new List<Visitor>();
    }

    public override string ToString()
    {
        return $"Название: {ParkName}\nАдрес: {ParkAddress}\nВремя работы: {ParkWorkingHours}\n" +
               $"Количество аттракционов: {CountAttractions}";
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
        return AttractionsList.ToArray();
    }

    public bool ExistAttraction(int id)
    {
        return GetAttractionById(id) != null;
    }

    public void AddVisitor(Visitor visitor)
    {
        VisitorsList.Add(visitor);
    }
    
    public void AddVisitor(Visitor[] visitors)
    {
        foreach (var visitor in visitors)
            AddVisitor(visitor);
    }
    
    public bool RemoveVisitor(int id)
    {
        if (!ExistVisitor(id)) return false;
        VisitorsList.RemoveAt(id);
        return true;
    }

    public bool RemoveVisitor(Visitor visitor)
    {
        return VisitorsList.Remove(visitor);
    }
    
    public Visitor? GetVisitorById(int id)
    {
        return ExistAttraction(id) ? VisitorsList[id] : null;
    }

    public bool ExistVisitor(int id)
    {
        if (id < 0 || id >= VisitorsList.Count) return false;
        return true;
    }
    
    public Visitor[] GetAllVisitors()
    {
        return VisitorsList.ToArray();
    }
    
    public bool BuyTicket(Visitor? visitor, AttractionModel? attraction)
    {
        if (attraction == null || visitor == null ||
            visitor.Age < attraction.AgeRestriction) return false;
        double price = attraction.Price;
        var type = TicketType.Adult;
        if (visitor.Age < 14)
        {
            price /= 2;
            type = TicketType.Child;
        }
        visitor.AddTicket(new Ticket($"Билет на аттракцион \"{attraction.Name}\"", price, type, attraction.Id));
        return true;
    }

    public void SortAttractions(Func<AttractionModel, AttractionModel, int> comparison)
    {
        AttractionsList.Sort(comparison);
    }
}