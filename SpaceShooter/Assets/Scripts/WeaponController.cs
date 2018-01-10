﻿using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;

    void Start ()
    {
        InvokeRepeating ("Fire", delay, fireRate);
    }

    void Fire ()
    {
        Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
    }
}