using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AmusementPark.Logging;
using AmusementPark.Interfaces;

namespace AmusementPark.models;

//Ограничение, что T должен быть наследником или самим классом AttractionModel
public class AttractionCollection<T> : IEnumerable<T> where T : AttractionModel
{
    private List<T> _list;
    
    public AttractionCollection()
    {
        _list = new List<T>();
    }
    
    public int Count => _list.Count;
    
    public void Add(T item)
    {
        _list.Add(item);
    }
    
    public void Clear()
    {
        _list.Clear();
    }
    
    public bool Contains(T? item)
    {
        return _list.Contains(item);
    }
    
    public bool Remove(T? item)
    {
        return _list.Remove(item);
    }
    
    public T? Find(Func<T, bool> predicate)
    {
        return _list.FirstOrDefault(predicate);
    }


    public void Sort(Func<T, T, int> comparison)
    {
        _list.Sort((x, y) => Compare(x,y, comparison));
    }

    public int Compare(T item1, T item2, Func<T, T, int> comparison)
    {
        return comparison(item1, item2);
    }

    public void WriteData(IDataWorker<T> dataWorker)
    {
        dataWorker.WriteData(_list);
    }

    public bool LoadData(IDataWorker<T> dataWorker)
    {
        List<T>? newList = dataWorker.LoadData();
        if (newList == null) return false;
        _list.AddRange(newList);
       return true;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}