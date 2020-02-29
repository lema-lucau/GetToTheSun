using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float knockbackForce = 2f;
    public static float healthAmount;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        healthAmount = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    public void takeDamage(float damage)
    {
        //knockbackEnemy();
        if(healthAmount > 0)
        {
            healthAmount -= damage;
        }
        else if(healthAmount < 0)
        {
            healthAmount = 0;
        }
        Debug.Log("Damage taken: -" + damage + " health");
    }
    
    void knockbackEnemy()
    {
        //knock enemy back towards the right
        rb2d.velocity = new Vector2(knockbackForce, rb2d.velocity.y);
    }
}
