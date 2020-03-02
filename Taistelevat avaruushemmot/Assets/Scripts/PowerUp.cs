using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            FindObjectOfType<GameManager>().PowerUpP1(1);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Player2"))
        {
            FindObjectOfType<GameManager>().PowerUpP2(1);
            Destroy(gameObject);
        }
    }
}
