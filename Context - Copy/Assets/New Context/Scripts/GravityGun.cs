using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    public Camera MainCamera;
    public float RayDistance;
    public float pickupSpeed = 10;
    public float shotSpeed;

    public Transform guide;

    private GameObject Grabbed;
    private bool gravityBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        GravityShoot();

        if (Input.GetMouseButtonUp(0) && Grabbed != null)
        {
            Grabbed.GetComponent<Rigidbody>().useGravity = gravityBool;
            Grabbed.GetComponent<Rigidbody>().AddForce(MainCamera.transform.forward * shotSpeed * Time.deltaTime * Grabbed.GetComponent<Rigidbody>().mass);
            Grabbed = null;
        }

        if (Grabbed != null)
        {
            Grabbed.transform.position = Vector3.Lerp(Grabbed.transform.position, guide.transform.position, Time.deltaTime * pickupSpeed);
            Grabbed.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Grabbed.GetComponent<Rigidbody>().useGravity = false;
        }

    }

    void GravityShoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCamera.transform.position, MainCamera.transform.forward, out hit, RayDistance))
        {
            Debug.Log(hit.transform.name);
            if(hit.transform.gameObject.GetComponent<Rigidbody>() != null && hit.transform.gameObject.GetComponent<Rigidbody>().isKinematic == false)
            {
                gravityBool = hit.transform.gameObject.GetComponent<Rigidbody>().useGravity;
                Grabbed = hit.transform.gameObject;
            }
        }
    }
}
