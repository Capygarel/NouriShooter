using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public ItemData newItemType;
    public List<ItemInstance> items = new List<ItemInstance>();
    void Start()
    {
        items.Add(new ItemInstance(newItemType));
        
    }
}
