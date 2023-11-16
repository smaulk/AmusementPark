namespace AmusementPark.models.attractions;

public class MiniGolf : AttractionModel
{
    public int NumberOfHoles { get; set; }
    public string SurfaceType { get; set; }

    public MiniGolf(string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin, int numberOfHoles, string surfaceType)
        : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = AttractionType.Sports;
        this.NumberOfHoles = numberOfHoles;
        this.SurfaceType = surfaceType;
    }
    
    public override string GetInfo()
    {
        return $"Аттракцион: Мини-гольф\n" +
               $"Название: {Name}\nТип поверхности: {SurfaceType}\nКоличество лунок: {NumberOfHoles}\n" +
               $"Стоимость: {Price} руб.\nВозрастное ограничение: {AgeRestriction}+" +
               $"\nМаксимальное число посетителей: {MaxVisitors}\nДлительность в минутах: {DurationAttractionInMin}";
    }
}
