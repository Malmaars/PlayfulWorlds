using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelBall : MonoBehaviour
{
    public GameObject Player;
    public float ShotSpeed;
    private Rigidbody rb;

    Vector3 oldPos;
    public Transform GunLoc;
    public Transform curvePoint;
    private bool isReturning = false;
    private float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.transform.parent != null)
        {
            Throw();
        }

        if (Input.GetMouseButtonDown(2))
        {
            ReturnBall();
        }

        if (isReturning)
        {
            if(time < 1.0f)
            {
                this.transform.position = getBQCPoint(time, oldPos, curvePoint.position, GunLoc.position);
                time += Time.deltaTime *2;
            }
            else
            {
                ResetBall();
            }
        }
    }

    void Throw()
    {
        rb.isKinematic = false;
        rb.AddForce(Player.transform.forward * ShotSpeed);
        this.transform.parent = null;
    }

    void ReturnBall()
    {
        oldPos = this.transform.position;
        isReturning = true;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }

    void ResetBall()
    {
        isReturning = false;
        this.transform.parent = Player.transform;
        this.transform.position = GunLoc.transform.position;
        this.transform.rotation = GunLoc.transform.rotation;
        time = 0.0f;
    }

    Vector3 getBQCPoint (float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = (uu * p0) + (2 * u * t * p1) + (tt * p2);
        return p;
    }
}
