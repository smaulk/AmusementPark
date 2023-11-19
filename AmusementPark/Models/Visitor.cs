using System.Collections.Generic;

namespace AmusementPark.models;

public class Visitor
{
    public string? Name { get; set; }
    public int Age { get; set; }
    private List<Ticket> Tickets { get; }

    public Visitor(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.Tickets = new List<Ticket>();
    }

    public int TicketCount => Tickets.Count;

    public void AddTicket(Ticket ticket)
    {
        this.Tickets.Add(ticket);
    }

    public Ticket[] GetTickets()
    {
        return new List<Ticket>(Tickets).ToArray();
    }

    public override string ToString()
    {
        return $"Имя: {Name}, Возраст: {Age}, Билеты: {TicketCount}";
    }
}