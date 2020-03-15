using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject DeathScreen;
    StateManager MrState;
    // Start is called before the first frame update
    void Start()
    {
        MrState = GameObject.FindObjectOfType<StateManager>();
        DeathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        updateHearts();

        if(MrState.lifePoints <= 0)
        {
            DeathScreen.SetActive(true);
        }
    }

    void updateHearts()
    {
        int i = 0;
        foreach (Transform heart in transform)
        {
            if (i + 1 <= MrState.lifePoints)
                heart.gameObject.SetActive(true);
            else
                heart.gameObject.SetActive(false);
            i++;
        }
    }
}
