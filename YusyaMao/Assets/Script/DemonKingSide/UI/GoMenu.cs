using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    [Header("ポーズ画面の親を代入")]
    public GameObject PauseBack;
    private bool Active;

    private void Update()
    {
        PauseBack.SetActive(Active);
    }

    public void OnButton()
    {
        Active = !Active;
        //タイマーを止められたらうれしい
    }
}
