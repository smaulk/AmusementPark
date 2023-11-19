namespace AmusementPark.models;

public class Ticket
{
    public string Name { get; }
    public double Price { get; }
    public TicketType TicketType { get; } // Поле для указания типа билета
    public int AttractionId { get; }
    
    //Для создания билета для аттракциона
    public Ticket(string name, double price, TicketType ticketType, int attractionId)
    {
        this.Name = name;
        this.Price = price;
        this.TicketType = ticketType;
        this.AttractionId = attractionId;
    }

    public override string ToString()
    {
        var type = TicketType == TicketType.Adult ? "Взрослый" : "Детский";
        return $"Название: {Name}, Цена: {Price}, Тип билета: {type}";
    }
}