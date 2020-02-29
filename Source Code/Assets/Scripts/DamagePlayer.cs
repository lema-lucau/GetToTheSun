using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public bool IsDamage = false;

    private void Start()
    {
        InvokeRepeating("Damage", 1f, 1f);
    }

    void Damage()
    {
        if (IsDamage == true)
        {
            GameLogicScript.health--;
            FindObjectOfType<AudioManager>().Play("PlayerHit");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.collider.tag == "Player")
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
