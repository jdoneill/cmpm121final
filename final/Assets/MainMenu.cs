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
        SceneManager.LoadScene("timerTutorial");
    }
    public void level2() // load level 2
    {
        SceneManager.LoadScene("tutorial");
    }
    public void level3() // load level 3
    {
        SceneManager.LoadScene("doubleJumpTutorial");
    }
    public void level4() // load level 4
    {
        SceneManager.LoadScene("wallTutorial");
    }
    public void level5() // load level 5
    {
        SceneManager.LoadScene("movingPlats");
    }
}
