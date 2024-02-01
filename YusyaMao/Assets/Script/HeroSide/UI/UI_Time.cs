using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Žg‚Á‚Ä‚È‚¢‚Å‚·
public class UI_Time : MonoBehaviour
{
    Text UI_text;

    private void Awake()
    {
        UI_text= GetComponent<Text>();
    }

    void Update()
    {
        UI_text.text=
        GameManager.Instance.GetTime_limit.ToString("N1"); 
    }
}
