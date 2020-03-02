using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public float starSpeed;

    //yhteys fysiikkamoottoriin
    private Rigidbody2D rb2d;

    //efektin julkinen muuttuja
    public GameObject starEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(starSpeed * transform.localScale.x, 0);
    }
    //valmis metodi, joka tutkii törmäyksiä
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            //esim. tähti osuu pelihahmoon 1, joten vähennetään yksi elämä
            FindObjectOfType<GameManager>().HurtP1();
            //osumaäänet ym..
        }
        if (collision.CompareTag("Player2"))
        {
            //esim. tähti osuu pelihahmoon 1, joten vähennetään yksi elämä
            FindObjectOfType<GameManager>().HurtP2();
            //osumaäänet ym..
        }


        //tähden törmäysegekti
        Instantiate(starEffect, transform.position, transform.rotation);

        //osumaääni
        FindObjectOfType<AudioManager>().Play("Impact");

        //tuhotaan ammus törmäyksen jälkeen
        Destroy(gameObject);//kun gameObject on kirjoitettu pienellä, se tarkoittaa ko. objektia, jossa scripti on kiinni
    }
}
