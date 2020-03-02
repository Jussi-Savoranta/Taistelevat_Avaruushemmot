using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //käynnistettävän scenen eli tason nimi
    public string startLevel;
    
    public void NewGame()
    {
        //käynnistää uuden pelin
        SceneManager.LoadScene(startLevel);
    }
    public void ExitGame()
    {
        //lopettaa pelin
        Application.Quit();
    }
}
