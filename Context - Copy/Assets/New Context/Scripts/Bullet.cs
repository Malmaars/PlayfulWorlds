using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTimer;
    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Remove();
    }

    public virtual void Remove()
    {
        lifeTimer += Time.deltaTime;
        if(lifeTimer > 10)
        {
            Destroy(this.gameObject);
        }
    }
}
