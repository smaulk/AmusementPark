﻿namespace AmusementPark.models.attractions;

[Serializable]
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
    public ShootingRange(){}
    
    public override string GetInfo()
    {
        return $"Аттракцион: Тир\n" +
               $"Название: {Name}\nТип оружия: {GunType}\nКоличество целей: {TargetCount}\n" +
               $"Стоимость: {Price} руб.\nВозрастное ограничение: {AgeRestriction}+" +
               $"\nМаксимальное число посетителей: {MaxVisitors}\nДлительность в минутах: {DurationAttractionInMin}";
    }
}
