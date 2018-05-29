using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Projectile;

    public GunScriptable values;
    public Transform Muzzle;

    public float AmmoReady;
    public float AmmoInMagazine;
    public float MaxAmmoStored;

    public void Awake()
    {
        AmmoReady = values.AmmoReady;
        AmmoInMagazine = values.AmmoInMagazine;
        MaxAmmoStored = values.MaxAmmoStored;
    }

    public void Shoot()
    {
        if (Projectile == null)
            return;
        
        Instantiate(Projectile, Muzzle.transform.position, Muzzle.transform.rotation);
    }
}
