using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeControlScript : MonoBehaviour
{    
    //ïœêî
    public Text TextFlame;
    private float Minutes;
    private float Seconds;

    // Start is called before the first frame update
    void Start()
    {
        Seconds = GameManager.Instance.GetTime_limit % 60;
        Minutes = GameManager.Instance.GetTime_limit / 60;

        Debug.Log(Seconds);
        Debug.Log(Minutes);
    }

    // Update is called once per frame
    void Update()
    {
        Seconds = (int)GameManager.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager.Instance.GetTime_limit / 60;

        TextFlame.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");

        Debug.Log(Minutes.ToString("00") + ":" + Seconds.ToString("00"));
    }

}
