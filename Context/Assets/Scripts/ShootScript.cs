using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject Bullets;
    public Transform Barrel;

    public int ShotSpeed;

    public GameObject Pistol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject temp = Instantiate(Bullets, new Vector3(Barrel.transform.position.x, Barrel.transform.position.y, Barrel.transform.position.z), Barrel.transform.rotation, Pistol.transform);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.AddForce(Pistol.transform.forward * ShotSpeed * Time.deltaTime);
        }
        
    }
}
