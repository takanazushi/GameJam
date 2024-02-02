using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar_Player : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private PlayerDoragonData playerData;

    private RectTransform myRectTfm;

    float fillAmount;

    int maxHP;

    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        maxHP = playerData.PlayerHP;
        fillAmount = 1.0f;
        image.fillAmount = fillAmount;
    }

    void Update()
    {
        fillAmount = (float)playerData.PlayerHP / maxHP;

        image.fillAmount = fillAmount;

        if (playerData.PlayerHP <= 0)
        {
            playerData.GameOverFlag = true;
            GameManager.Instance.IsGetTime_flg = false;
        }
    }
}
