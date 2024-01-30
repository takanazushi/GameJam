using TMPro;
using UnityEngine;

public class RestEnemyControl : MonoBehaviour
{
    //textéwíËóp
    public TextMeshProUGUI Textflame;
    //ï\é¶Ç∑ÇÈïœêî
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
        Textflame.text = ("ÇÃÇ±ÇË" + Rest.ToString() + "Ç…ÇÒ");
    }

    public void OnButton()
    {
        KO = true;
    }

}
