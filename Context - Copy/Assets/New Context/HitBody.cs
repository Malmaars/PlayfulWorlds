using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBody : MonoBehaviour
{
    StateManager MrState;
    // Start is called before the first frame update
    void Start()
    {
        MrState = GameObject.FindObjectOfType<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            MrState.lifePoints -= 1;
        }
    }
}
