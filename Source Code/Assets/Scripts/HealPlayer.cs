using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.tag == "Player")
        {
            if(GameLogicScript.health < 6)
            {
                GameLogicScript.health += 2;
            }
            else
            {
                GameScore.AddScore(100);
            }
            this.gameObject.SetActive(false);
        }
        FindObjectOfType<AudioManager>().Play("Heart");

    }
}
