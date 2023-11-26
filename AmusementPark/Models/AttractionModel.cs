using System.Xml.Serialization;
using AmusementPark.models.attractions;

namespace AmusementPark.models;

//Атрибуты для сериализации в XML
[XmlInclude(typeof(Carousel))]
[XmlInclude(typeof(FerrisWheel))]
[XmlInclude(typeof(GoKart))]
[XmlInclude(typeof(HorrorMaze))]
[XmlInclude(typeof(MiniGolf))]
[XmlInclude(typeof(RollerCoaster))]
[XmlInclude(typeof(ShootingRange))]
[Serializable]
public abstract class AttractionModel
{
    public int Id { get;}
    public string? Name { get; set; }
    public AttractionType Type { get; set; }
    public double Price { get; set; }
    public int AgeRestriction { get; set; }
    public int MaxVisitors {get; set; }
    public double DurationAttractionInMin { get; set; }
    
    //Последний Id
    private static int _lastId = 0;

    public AttractionModel(string name,  double price,
        int ageRestriction, int maxVisitors, double durationAttractionInMin)
    {
        this.Id = ++_lastId;
        this.Name = name;
        this.Price = price;
        this.AgeRestriction = ageRestriction;
        this.MaxVisitors = maxVisitors;
        this.DurationAttractionInMin = durationAttractionInMin;
    }

    public AttractionModel()
    {
        this.Id = ++_lastId;
    }

    public abstract string GetInfo();

    public override string ToString()
    {
        return $"{GetType().Name}, Название: {Name}, Цена: {Price}, Вместимость: {MaxVisitors} чел.," +
               $" Возрастное ограничение: {AgeRestriction}+, Тип: {Type}";
    }
    
}
