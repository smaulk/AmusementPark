using System.Text.Json;
using Newtonsoft.Json;
using AmusementPark.Interfaces;
using AmusementPark.models;
using AmusementPark.models.attractions;

namespace AmusementPark;

public class JsonDataWorker: IDataWorker<AttractionModel>
{
    private readonly string _filePath;

    public JsonDataWorker(string? filePath)
    {
        filePath ??= "data.json";
        _filePath = filePath;
    }
    
    public void WriteData(List<AttractionModel> list)
    {
        var jsonData = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All // Это сохранит информацию о типе объекта
        });
        File.WriteAllText(_filePath, jsonData);
    }

    public List<AttractionModel>? LoadData()
    {
        if (!File.Exists(_filePath))
            throw new PathNotFoundError("Файл с JSON данными не найден!", _filePath);

        try
        {
            var jsonData = File.ReadAllText(_filePath);
            var attractions = JsonConvert.DeserializeObject<List<AttractionModel>>(jsonData, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All // Это позволяет правильно десериализовать объекты разных типов
            });

            return attractions;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}

