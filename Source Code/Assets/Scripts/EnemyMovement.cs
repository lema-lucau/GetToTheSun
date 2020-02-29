using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    public float agroRange;

    [SerializeField]
    public float speed;

    Rigidbody2D rigid2d;

    public Animator animator;
    

    // Update is called once per frame
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //distance to the player
        float distancePlayer = Vector2.Distance(transform.position, player.position);


        animator.SetFloat("Speed", speed);

        if (distancePlayer < agroRange)
        {
            //chase code
            ChasePlayer();
        }
        else if (distancePlayer > agroRange)
        {
            //stop chasing player
            EndChasePlayer();
        }

    }

    void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //moves right
            rigid2d.velocity = new Vector2(speed, rigid2d.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            //moves left
            rigid2d.velocity = new Vector2(-speed, rigid2d.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
    }

    void EndChasePlayer()
    {
        rigid2d.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.tag == "Jump")
        {
            rigid2d.AddForce(Vector2.up * 500f);
        }

    }

    

}
