using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestEnemyControl : MonoBehaviour
{
    /// <summary>
    /// text�w��p
    /// </summary>
    [Header("���͐�e�L�X�g�{�b�N�X")]
    public Text Textflame;

    /// <summary>
    /// �c��l��
    /// </summary>
    [Header("�c��l��")]
    public int Rest;

    /// <summary>
    /// KO�t���O
    /// </summary>
    private bool KO;

    // Update is called once per frame
    void Update()
    {
        //KO������
        if(KO)
        {
            Rest -= 1;
            KO = false;
        }

        //�c��l���\���@�t�H���g���Ђ炪�Ȃ̂ݑΉ��̂��߂Ђ炪�Ȃŕ\��
        Textflame.text = ("�̂���" + Rest.ToString() + "�ɂ�");
    }

    /// <summary>
    /// �G���j�����s�ppublic���]�b�g
    /// </summary>
    public void BraverKO()
    {
        KO = true;
    }

}
