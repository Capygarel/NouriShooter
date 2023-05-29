using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    public int level, changeMaxHP, changeCurrentHP;
    public int ID;
    public GameObject model;
    public float changeReloadTime, changeSpeed, changeshotSpeed, firingRateModifier, damageModifier, rangeModifier;
    public IItem itemBehavior;


}
