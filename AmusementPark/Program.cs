using AmusementPark;
using AmusementPark.models;
using AmusementPark.models.attractions;

namespace AmusementPark;

class Program
{


    public static void Main()
    {
        Park park = new Park("Парк дружбы", "г. Челябинск, ул. Ленина 120", "08:00 - 20:00");

        var attractions = new AttractionModel[]
        {
            new Carousel(AttractionType.ForChildren, "Карусель веселья", 150, 4, 10, 5, true, "Лошадка"),
            new Carousel(AttractionType.Extreme, "Круговорот", 280, 14, 20, 4, false, "Кресло"),
            new Carousel(AttractionType.Entertainment, "Полет птицы", 250, 10, 25, 8, false, "Кабинка"),
            new FerrisWheel("Вершина мира", 300, 10, 120, 15, 120, 6),
            new FerrisWheel("Колесо любви", 240, 10, 60, 10, 80, 5),
            new GoKart("Космические гонки", 500, 14, 20, 10, 5, 800, 40),
            new HorrorMaze("Зов тьмы", 420, 14, 15, 20, "Призраки", 6),
            new HorrorMaze("Адский путь", 440, 18, 15, 25, "Демоны", 8),
            new MiniGolf("Мини-гольф", 390, 8, 12, 30, 10, "газон"),
            new RollerCoaster("Дорога страха", 380, 16, 25, 6, 800, 60, 2),
            new ShootingRange("Стрелок", 280, 10, 10, 10, 8, "ружье"),
            new ShootingRange("Ковбой", 280, 10, 8, 10, 6, "револьвер")
        };
        park.AddAttraction(attractions);

        var visitors = new Visitor[]
        {
            new Visitor("Иван", 10),
            new Visitor("Мария", 14),
            new Visitor("Дмитрий", 20),
            new Visitor("Александр", 12),
            new Visitor("Алексей", 16),
            new Visitor("Анастасия", 6),
            new Visitor("Владимир", 18),
            new Visitor("Дарья", 31),
            new Visitor("Николай", 35),
            new Visitor("Никита", 8),
            new Visitor("Наталья", 21),
        };
        park.AddVisitor(visitors);
        
        ParkApp app = new ParkApp(park);
        app.Run();
    }
}