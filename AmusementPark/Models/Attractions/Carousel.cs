namespace AmusementPark.models.attractions;

public class Carousel : AttractionModel
{
    public bool GroundCarousel { get; set; }
    public string SeatType { get; set; }
    public Carousel(AttractionType type, string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin, bool groundCarousel, string seatType)
        : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = type;
        this.GroundCarousel = groundCarousel;
        this.SeatType = seatType;
    }

    public override string GetInfo()
    {
        var carouselType = GroundCarousel ? "Наземная" : "Воздушная";
        return $"Аттракцион: Карусель\n" +
               $"Название: {Name}\nТип карусели: {carouselType}\nВид сидения: {SeatType}\n" +
               $"Стоимость: {Price} руб.\nВозрастное ограничение: {AgeRestriction}+" +
               $"\nМаксимальное число посетителей: {MaxVisitors}\nДлительность в минутах: {DurationAttractionInMin}";
    }
}
