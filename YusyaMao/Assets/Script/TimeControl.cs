using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public TextMeshProUGUI TextFlame;
    private float Minutes;
    private float Seconds;

    // Start is called before the first frame update
    void Start()
    {
        Seconds = (int)GameManager.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager.Instance.GetTime_limit / 60;
    }

    // Update is called once per frame
    void Update()
    {
        Seconds = (int)GameManager.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager.Instance.GetTime_limit / 60;

        TextFlame.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");
    }
}
