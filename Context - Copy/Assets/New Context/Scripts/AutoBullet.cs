using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : ShootScript
{
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public override void Shoot()
    {
        if (timer > 2)
        {
            if (FreeBullet == true)
            {
                GameObject temp = Instantiate(Bullets, new Vector3(Barrel.transform.position.x, Barrel.transform.position.y, Barrel.transform.position.z), Barrel.transform.rotation, null);
                Rigidbody rb = temp.GetComponent<Rigidbody>();
                rb.AddForce(Pistol.transform.right * ShotSpeed);
            }

            if (FreeBullet == false)
            {
                GameObject temp = Instantiate(Bullets, new Vector3(Barrel.transform.position.x, Barrel.transform.position.y, Barrel.transform.position.z), Barrel.transform.rotation, Pistol.transform);
                Rigidbody rb = temp.GetComponent<Rigidbody>();
                rb.AddForce(Pistol.transform.right * ShotSpeed);
            }

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
