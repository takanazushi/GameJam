using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �C���X�^���X
    /// </summary>
    public static GameManager Instance;

    /// <summary>
    /// �Q�[������\�t���Otrue:�\
    /// </summary>
    bool GameOperationFlg;
    public bool GetGameOperationFlg
    {
        get { return GameOperationFlg; }
        set { GameOperationFlg = value; }
    }

    /// <summary>
    /// �J�n�b��
    /// </summary>
    [SerializeField]
    float Time_limit_Start;

    /// <summary>
    /// �������ԁA�c��b��
    /// </summary>
    float Time_limit;

    /// <summary>
    /// �������Ԃ��v�����邩true:�v������
    /// </summary>
    [SerializeField]
    bool IsTime_Count;

    /// <summary>
    /// �c�萧�����Ԏ擾
    /// </summary>
    public float GetTime_limit
    {
        get { return Time_limit;}
    }    

    /// <summary>
    /// �o�ߎ��Ԏ擾
    /// </summary>
    public float Get_ElapsedTime
    {
        get { return Time_limit_Start- Time_limit; }
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Time_limit = Time_limit_Start;
    }

    private void FixedUpdate()
    {
        if (IsTime_Count)
        {
            //�o�ߎ��Ԃ𑝉�
            Time_limit -= Time.deltaTime;

            if (Time_limit <= 0.0f)
            {
                Time_limit = 0.0f;
                IsTime_Count = false;

            }

        }

    }


}
