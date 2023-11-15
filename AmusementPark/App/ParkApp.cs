using System;
using AmusementPark.models;

namespace AmusementPark;

public class ParkApp
{
    private Park park { get; }

    public ParkApp(Park park)
    {
        this.park = park;
    }

    public void Run()
    {
        Console.WriteLine();
    }
}