using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.transform.SetParent(collision.gameObject.transform);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        this.GetComponent<Rigidbody>().isKinematic = true;

        this.GetComponent<BoxCollider>().enabled = false;
    }
}
