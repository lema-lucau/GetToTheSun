using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUIManager : MonoBehaviour
{
    public Slider health;
    public Text healthDesc;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(health.value <= 0)
        {
            health.enabled = false;
            healthDesc.enabled = false;
        }
        else
        {
           health.enabled = true;
           healthDesc.enabled = true; 
        }
    }
}
