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
        //�Q�[������\
        GameManager.Instance.GetGameOperationFlg = Active;
        //�Q�[�����Ԓ�~
        GameManager.Instance.IsGetTime_flg = Active;

        Active = !Active;


        PauseBack.SetActive(Active);
        //GameManager.Instance.i
    }
}
