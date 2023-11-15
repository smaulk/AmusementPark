﻿namespace AmusementPark.models;

public abstract class AttractionModel
{
    public int Id { get;}
    public string? Name { get; set; }
    public AttractionType Type { get; set; }
    public double Price { get; set; }
    public int AgeRestriction { get; set; }
    public int MaxVisitors {get; set; }
    public double DurationAttractionInMin { get; set; }

    public AttractionModel(string name,  double price,
        int ageRestriction, int maxVisitors, double durationAttractionInMin)
    {
        this.Id = Park.GetLastId();
        this.Name = name;
        this.Price = price;
        this.AgeRestriction = ageRestriction;
        this.MaxVisitors = maxVisitors;
        this.DurationAttractionInMin = durationAttractionInMin;
    }

    public abstract string GetInfo();
    
}