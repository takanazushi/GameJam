using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CoolTime : MonoBehaviour
{
    public Image CoolImage;
    public float CoolTimeCount;

    /// <summary>
    /// クールダウン中true：クールダウン中
    /// </summary>
    public bool CoolTimeFlg;

    // Start is called before the first frame update
    void Start()
    {
        CoolTimeFlg = false;

        CoolImage.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.GetGameOperationFlg)
        {
            return;
        }

        if (CoolTimeFlg)
        {
            //クールダウン中の影を消していく
            CoolImage.fillAmount -= 1.0f / CoolTimeCount * Time.deltaTime;

            //クールダウン終了判定
            if (CoolImage.fillAmount <= 0f)
            {
                //StartFlg = false;
                CoolTimeFlg = false;
            }
        }
    }

    /// <summary>
    /// クールダウンリセット
    /// </summary>
    public void ReCooldown()
    {
        CoolImage.fillAmount = 1;
    }

    /// <summary>
    /// クールダウン開始
    /// </summary>
    public void StartCooldown()
    {
        if (!CoolTimeFlg)
        {
            CoolTimeFlg = true;
            CoolImage.fillAmount = 1;
        }
    }
}
