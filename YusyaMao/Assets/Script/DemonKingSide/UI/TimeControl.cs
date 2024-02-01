using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public Text TextFlame;
    private float Minutes;
    private float Seconds;

    // Start is called before the first frame update
    void Start()
    {
        Seconds = (int)GameManager2.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager2.Instance.GetTime_limit / 60;
    }

    // Update is called once per frame
    void Update()
    {
        Seconds = (int)GameManager2.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager2.Instance.GetTime_limit / 60;

        TextFlame.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");
    }
}
