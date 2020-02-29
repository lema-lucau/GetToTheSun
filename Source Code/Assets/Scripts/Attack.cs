using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public LayerMask onlyEnemies;
    public Transform attackPosL;
    public Transform attackPosR;

    public float attackRangeX;
    public float attackRangeY;
    //public float damage = 0.1f;

    public static bool facingRight = true;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //Movement
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                facingRight = true;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                facingRight = false;
            }

            //allow player to atack
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] damageEnemiesL = Physics2D.OverlapBoxAll(attackPosL.position, new Vector2(attackRangeX, attackRangeY), 0, onlyEnemies);

                Collider2D[] damageEnemiesR = Physics2D.OverlapBoxAll(attackPosR.position, new Vector2(attackRangeX, attackRangeY), 0, onlyEnemies);

                for (int i = 0; i < damageEnemiesL.Length; i++)
                {
                    if (facingRight == false)
                    {
                        damageEnemiesL[i].GetComponent<DamageEnemyTest>().takeDamage();
                    }
                }   

                for (int i = 0; i < damageEnemiesR.Length; i++)
                {
                    if (facingRight == true)
                    {
                        damageEnemiesR[i].GetComponent<DamageEnemyTest>().takeDamage();
                    }
                }

                timeBtwAttack = startTimeBtwAttack;
                animator.SetBool("Attack",true);
                FindObjectOfType<AudioManager>().Play("SwingSword");
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            animator.SetBool("Attack", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPosL.position, new Vector3(attackRangeX, attackRangeY, 1));
        Gizmos.DrawWireCube(attackPosR.position, new Vector3(attackRangeX, attackRangeY, 1));
    }
}
