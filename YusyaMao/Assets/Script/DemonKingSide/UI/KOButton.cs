using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KOButton : MonoBehaviour
{
    public RestEnemyControl KO;

    public void KOBraver()
    {
        KO.OnButton();
    }
}
