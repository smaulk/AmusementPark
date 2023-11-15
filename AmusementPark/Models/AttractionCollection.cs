using System.Collections;

namespace AmusementPark.models;

//Ограничение, что T должен быть наследником или самим классом AttractionModel
public class AttractionCollection<T> : IEnumerable<T> where T : AttractionModel
{
    private List<T> list;   
    

    public AttractionCollection()
    {
        list = new List<T>();
    }
    
    public int Count => list.Count;
    
    public void Add(T item)
    {
        list.Add(item);
    }
    
    public void Clear()
    {
        list.Clear();
    }
    
    public bool Contains(T item)
    {
        return list.Contains(item);
    }
    
    public bool Remove(T item)
    {
        return list.Remove(item);
    }
    
    public T? Find(Func<T, bool> predicate)
    {
        return list.FirstOrDefault(predicate);
    } 
    
    
    public IEnumerator<T> GetEnumerator()
    {
        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}