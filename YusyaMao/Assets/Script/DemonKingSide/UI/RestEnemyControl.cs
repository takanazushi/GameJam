using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestEnemyControl : MonoBehaviour
{
    //text�w��p
    public Text Textflame;
    //�\������ϐ�
    private int Rest;
    private bool KO;

    private TimeControlScript time;

    // Start is called before the first frame update
    void Start()
    {
        Rest = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(KO)
        {
            Rest -= 1;
            KO = false;
        }
        Textflame.text = ("�c��" + Rest.ToString() + "�l");
    }

    public void OnButton()
    {
        KO = true;
    }

}
