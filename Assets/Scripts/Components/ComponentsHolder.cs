using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentsHolder
{
    private HashSet<BaseCharacterComponent> _components = new();

    public IReadOnlyCollection<BaseCharacterComponent> Components => _components;

    public void AddComponent(BaseCharacterComponent component)
    {
        _components.Add(component);
    }
    
    public T GetComponent<T>() where T : BaseCharacterComponent
    {
        var component = _components.FirstOrDefault(e => e.GetType() == typeof(T));
        return component as T;
    }
}
