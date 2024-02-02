using UnityEngine;
using TMPro;

public class TimeControlScript : MonoBehaviour
{    
    //ïœêî
    public TextMeshProUGUI TextFlame;
    private float Minutes;
    private float Seconds;

    // Start is called before the first frame update
    void Start()
    {
        //Seconds = GameManager2.Instance.GetTime_limit % 60;
        //Minutes = GameManager2.Instance.GetTime_limit / 60;

        Debug.Log(Seconds);
        Debug.Log(Minutes);
    }

    // Update is called once per frame
    void Update()
    {
        //Seconds = (int)GameManager2.Instance.GetTime_limit % 60;
        //Minutes = (int)GameManager2.Instance.GetTime_limit / 60;

        TextFlame.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");

        //Debug.Log(Minutes.ToString("00") + ":" + Seconds.ToString("00"));
    }

}
