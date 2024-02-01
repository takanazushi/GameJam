using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("“–‚½‚Á‚½");

        if (collision.gameObject.CompareTag("Line"))
        {
            speed = 0;
            Debug.Log("‘Ø—¯");
        }
    }
}
