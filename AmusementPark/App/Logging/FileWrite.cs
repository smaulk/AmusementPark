namespace AmusementPark.Logging;

public class FileWrite
{
    private readonly string _filePath;
    
    public FileWrite(string? filePath)
    {
        filePath ??= "data.json";
        _filePath =  filePath;
        if (!File.Exists(filePath))
            File.Create(filePath).Close();
        
    }

    public void WriteToFile(string message)
    {
        using var writer = new StreamWriter(_filePath, true);
        writer.WriteLine(message);
    }
}