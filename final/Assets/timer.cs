using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{

    public Camera Red;
    public GameObject RedObjs;
    public Camera Green;
    public GameObject GreenObjs;
    public Camera Blue;
    public GameObject BlueObjs;
    private bool red;
    private bool green;
    private bool blue;
    float timeLeft;
    float timeTotal = 3;
    float uiTime;
    public Text UIText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeTotal;
        colorSwitch(true, false, false);//make it RED
    }

    void colorSwitch(bool R, bool G, bool B)
    {
        Red.enabled = R;
        Green.enabled = G;
        Blue.enabled = B;
        RedObjs.SetActive(R);
        GreenObjs.SetActive(G);
        BlueObjs.SetActive(B);
        timeLeft = timeTotal;

    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft-= Time.deltaTime;
            uiTime = Mathf.RoundToInt(timeLeft);
            UIText.text = "Color change in " + uiTime;
        }
        else
        {
            if (Blue.enabled)
            {
                colorSwitch(true, false, false);//make it RED
            }
            else if (Red.enabled)//|| Input.GetKey(KeyCode.E))
            {
                colorSwitch(false, true, false);//I'll try to make it easier bein green
            }
            else if (Green.enabled)//|| Input.GetKey(KeyCode.F))
            {
                colorSwitch(false, false, true);//blue chu kachu
            }

        }
    }
}
