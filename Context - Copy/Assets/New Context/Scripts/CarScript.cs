using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : Bullet
{
    public float force;
    public float radius;
    public GameObject explosionEffect;

    public float driveSpeed;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Remove();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (this.transform.localScale.x < 1)
        this.transform.localScale = new Vector3(Mathf.Lerp(this.transform.localScale.x, 1f, 8f * Time.deltaTime), Mathf.Lerp(this.transform.localScale.y, 1f, 8f * Time.deltaTime), Mathf.Lerp(this.transform.localScale.z, 1f, 8f * Time.deltaTime));

        if(isGrounded)
        this.GetComponent<Rigidbody>().velocity = this.transform.forward * 20;

        if(lifeTimer > 5)
        {
            Explode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.gameObject.layer != 9)
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }

        Destroy(this.gameObject);
    }
}
