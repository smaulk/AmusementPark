using System;

namespace AmusementPark;

public class ConsoleManager
{


    public void RenderMenu(string[] menuItems)
    {
        for (int i = 1; i <= menuItems.Length; i++)
        {
            Console.WriteLine(i + ". " + menuItems[i-1]);
        }
    }
}