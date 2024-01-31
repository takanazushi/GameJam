using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    public GameObject PauseBack;
    private bool Active = false;

    private void Update()
    {
        //PauseBack.SetActive(Active);
    }

    public void OnButton()
    {
        //ƒQ[ƒ€‘€ì‰Â”\
        GameManager.Instance.GetGameOperationFlg = Active;
        //ƒQ[ƒ€ŠÔ’â~
        GameManager.Instance.IsGetTime_flg = Active;

        Active = !Active;


        PauseBack.SetActive(Active);
        //GameManager.Instance.i
    }
}
