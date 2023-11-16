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
               $"Название: {Name}\nДлина трека: {TrackLengthInMeters} м.\nМакс. скорость: {MaxSpeedInKmH} км/ч\n" +
               $"Вместимость вагона: {WagonCapacity} чел.\nСтоимость: {Price} руб.\nВозрастное ограничение: {AgeRestriction}+" +
               $"\nМаксимальное число посетителей: {MaxVisitors}\nДлительность в минутах: {DurationAttractionInMin}";
    }
}