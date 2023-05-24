using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance : IItem
{

    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
        
    }

    public new void Effect()
    {

    }

    public new  void UndoEffect()
    {

    }
}

