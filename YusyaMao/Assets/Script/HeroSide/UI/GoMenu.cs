using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    public GameObject PauseBack;
    private bool Active;

    private void Update()
    {
        PauseBack.SetActive(Active);
    }

    public void OnButton()
    {
        Active = !Active;
        GameManager.Instance.i
    }
}
