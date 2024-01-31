using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    [Header("�|�[�Y�e")]
    public GameObject PauseBack;

    [Header("���ʉ�")]
    public AudioClip Decision;
    public AudioClip Exit;
    
    private bool Active;

    private void Start()
    {
        Active = false;
    }

    private void Update()
    {
        PauseBack.SetActive(Active);
    }

    public void OnButton()
    {
        if (Active == false)
        {
            GetComponent<AudioSource>().PlayOneShot(Decision);
        }
        else if (Active == true)
        {
            GetComponent<AudioSource>().PlayOneShot(Exit);
        }


        Active = !Active;
    }

}
