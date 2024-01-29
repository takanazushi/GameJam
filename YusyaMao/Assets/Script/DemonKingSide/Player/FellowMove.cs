using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowMove : MonoBehaviour
{
    [SerializeField, Header("ˆÚ“®‘¬“x")]
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }
}
