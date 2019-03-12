using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void startMenu() //load main menu
    {
        SceneManager.LoadScene("startMenu");
    }
    public void restart() //load current level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void level1() // load level 1
    {
        SceneManager.LoadScene("tutorial");
    }
    public void level2() // load level 2
    {
        SceneManager.LoadScene("wallTutorial");
    }
}
