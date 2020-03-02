using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //pelihahmot
    public GameObject player1;
    public GameObject player2;

    //pelihahmon kokonaiselämä
    public int P1Life;
    public int P2Life;

    //game over paneelit
    public GameObject p1Wins;
    public GameObject p2Wins;

    //päiden pudotus, taulukkoon talletetaan kuvat
    //jotka mallintavat pelihahmon elämää
    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;

    //lipun suojacolliderit
    public GameObject flagGreenCollider;
    public GameObject flagYellowCollider;

    public int powerUp;

    // Update is called once per frame
    void Update()
    {
        //onko pelihahmo 1 kuollut
        if (P1Life <= 0)
        {
            //kyllä on, joten pelihahmo 2 voitti.
            //poistetaan pelihahmo 1
            player1.SetActive(false);
            p2Wins.SetActive(true);
            //plus ääniä efektejä ym.

            //aktivoidaan pelihahmon 1 lippu, eli poistaa suojacolliderin
            flagGreenCollider.SetActive(false);

        }
        if (P2Life <= 0)
        {
            player2.SetActive(false);
            p1Wins.SetActive(true);

            flagYellowCollider.SetActive(false);
        }
    }
    //aiheutetaan vahinkoa (tähti osuu pelihahmoon) pelihahmolle 1
    //poistetaan yksi naama canvaksesta
    public void HurtP1()
    {
        //vähennetään yksi elämä
        P1Life --;
        //tiputetaan yksi pää
        //silmukka, joka käy läpi taulukkoa
        //ja poistetaan viimeinen
        //i saa arvot 0,1,2,3,4
        for (int i = 0; i < p1Sticks.Length; i++)
        {
            //kuva i näytetään, jos p1life on suurempi kuin 1
            if (P1Life>i)
            {
                p1Sticks[i].SetActive(true);//taulukon i:s kuva näytetään
            }
            else
            {
                p1Sticks[i].SetActive(false);//taulukon i:s kuva piilotetaan
            }
        }
    }
    public void HurtP2()
    {
        //vähennetään yksi elämä
        P2Life--;
        //tiputetaan yksi pää
        //silmukka, joka käy läpi taulukkoa
        //ja poistetaan viimeinen
        //i saa arvot 0,1,2,3,4
        for (int i = 0; i < p2Sticks.Length; i++)
        {
            //kuva i näytetään, jos p1life on suurempi kuin 1
            if (P2Life > i)
            {
                p2Sticks[i].SetActive(true);//taulukon i:s kuva näytetään
            }
            else
            {
                p2Sticks[i].SetActive(false);//taulukon i:s kuva piilotetaan
            }
        }
    }
    public void PowerUpP1(int powerUp)
    {
        //lisätään yksi elämä
        if (P1Life < 5)
        {
            P1Life += powerUp;
            //tiputetaan yksi pää
            //silmukka, joka käy läpi taulukkoa
            //ja poistetaan viimeinen
            //i saa arvot 0,1,2,3,4
            for (int i = 0; i < p1Sticks.Length; i++)
            {
                //kuva i näytetään, jos p1life on suurempi kuin 1
                if (P1Life > i)
                {
                    p1Sticks[i].SetActive(true);//taulukon i:s kuva näytetään
                }
                else
                {
                    p1Sticks[i].SetActive(false);//taulukon i:s kuva piilotetaan
                }
            }
        }
    }
    public void PowerUpP2(int powerUp)
    {
        //lisätään yksi elämä
        if (P2Life < 5)
        {
            P2Life += powerUp;
            //tiputetaan yksi pää
            //silmukka, joka käy läpi taulukkoa
            //ja poistetaan viimeinen
            //i saa arvot 0,1,2,3,4
            for (int i = 0; i < p2Sticks.Length; i++)
            {
                //kuva i näytetään, jos p1life on suurempi kuin 1
                if (P1Life > i)
                {
                    p2Sticks[i].SetActive(true);//taulukon i:s kuva näytetään
                }
                else
                {
                    p2Sticks[i].SetActive(false);//taulukon i:s kuva piilotetaan
                }
            }
        }
    }

}
