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
    public float damage;
    public float cooldown;
    public GameObject model;
    public float changeReloadTime, changeMaxHP, changeSpeed, changeshotSpeed, firingRateModifier, damageModifier, rangeModifier;


}
