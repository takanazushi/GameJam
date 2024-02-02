using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ResultGet : MonoBehaviour
{
    [SerializeField]
    private GameObject ResultUI;

    [SerializeField]
    private TextMeshProUGUI EenemyDie;

    [SerializeField]
    private TextMeshProUGUI Time;

    [SerializeField]
    private PlayerDoragonData playerData;

    // Start is called before the first frame update
    void Start()
    {
        ResultUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.ClearFlag || playerData.GameOverFlag)
        {
            ResultUI.SetActive(true);

            int Seconds = (int)GameManager.Instance.GetTime_limit % 60;
            int Minutes = (int)GameManager.Instance.GetTime_limit / 60;

            EenemyDie.text = playerData.EnemyDieCount.ToString();
            Time.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");
        }
    }
}
