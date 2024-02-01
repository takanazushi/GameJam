using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEnd_Hide : MonoBehaviour
{


    public void End()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);

        }
    }
}
