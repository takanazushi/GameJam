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
    /// �N�[���_�E����true�F�N�[���_�E����
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
            //�N�[���_�E�����̉e�������Ă���
            CoolImage.fillAmount -= 1.0f / CoolTimeCount * Time.deltaTime;

            //�N�[���_�E���I������
            if (CoolImage.fillAmount <= 0f)
            {
                //StartFlg = false;
                CoolTimeFlg = false;
            }
        }
    }

    /// <summary>
    /// �N�[���_�E�����Z�b�g
    /// </summary>
    public void ReCooldown()
    {
        CoolImage.fillAmount = 1;
    }

    /// <summary>
    /// �N�[���_�E���J�n
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
