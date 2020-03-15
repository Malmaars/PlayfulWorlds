using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGetsHit : MonoBehaviour
{
    public GameObject Root;
    public GameObject hips;
    // Start is called before the first frame update
    void Start()
    {
        Root.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            foreach (Collider c in this.gameObject.GetComponents<BoxCollider>())
            {
                c.enabled = false;
            }
            Root.SetActive(true);

            hips.GetComponent<Rigidbody>().velocity = collision.rigidbody.velocity;
        }
    }
}
