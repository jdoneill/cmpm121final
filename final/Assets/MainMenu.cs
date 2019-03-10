using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Update is called once per frame
    public void gameStart() // load first level
    {
        SceneManager.LoadScene("tutorial");
    }
    public void startMenu() //load main menu
    {
        SceneManager.LoadScene("startMenu");
    }
    public void levelReset() //load current level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void level2() // load first level
    {
        SceneManager.LoadScene("wallTutorial");
    }
}
