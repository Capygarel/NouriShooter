using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    private PlayerController player;

    public PlayerStats modifiedStats;

    public List<IItem> items;

    public List<WeaponInstance> secondaryWeapons;

    public WeaponInstance mainWeapon;
    public WeaponInstance mainWeaponInstance;



    public void SetupInventory()
    {
        items = new List<IItem>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        UpdateModifiedStats();
        if (mainWeapon != null)
            mainWeaponInstance = Instantiate(mainWeapon.gameObject, player.shootingManager.transform).GetComponent<WeaponInstance>();
    }

    public void EquipNewItem(IItem itemtoAdd)
    {
        Debug.Log(itemtoAdd);
        items.Add(itemtoAdd);
        itemtoAdd.AddStatsModifiers(modifiedStats);
    }

    public void DropLastItem()
    {
        if (items.Count > 0)
        {
            InstanceItemContainer toDrop = items[items.Count - 1].GetComponent<InstanceItemContainer>();
            toDrop.item.RemoveStatsModifiers(modifiedStats);
            toDrop.DropItem(player.gameObject);
            items.RemoveAt(items.Count - 1);
        }
    }

    public int IsItemInInventory(IItem toSearch)
    {
        for (int i = 0; i < items.Count; i++)
            if (toSearch.itemType.ID == items[i].itemType.ID) return i;
        return -1;

    }

    public void UpgradeItem(int itemIndex)
    {
        items[itemIndex].UpgradeItem(modifiedStats);
    }

    public void UpdateModifiedStats()
    {

        modifiedStats.CopyStats(player.stats);
        for (int i = 0; i < items.Count; i++)
        {
            items[i].AddStatsModifiers(modifiedStats);
        }
        Debug.Log(modifiedStats.CurrentHP);
    }

    public void applyEffects( )
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].Effect();
        }
    }
}
