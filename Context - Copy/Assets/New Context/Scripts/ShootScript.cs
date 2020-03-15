using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject Bullets;
    public Transform Barrel;

    public int ShotSpeed;

    public GameObject Pistol;

    public bool FreeBullet = true;
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

    public virtual void Shoot()
    {
        if (Bullets != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (FreeBullet == true)
                {
                    GameObject temp = Instantiate(Bullets, new Vector3(Barrel.transform.position.x, Barrel.transform.position.y, Barrel.transform.position.z), Barrel.transform.rotation, null);
                    Rigidbody rb = temp.GetComponent<Rigidbody>();
                    rb.AddForce(Pistol.transform.forward * ShotSpeed);
                }

                if (FreeBullet == false)
                {
                    GameObject temp = Instantiate(Bullets, new Vector3(Barrel.transform.position.x, Barrel.transform.position.y, Barrel.transform.position.z), Barrel.transform.rotation, Pistol.transform);
                    Rigidbody rb = temp.GetComponent<Rigidbody>();
                    rb.AddForce(Pistol.transform.forward * ShotSpeed);
                }
            }
        }
    }

    public virtual void GunPrep()
    {
        Pistol = this.transform.gameObject;
        Barrel = gameObject.transform.Find("Barrel").transform;
    }
}
