using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuMGR : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject instructions;
    public GameObject lvlSelect;

    // Start is called before the first frame update
    void Start()
    {
        activeCanvas(true, false, false);
    }

    void activeCanvas(bool menu, bool controls, bool lvls)
    {
        mainMenu.SetActive(menu);
        instructions.SetActive(controls);
        lvlSelect.SetActive(lvls);
    }

    public void startMenu()
    {
        activeCanvas(true, false, false);
    }
    public void controlMenu()
    {
        activeCanvas(false, true, false);
    }
    public void lvlMenu()
    {
        activeCanvas(false, false, true);
    }





}
