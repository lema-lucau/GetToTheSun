using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTime : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0f;
    }
}
