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
               $"Название: {Name}, Тип карусели: {carouselType}, Вид сидения: {SeatType}, " +
               $"Стоимость: {Price} руб., Возрастное ограничение: {AgeRestriction}+";
    }
}
