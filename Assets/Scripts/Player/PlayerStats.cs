using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{



    //Character Stats
    [SerializeField]
    private float speed, luckModifier, dodgeChance, blockChance, pickupRange, xpMultiplier;
    [SerializeField]
    private int currentHP, maxHP, level;
    //Global Weapon Modifier
    [SerializeField]
    private float reloadModifier, shotSpeedModifier, firingRateModifier, damageModifier, rangeModifier;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSpeed(float modifier) { speed += modifier; }
    public void ChangeLuck(float modifier) { luckModifier += modifier; }
    public void ChangeDodgeChance(float modifier) { dodgeChance += modifier; }
    public void ChangeBlockChance(float modifier) { blockChance += modifier; }
    public void ChangePickupRange(float modifier) { pickupRange += modifier; }
    public void ChangeXpMultiplier(float modifier) { xpMultiplier += modifier; }
    public void ChangeReloadModifie(float modifier) { reloadModifier += modifier; }
    public void ChangeShotSpeedModifier(float modifier) { shotSpeedModifier += modifier; }
    public void ChangeFiringRateModifier(float modifier) { firingRateModifier += modifier; }
    public void ChangeDamageModifier(float modifier) { damageModifier += modifier; }
    public void ChangeRangeModifier(float modifier) { rangeModifier += modifier; }
    public void ChangeCurrentHP(int modifier) { currentHP += modifier; }
    public void ChangeMaxHP(int modifier) { maxHP += modifier; }
    public void ChangeLevel(int modifier) { level += modifier; }

    public float Speed { get => speed; set => speed = value; }
    public float LuckModifier { get => luckModifier; set => luckModifier = value; }
    public float DodgeChance { get => dodgeChance; set => dodgeChance = value; }
    public float BlockChance { get => blockChance; set => blockChance = value; }
    public float PickupRange { get => pickupRange; set => pickupRange = value; }
    public float XpMultiplier { get => xpMultiplier; set => xpMultiplier = value; }
    public float ReloadModifier { get => reloadModifier; set => reloadModifier = value; }
    public float ShotSpeedModifier { get => shotSpeedModifier; set => shotSpeedModifier = value; }
    public float FiringRateModifier { get => firingRateModifier; set => firingRateModifier = value; }
    public float DamageModifier { get => damageModifier; set => damageModifier = value; }
    public float RangeModifier { get => rangeModifier; set => rangeModifier = value; }
    public int CurrentHP { get => currentHP; set => currentHP = value; }
    public int MaxHP { get => maxHP; set => maxHP = value; }
    public int Level { get => level; set => level = value; }
}
