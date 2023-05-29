using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public  class IItem : MonoBehaviour
{
    public ItemData itemType;
    public int level, indexInventory, changeMaxHP, changeCurrentHP;
    //private bool setup = false;
    public float changeReloadTime, changeSpeed, changeshotSpeed, firingRateModifier, damageModifier, rangeModifier;
    [SerializeField]private bool setup = false;
    private void Start()
    {

    }

    public void Setup()
    {
        changeReloadTime = itemType.changeReloadTime;
        changeMaxHP = itemType.changeMaxHP;
        changeSpeed = itemType.changeSpeed;
        changeshotSpeed = itemType.changeshotSpeed;
        firingRateModifier = itemType.firingRateModifier;
        changeCurrentHP = itemType.changeCurrentHP;
        damageModifier = itemType.damageModifier;
        rangeModifier = itemType.rangeModifier;
        setup = true;
    }

    public void OneShotEffect()
    {
        changeReloadTime += itemType.changeReloadTime;
        changeMaxHP += itemType.changeMaxHP;
        changeCurrentHP += itemType.changeCurrentHP;
        changeSpeed += itemType.changeSpeed;
        changeshotSpeed += itemType.changeshotSpeed;
        firingRateModifier += itemType.firingRateModifier;
        damageModifier += itemType.damageModifier;
        rangeModifier += itemType.rangeModifier;

    }

    public void UpgradeItem(PlayerStats modifiedStats)
    {
        level++;
        AddStatsModifiers(modifiedStats);
    }

    public virtual void Effect() {

    }

    public IItem GetInstance()
    {
        return this;
    }

    public void AddStatsModifiers(PlayerStats modifiedStats)
    {
        if (!setup) Setup();
        modifiedStats.ChangeReloadModifier(changeReloadTime);
        modifiedStats.ChangeMaxHP(changeMaxHP);
        modifiedStats.ChangeCurrentHP(changeCurrentHP);
        modifiedStats.ChangeSpeed(changeSpeed);
        modifiedStats.ChangeShotSpeedModifier(changeshotSpeed);
        modifiedStats.ChangeFiringRateModifier(firingRateModifier);
        modifiedStats.ChangeDamageModifier(damageModifier);
        modifiedStats.ChangeRangeModifier(rangeModifier);

    }

    public void RemoveStatsModifiers(PlayerStats modifiedStats)
    {
        modifiedStats.ChangeReloadModifier(-changeReloadTime);
        modifiedStats.ChangeMaxHP(-changeMaxHP);
        modifiedStats.ChangeCurrentHP(-changeCurrentHP);
        modifiedStats.ChangeSpeed(-changeSpeed);
        modifiedStats.ChangeShotSpeedModifier(-changeshotSpeed);
        modifiedStats.ChangeFiringRateModifier(-firingRateModifier);
        modifiedStats.ChangeDamageModifier(-damageModifier);
        modifiedStats.ChangeRangeModifier(-rangeModifier);
    }

    public virtual void UndoEffect() { }
}


