namespace AmusementPark.models.attractions;

public class GoKart : AttractionModel
{
    public double TrackLengthInMeters { get; set; }
    public double MaxSpeed { get; set; }

    public GoKart(string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin, double trackLengthInMeters, double maxSpeed)
        : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = AttractionType.Sports;
        this.TrackLengthInMeters = trackLengthInMeters;
        this.MaxSpeed = maxSpeed;
    }
    
    public override string GetInfo()
    {
        return $"Аттракцион: Картинг\n" +
               $"Название: {Name}, Длина трека: {TrackLengthInMeters} м., Макс. скорость: {MaxSpeed}, " +
               $"Стоимость: {Price} руб., Возрастное ограничение: {AgeRestriction}+";
    }
}
