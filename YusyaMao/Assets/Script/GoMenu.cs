using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    [Header("ポーズ親")]
    public GameObject PauseBack;

    [Header("効果音")]
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
            //ゲーム一時停止
            GameManager.Instance.GameStop();
            StopEvent.Invoke();
            audioSource.PlayOneShot(Exit);

        }
        else
        {
            //ゲーム再開
            GameManager.Instance.GameStart();
            StartEvent.Invoke();
            audioSource.PlayOneShot(Decision);

        }

        PauseBack.SetActive(Active);
    }

}
