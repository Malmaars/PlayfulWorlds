using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShield : MonoBehaviour
{
    public GameObject Shield;
    public GameObject Guns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Shield.SetActive(true);
            Guns.SetActive(false);
        }

        else
        {
            Shield.SetActive(false);
            Guns.SetActive(true);
        }
    }
}
