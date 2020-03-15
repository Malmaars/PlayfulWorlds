using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleBullet : Bullet
{
    public float radius = 20f;

    public float force = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Remove();

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject != this.gameObject.GetComponent<SphereCollider>())
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.GetComponent<Rigidbody>() != null && other.gameObject.GetComponent<Rigidbody>().isKinematic == true)
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.GetComponent<Rigidbody>() != null && other.gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            GameObject temp = other.gameObject;
            while(temp.transform.parent != null)
            {
                temp = temp.gameObject.transform.parent.gameObject;
            }

            Destroy(temp.gameObject);
        }
    }
}
