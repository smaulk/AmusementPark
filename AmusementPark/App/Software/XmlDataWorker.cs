using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AmusementPark.Interfaces;
using AmusementPark.models;
using AmusementPark.models.attractions;

namespace AmusementPark
{
    public class XmlDataWorker : IDataWorker<AttractionModel>
    {
        private readonly string _filePath;

        public XmlDataWorker(string? filePath)
        {
            filePath ??= "data.xml";
            _filePath = filePath;
        }

        public void WriteData(List<AttractionModel> list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<AttractionModel>));
            using (TextWriter writer = new StreamWriter(_filePath))
            {
                serializer.Serialize(writer, list);
            }
        }

        public List<AttractionModel>? LoadData()
        {
            if (!File.Exists(_filePath))
                throw new FileNotFoundException("Файл с XML данными не найден!", _filePath);

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<AttractionModel>));
                using (TextReader reader = new StreamReader(_filePath))
                {
                    var attractions = (List<AttractionModel>)serializer.Deserialize(reader);
                    return attractions;
                }
            }
            catch (Exception e)
            {
                // Обработка ошибок или логирование
                return null;
            }
        }
    }
}