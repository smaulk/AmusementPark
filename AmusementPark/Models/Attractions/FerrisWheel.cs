namespace AmusementPark.models.attractions;

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

    public override string GetInfo()
    {
        return $"Аттракцион: Колесо обозрения\n" +
               $"Название: {Name}, Вместимость кабины: {CabinCapacity} чел., Высота: {HeightInMeters}м., " +
               $"Стоимость: {Price} руб., Возрастное ограничение: {AgeRestriction}+";
    }
}