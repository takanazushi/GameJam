using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    [Header("�|�[�Y�e")]
    public GameObject PauseBack;

    [Header("���ʉ�")]
    public AudioClip Decision;
    public AudioClip Exit;
    
    private bool Active;

    AudioSource audioSource;

    [SerializeField]
    UnityEvent StartEvent;
    [SerializeField]
    UnityEvent StopEvent;

    private void Start()
    {
        Active = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PauseBack.SetActive(Active);
    }

    public void OnButton()
    {

        Active = !Active;

        if (Active)
        {
            //�Q�[���ꎞ��~
            GameManager.Instance.GameStop();
            StopEvent.Invoke();
            audioSource.PlayOneShot(Exit);

        }
        else
        {
            //�Q�[���ĊJ
            GameManager.Instance.GameStart();
            StartEvent.Invoke();
            audioSource.PlayOneShot(Decision);

        }

        PauseBack.SetActive(Active);
    }

}
