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
    /// �������ԁA�b
    /// </summary>
    [SerializeField]
    float Time_limit;

    /// <summary>
    /// �������Ԃ��v�����邩true:�v������
    /// </summary>
    [SerializeField]
    bool IsTime_Count;

    public float GetTime_limit
    {
        get { return Time_limit;}
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
