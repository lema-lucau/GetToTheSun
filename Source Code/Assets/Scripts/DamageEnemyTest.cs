using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEnemyTest : MonoBehaviour
{
    private Rigidbody2D rb2d;
    EnemyMovement enemyMovementScript;
    public Animator animator;

    public float knockbackForce;
    public float knockbackTime;
    public float knockbackCount;

    public float maxHealth;
    public float currentHealth;
    public float damageTaken;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyMovementScript = GetComponent<EnemyMovement>();
        rb2d = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        healthBar.value = calculateHealth();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage()
    {
        enemyMovementScript.enabled = false;
        knockbackEnemy();
        currentHealth -= damageTaken;
        FindObjectOfType<AudioManager>().Play("EnemyHit");
        healthBar.value = calculateHealth();
        if(currentHealth <= 0)
        {
            Die();
        }
        else 
        {
            this.gameObject.SetActive(true);
        }

        Debug.Log(this.gameObject.name + " took " + damageTaken + " damage");
    }
    
    void knockbackEnemy()
    {
        if(Attack.facingRight == true)
        {
            //knock enemy back towards the right
            rb2d.velocity = new Vector2(knockbackForce, knockbackForce/2);
        }
        
        if(Attack.facingRight == false)
        {
            //knock enemy back towards the left
            rb2d.velocity = new Vector2(-knockbackForce, knockbackForce/2);
        }

        StartCoroutine(stunEnemy());
    }

    float calculateHealth()
    {
        return currentHealth / maxHealth;
    }

    private IEnumerator stunEnemy()
    {
        yield return new WaitForSeconds(knockbackTime);

        enemyMovementScript.enabled = true;
    }

    void Die()
    {
        Debug.Log(this.gameObject.name + " died");
        this.gameObject.SetActive(false);
        GameScore.AddScore((int)maxHealth * 10);
        FindObjectOfType<AudioManager>().Play("EnemyDie");
    }
}
