using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCtrl : MonoBehaviour
{
    [SerializeField]
    private Sprite[] sp = new Sprite[26];

    public void ChangeSprite(int no)
    {
        if (no > 25 || no < 0)
        {
            no = 0;
        }

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sp[no];
    }
}
