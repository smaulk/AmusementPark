namespace AmusementPark.models.attractions;

public class HorrorMaze : AttractionModel
{
    public string Theme { get; set; }
    private int _scareLevel = 1;
    public int ScareLevel //Значение в промежутке от 1 до 10
    {
        get => _scareLevel;
        set
        {
            _scareLevel = value switch
            {
                < 1 => 1,
                > 10 => 10,
                _ => value
            };
        }
    }

    public HorrorMaze(string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin, string theme, int scareLevel)
        : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = AttractionType.Entertainment;
        this.Theme = theme;
        this.ScareLevel = scareLevel;
    }
    
    public override string GetInfo()
    {
        return $"Аттракцион: Лабиринт страха\n" +
               $"Название: {Name}, Тема лабиринта: {Theme}, Уровень страха (1-10): {ScareLevel}, " +
               $"Стоимость: {Price} руб., Возрастное ограничение: {AgeRestriction}+";
    }
}