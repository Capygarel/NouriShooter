using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{

    public ItemData itemData;
    public int ammo, maxAmmo;
    public AudioClip shootingSound;
    public float volumeScale;
    public float  reloadTime, firingRate, damage, range, shotSpeed;
    public GameObject projectilePrefab;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
