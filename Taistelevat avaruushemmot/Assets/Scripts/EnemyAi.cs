using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed;
    private Rigidbody2D rb2D;
    private Transform trans;
    private float enemyWidth;

    // Start is called before the first frame update
    void Start()
    {
        trans = transform;
        rb2D = GetComponent<Rigidbody2D>();
        enemyWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tarkistetaan onko edessä maata eli onko isGrounded = true
        Vector2 lineCastPos = trans.position - trans.right * enemyWidth;
        Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos + Vector2.down, enemyMask);

        //tarkistetaan onko edessä este
        Debug.DrawLine(lineCastPos, lineCastPos - Vector2.right * 0.02f);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos - Vector2.right * 0.02f, enemyMask);

        //loppuiko maa tai onko edessä este
        if(!isGrounded || isBlocked)
        {
            //kyllä, joten vaihdetaan suuntaa
            Vector2 currRot = trans.eulerAngles;
            currRot.y += 180;
            trans.eulerAngles = currRot;
        }
        //aina kuljetaan eteenpäin
        Vector2 enemyVelocity = rb2D.velocity;      //vihollisen nopeusvektori
        enemyVelocity.x = -trans.right.x * speed;   //punainen akseli
        rb2D.velocity = enemyVelocity;
    }
}
