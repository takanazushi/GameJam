using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GoMenu : MonoBehaviour
{
    [Header("�|�[�Y��ʂ̐e����")]
    public GameObject PauseBack;
    private bool Active;

    private void Update()
    {
        PauseBack.SetActive(Active);
    }

    public void OnButton()
    {
        Active = !Active;
        //�^�C�}�[���~�߂�ꂽ�炤�ꂵ��
    }
}
