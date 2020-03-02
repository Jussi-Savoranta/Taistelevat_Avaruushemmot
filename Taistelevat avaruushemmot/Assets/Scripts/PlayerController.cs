using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //pelihahmon nopeus x-akselin suunnassa
    public float moveSpeed;

    //hyppyvoima y-akselin suunnassa
    public float jumpForce;

    //näppäinmuuttujat
    [Header("Näppäimet")]
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode shootStar;

    //yhteys fysiikkamoottoriin eli rigidbodyyn
    private Rigidbody2D rb2d;

    //hyppyyn liittyvät muuttujat
    [Header("Hyppy")]
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    //jos isGround on 'true', niin objekti on maassa
    public bool isGround;

    //Animaattorin määritys
    private Animator anim;

    //Ampumisen muuttujat
    [Header ("Ampuminen")]
    public Transform shootingPoint;      //ampumispiste
    public GameObject star;             //se mikä ammutaan

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheckPoint.position,
            groundCheckRadius,
            whatIsGround);

        //pelihahmon liikuttelu
        MovePlayer();

        Shoot();

        //Animaatiot: juoksu ja hyppy
        Animation();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(shootStar))
        {
            //synnyttää tähden
            GameObject starClone = Instantiate(star, 
                shootingPoint.position, shootingPoint.rotation);
            //laittaa tähden menemään samaan suuntaan kuin pelaaja
            starClone.transform.localScale = transform.localScale;
            //ääni ampumiselle
            FindObjectOfType<AudioManager>().Play("Shoot");
        }
    }

    void MovePlayer()
    {
        //Pelihahmon liike
        if (Input.GetKey(left))
        {
            //jos true, niin liikutaan vasemmalle
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
            //pelihahmon suunta on vasemmalle
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Input.GetKey(right))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            //pelihahmon suunta on oikealle
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }
        //pelihahmon hyppy. Hahmo voi hypätä, vain kun hahmo on maassa.
        if (Input.GetKeyDown(jump) && isGround)
        {
            //pelihahmo hyppää
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    void Animation()
    {
        //Kävelyanimaatiokutsu
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        //hypppyanimaatiokutsu
        anim.SetBool("Grounded", isGround);
    }
    
}