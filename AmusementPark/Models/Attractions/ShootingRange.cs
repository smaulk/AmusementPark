namespace AmusementPark.models.attractions;

public class ShootingRange : AttractionModel
{
    public int TargetCount { get; set; }
    public string GunType { get; set; }

    public ShootingRange(string name, double price, int ageRestriction, int maxVisitors, double durationAttractionInMin, int targetCount, string gunType)
        : base(name, price, ageRestriction, maxVisitors, durationAttractionInMin)
    {
        this.Type = AttractionType.Sports;
        this.TargetCount = targetCount;
        this.GunType = gunType;
    }
    
    public override string GetInfo()
    {
        return $"Аттракцион: Тир\n" +
               $"Название: {Name}, Тип оружия: {GunType}, Количество целей: {TargetCount}, " +
               $"Стоимость: {Price} руб., Возрастное ограничение: {AgeRestriction}+";
    }
}
