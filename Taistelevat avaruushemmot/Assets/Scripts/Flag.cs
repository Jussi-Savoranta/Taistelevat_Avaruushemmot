using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    //tason nimi, jolle siirrytään
    public string levelName;

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
        //osuiko pelihahmo1 lippuun
        if (collision.CompareTag("Player1"))
        {
            //pelihahmo1 osui lippuun, joten poistetaan se
            //ja siirrytään seuraavaan tasoon
            Destroy(gameObject);
            NextLevel(levelName);
        }

        if (collision.CompareTag("Player2"))
        {
            //pelihahmo2 osui lippuun, joten poistetaan se
            //ja siirrytään seuraavaan tasoon
            Destroy(gameObject);
            NextLevel(levelName);
        }
    }
    private void NextLevel(string levelName)
    {
        //siirrytään toiselle tasolle
        SceneManager.LoadScene(levelName);
    }
}
