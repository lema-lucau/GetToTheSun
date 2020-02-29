using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamagePlayer : MonoBehaviour
{
    public bool IsDamage = false;

    private void Start()
    {
        InvokeRepeating("Damage", 0.1f, 0.5f);
    }

    void Damage()
    {
        if (IsDamage == true)
        {
            GameLogicScript.health--;
            FindObjectOfType<AudioManager>().Play("Fire");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.tag == "Player")
        {
            IsDamage = true;
        }

    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Player")
        {
            IsDamage = false;
        }
    }
}
