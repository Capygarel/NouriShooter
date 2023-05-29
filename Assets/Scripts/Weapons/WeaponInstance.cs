using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInstance : IItem
{

    public WeaponData data;

    public int currentAmmo;
    public float modifiedFireRate, modifiedDamage, modifiedRange, modifiedShotSpeed, modifiedReloadTime;
    // Start is called before the first frame update
    void Start()
    {
        modifiedReloadTime = data.reloadTime;
        modifiedShotSpeed = data.shotSpeed;
        modifiedRange = data.range;
        modifiedDamage = data.damage;
        modifiedFireRate = data.firingRate;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(float reloadModifier,float shotSpeedModifier, float firingRateModifier, float damageModifier, float rangeModifier)
    {
        SoundManager.Instance.PlaySound(data.shootingSound, data.volumeScale);
        modifiedFireRate += firingRateModifier;
        modifiedDamage += damageModifier;
        modifiedRange += rangeModifier;
        modifiedShotSpeed += shotSpeedModifier;
        modifiedReloadTime += reloadModifier;

        GameObject currentProjectile = Instantiate(data. projectilePrefab, transform.position, transform.rotation);
        currentProjectile.GetComponent<ProjectileController>().Set(modifiedShotSpeed, modifiedDamage, modifiedRange, transform.position);
        modifiedFireRate -= firingRateModifier;
        modifiedDamage -= damageModifier;
        modifiedRange -= rangeModifier;
        modifiedShotSpeed -= shotSpeedModifier;
        modifiedReloadTime -= reloadModifier;
    }
}
