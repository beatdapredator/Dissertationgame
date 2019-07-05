using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    private float nextState;
    public float stateswitchSpeed;
    public float meleeProbibility;
    public float rangeProbability;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextState)
        {
            nextState = Time.time + stateswitchSpeed;
            float rand = Random.Range(0.0f, 1.0f);
            if (rand < meleeProbibility)
            {
                GetComponent<Melee>().enabled = true;
                GetComponent<Ranged>().enabled = false;
                GetComponent<Hedgehog>().enabled = false;
            }
            else if (rand - meleeProbibility < rangeProbability)
            {
                GetComponent<Ranged>().enabled = true;
                GetComponent<Melee>().enabled = false;
                GetComponent<Hedgehog>().enabled = false;
            }
            else 
            {
                GetComponent<Hedgehog>().enabled = true;
                GetComponent<Ranged>().enabled = false;
                GetComponent<Melee>().enabled = false;
            }

        }
    }
}
