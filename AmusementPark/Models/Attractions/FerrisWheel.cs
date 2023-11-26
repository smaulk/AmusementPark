namespace AmusementPark.models.attractions;

[Serializable]
public class FerrisWheel: AttractionModel
{
    public double HeightInMeters { get; set; }
    public int CabinCapacity {get; set; }

    public FerrisWheel(string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin,
        double heightInMeters, int cabinCapacity) : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = AttractionType.Entertainment;
        this.HeightInMeters = heightInMeters;
        this.CabinCapacity = cabinCapacity;
    }
    public FerrisWheel(){}

    public override string GetInfo()
    {
        return $"Аттракцион: Колесо обозрения\n" +
               $"Название: {Name}\nВместимость кабины: {CabinCapacity} чел.\nВысота: {HeightInMeters}м.\n" +
               $"Стоимость: {Price} руб.\nВозрастное ограничение: {AgeRestriction}+" +
               $"\nМаксимальное число посетителей: {MaxVisitors}\nДлительность в минутах: {DurationAttractionInMin}";
    }
}