using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binscript : MonoBehaviour
{
    public GameObject spawnObject;

    public Transform spawnLoc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Instantiate(spawnObject, spawnLoc.transform.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
