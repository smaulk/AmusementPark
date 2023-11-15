using System.Collections.Generic;
using AmusementPark.models.attractions;

namespace AmusementPark.models;

public class Park
{
    public string ParkName {get; set;}
    public string ParkAddress {get; set;}
    public string ParkWorkingHours {get; set;}
    private AttractionCollection<AttractionModel> AttractionsList { get;}
    
    //Получение последнего id
    private static int lastId = 0;
    public static int GetLastId() => ++lastId;
    
    public Park(string parkName, string parkAddress, string parkWorkingHours)
    {
        this.ParkName = parkName;
        this.ParkAddress = parkAddress;
        this.ParkWorkingHours = parkWorkingHours;
        this.AttractionsList = new AttractionCollection<AttractionModel>();
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