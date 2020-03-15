using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLook : MonoBehaviour
{
    public GameObject LookPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(LookPoint.transform,this.transform.up);
    }
}
