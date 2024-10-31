using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObservableInt
{
    private int _value;
    public event Action<int> OnValueChanged;
    public int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
    public ObservableInt(int initialValue = 0)
    {
        _value = initialValue;
    }
}

public class ResourceBank : MonoBehaviour
{
    public Dictionary<GameResource, ObservableInt> resources = new Dictionary<GameResource, ObservableInt>();
    private void Awake()
    {
        resources.Add(GameResource.Humans, new ObservableInt(0));
        resources.Add(GameResource.Food, new ObservableInt(0));
        resources.Add(GameResource.Wood, new ObservableInt(0));
        resources.Add(GameResource.Stone, new ObservableInt(0));
        resources.Add(GameResource.Gold, new ObservableInt(0));

        resources.Add(GameResource.HumansProdLvl, new ObservableInt(1));
        resources.Add(GameResource.FoodProdLvl, new ObservableInt(1));
        resources.Add(GameResource.WoodProdLvl, new ObservableInt(1));
        resources.Add(GameResource.StoneProdLvl, new ObservableInt(1));
        resources.Add(GameResource.GoldProdLvl, new ObservableInt(1));
    }
    public void ChangeResource(GameResource r, int v)
    {
        if (resources.ContainsKey(r))
        {
            resources[r].Value += v;
        }
    }
    public ObservableInt GetResource(GameResource r)
    {
        if (resources.ContainsKey(r))
        {
            return resources[r];
        }
        else
        {
            return null;
        }
    }
}


