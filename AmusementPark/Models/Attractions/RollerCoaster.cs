namespace AmusementPark.models.attractions;

public class RollerCoaster: AttractionModel
{
    public double TrackLengthInMeters { get; set; }
    public double MaxSpeedInKmH { get; set; }
    public int WagonCapacity { get; set; }
    
    public RollerCoaster(string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin,
        double trackLengthInMeters, double maxSpeedInKmH, int wagonCapacity) : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = AttractionType.Extreme;
        this.TrackLengthInMeters = trackLengthInMeters;
        this.MaxSpeedInKmH = maxSpeedInKmH;
        this.WagonCapacity = wagonCapacity;
    }
    
    public override string GetInfo()
    {
        return $"Аттракцион: Американские горки\n" +
               $"Название: {Name}, Длина трека: {TrackLengthInMeters} м., Макс. скорость: {MaxSpeedInKmH} км/ч, " +
               $" Вместимость вагона: {WagonCapacity} чел., Стоимость: {Price} руб., Возрастное ограничение: {AgeRestriction}+";
    }
}