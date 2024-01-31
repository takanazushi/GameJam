using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    public GameObject PauseBack;
    private bool Active = false;

    [SerializeField]
    UnityEvent StopEvent;
    [SerializeField]
    UnityEvent StartEvent;


    private void Update()
    {
        //PauseBack.SetActive(Active);
    }

    public void OnButton()
    {
        Active = !Active;

        if (Active)
        {
            //�Q�[���ꎞ��~
            GameManager.Instance.GameStop();
            StopEvent.Invoke();
        }
        else
        {
            //�Q�[���ĊJ
            GameManager.Instance.GameStart();
            StartEvent.Invoke();
        }

        PauseBack.SetActive(Active);

    }
}
