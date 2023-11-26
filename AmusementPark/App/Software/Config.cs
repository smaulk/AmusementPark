namespace AmusementPark;

public class Config
{
    public string? LogPath { get; }
    public string? JsonPath { get; }
    public string? XmlPath { get; }

    public Config(string? logPath, string? jsonPath, string? xmlPath)
    {
        this.LogPath = logPath;
        this.JsonPath = jsonPath;
        this.XmlPath = xmlPath;
    }

}