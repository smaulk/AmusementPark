namespace AmusementPark.models.attractions;

[Serializable]
public class GoKart : AttractionModel
{
    public double TrackLengthInMeters { get; set; }
    public double MaxSpeed { get; set; }
    public int NumberOfLaps { get; set; }

    public GoKart(string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin, 
        int numberOfLaps, double trackLengthInMeters, double maxSpeed)
        : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = AttractionType.Sports;
        this.NumberOfLaps = numberOfLaps;
        this.TrackLengthInMeters = trackLengthInMeters;
        this.MaxSpeed = maxSpeed;
    }
    public GoKart(){}
    
    public override string GetInfo()
    {
        return $"Аттракцион: Картинг\n" +
               $"Название: {Name}\nДлина трека: {TrackLengthInMeters} м.\nМакс. скорость: {MaxSpeed}\n" +
               $"Количество кругов: {NumberOfLaps}\nСтоимость: {Price} руб.\nВозрастное ограничение: {AgeRestriction}+" +
               $"\nМаксимальное число посетителей: {MaxVisitors}\nДлительность в минутах: {DurationAttractionInMin}";
    }
}
