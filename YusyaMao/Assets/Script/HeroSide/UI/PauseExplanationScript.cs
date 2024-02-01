using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseExplanationScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [Header("代入先テキストボックス")]
    public Text TextField;

    [SerializeField, Space, Header("表示文章")]
    private string Text;

    public void OnMouseEnter()
    {
        TextField.text = Text;
        Debug.Log(Text);
    }



    public void OnMouseExit()
    {
        TextField.text = "ここに せつめい が ひょうじ されます";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TextField.text = Text;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextField.text = "せつめい";
    }
}
