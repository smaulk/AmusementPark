namespace AmusementPark.Interfaces;

//Интерфейс для работы с данными (Запись и загрузка данных)
public interface IDataWorker<T>
{
    void WriteData(List<T> list);
    List<T>? LoadData();
}