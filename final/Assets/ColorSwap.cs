using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSwap : MonoBehaviour
{
    //camera
    Camera start;
    public Camera Red;
    public GameObject RedObjs;
    public Camera Green;
    public GameObject GreenObjs;
    public Camera Blue;
    public GameObject BlueObjs;
    private bool red;
    private bool green;
    private bool blue;
    public Text currentColor;

    // Start is called before the first frame update
    void Start()
    {
        start = Camera.main;
        start.enabled = true;
        colorSwitch(false, false, false);
        currentColor.text = "Press R, G or B to activate different platforms!";

    }

    void colorSwitch(bool R, bool G, bool B)
    {
        Red.enabled = R;
        Green.enabled = G;
        Blue.enabled = B;
        RedObjs.SetActive(R);
        GreenObjs.SetActive(G);
        BlueObjs.SetActive(B);
    }

    // Update is called once per frame
    void Update()
    {
        //Camera logic
        red = (Red.enabled) ? true : false;
        green = (Green.enabled) ? true : false;
        blue = (Blue.enabled) ? true : false;

        if (Input.GetKey(KeyCode.R))
        {
            colorSwitch(true, false, false);//make it RED
            currentColor.text = "Red";
        }

        if (Input.GetKey(KeyCode.G))//|| Input.GetKey(KeyCode.E))
        {
            colorSwitch(false, true, false);//I'll try to make it easier bein green
            currentColor.text = "Green";
        }

        if (Input.GetKey(KeyCode.B))//|| Input.GetKey(KeyCode.F))
        {
            colorSwitch(false, false, true);//blue chu kachu
            currentColor.text = "Blue";
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!red && !blue && !green)
            {
                colorSwitch(true, false, false);//make it RED
                currentColor.text = "Red";
            }
            else if (red)//if red is go green
            {
                colorSwitch(false, true, false);//I'll try to make it easier bein green
                currentColor.text = "Green";
            }
            else if (green)//if green go to blue
            {
                colorSwitch(false, false, true);//blue chu kachu
                currentColor.text = "Blue";
            }
            else if (blue)//if blue is enabled go red
            {
                colorSwitch(true, false, false);//make it RED
                currentColor.text = "Red";
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!red && !blue && !green)
            {
                colorSwitch(false, false, true);//blue chu kachu
                currentColor.text = "Blue";
            }
            else if (red)//if red is go blue
            {
                colorSwitch(false, false, true);//blue chu kachu
                currentColor.text = "Blue";
            }
            else if (green)//if green go to red
            {
                colorSwitch(true, false, false);//make it RED
                currentColor.text = "Red";
            }
            else if (blue)//if blue is enabled go green
            {
                colorSwitch(false, true, false);//I'll try to make it easier bein green
                currentColor.text = "Green";
            }
        }
    }

}
