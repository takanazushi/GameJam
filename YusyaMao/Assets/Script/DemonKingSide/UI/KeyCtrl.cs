using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sp = new Sprite[27];

    public void ChangeSprite(int no)
    {
        if (no > 26|| no < 0)
        {
            no = 0;
        }

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sp[no];
    }
}
