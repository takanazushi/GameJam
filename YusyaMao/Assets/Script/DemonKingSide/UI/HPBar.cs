using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    private Image image;

    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private EnemyDamage damage;

    private RectTransform myRectTfm;

    float fillAmount;

    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        fillAmount = 1.0f;
        image.fillAmount = fillAmount;
    }

    void Update()
    {
        // 自身の向きをカメラに向ける
        //myRectTfm.LookAt(Camera.main.transform);

        fillAmount =(float)damage.GetHP / damage.GetStartHP;

        image.fillAmount = fillAmount;
    }

}
