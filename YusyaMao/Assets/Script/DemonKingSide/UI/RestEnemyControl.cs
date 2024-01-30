using TMPro;
using UnityEngine;

public class RestEnemyControl : MonoBehaviour
{
    //text指定用
    public TextMeshProUGUI Textflame;
    //表示する変数
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
        Textflame.text = ("のこり" + Rest.ToString() + "にん");
    }

    public void OnButton()
    {
        KO = true;
    }

}
