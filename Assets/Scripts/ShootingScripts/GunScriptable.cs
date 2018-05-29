using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GunValues", menuName = "GunAsset")]
public class GunScriptable : ScriptableObject
{
    //ammo
    //time to shoot
    public float Rateo;
    //ammo that can be shoot
    [SerializeField]
    private float ammoReady;
    public float AmmoReady { get { return ammoReady; } }
    //ammo in each magazine
    [SerializeField]
    private float ammoInMagazine;
    public float AmmoInMagazine { get { return ammoInMagazine; } }
    //max ammo that can be stored
    [SerializeField]
    private float maxAmmoStored;
    public float MaxAmmoStored { get { return maxAmmoStored; } }

    //range
    //muzzle error
    [SerializeField]
    private float range;
    public float Range { get { return range; } }
    //max projectile run
    [SerializeField]
    private float maxDistance;
    public float MaxDistance { get { return maxDistance; } }

    //speed
    //projectile speed
    [SerializeField]
    private float speed;

    public float Speed { get { return speed; } }

    //effect
    //shootEffect
    public ParticleSystem shootParticle;
    //wall effect
    public ParticleSystem wallParticle;
    //blood effect
    public ParticleSystem bloodParticles;

    //gun type
    [Range(0, 10)]
    [SerializeField]
    private int gunSystem;

    public int GunSystem { get { return gunSystem; } }

    //Damage
    [SerializeField]
    private float damage;

    public float Damage { get { return damage; } }
}
