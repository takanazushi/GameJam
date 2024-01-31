using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeControlScript : MonoBehaviour
{
    /// <summary>
    /// ���͐�
    /// </summary>
    [Header("���͐�e�L�X�g�{�b�N�X")]
    public Text TextFlame;

    /// <summary>
    /// ����
    /// </summary>
    private float Minutes;

    /// <summary>
    /// �b��
    /// </summary>
    private float Seconds;

    // Start is called before the first frame update
    void Start()
    {
        //�����E�b������o��
        Seconds = GameManager2.Instance.GetTime_limit % 60;
        Minutes = GameManager2.Instance.GetTime_limit / 60;
    }

    // Update is called once per frame
    void Update()
    {
        //�����E�b������o��
        Seconds = (int)GameManager2.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager2.Instance.GetTime_limit / 60;

        //��������
        TextFlame.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");
    }

}
