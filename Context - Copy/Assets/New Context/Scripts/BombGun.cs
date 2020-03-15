﻿using UnityEngine;

public class BombGun : ShootScript
{
    // Start is called before the first frame update
    void Start()
    {
        GunPrep();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public override void GunPrep()
    {
        base.GunPrep();
        Bullets = (GameObject)Resources.Load("Prefabs/Bullets/BombBullet", typeof(GameObject));
    }
}
