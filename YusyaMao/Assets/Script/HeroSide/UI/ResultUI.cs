using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI CountText;

    [SerializeField]
    TextMeshProUGUI TimeText;

    [SerializeField]
    EnemyManeger _EnemyManeger;

    private float Minutes;
    private float Seconds;

    private void OnEnable()
    {
        Seconds = (int)GameManager.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager.Instance.GetTime_limit / 60;

        CountText.text = _EnemyManeger.GetKnockOutCount.ToString();
        TimeText.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");

    }

}
