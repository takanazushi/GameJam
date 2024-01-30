using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroll : MonoBehaviour
{
    private float maxLength = 1f;
    private string propName = "_MainTex";

    [SerializeField]
    private Vector2 offsetSpeed;

    private Material material;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        if (image != null)
        {
            material = image.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (material)
        {
            float x = Mathf.Repeat(Time.time * offsetSpeed.x, maxLength);
            float y = Mathf.Repeat(Time.time * offsetSpeed.y, maxLength);

            Vector2 offset = new Vector2(x, y);
            material.SetTextureOffset(propName, offset);
        }
    }

    private void OnDestroy()
    {
        if (material)
        {
            material.SetTextureOffset(propName, Vector2.zero);
        }
    }
}
