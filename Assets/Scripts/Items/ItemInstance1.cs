using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInstance1 : IItem
{

    public ItemInstance1(ItemData itemData, Vector3 position)
    {
        itemType = itemData;
        
    }

    public override void Effect()
    {
        changeMaxHP++;

    }

    public override void UndoEffect()
    {

    }
}

