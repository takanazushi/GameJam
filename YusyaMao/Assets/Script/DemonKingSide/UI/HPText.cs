using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPText : MonoBehaviour
{
    [SerializeField, Header("HP表記マネージャ")]
    private Number_test HPManager;

    [SerializeField, Header("Key表記マネージャ")]
    private KeyText keyTextManager;


    private GameObject parent;
    EnemyDamage enemyDamage;

    int keyNumber = 0;

    bool flag = true;

    // AlphabetとKeyNumberの対応関係を格納するDictionary
    Dictionary<string, int> keyMap = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        enemyDamage=parent.GetComponent<EnemyDamage>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDamage.KeyName != null && flag) 
        {
            KeyTextNumber();
            keyTextManager.TextInit(keyNumber);
            flag = false;
        }

        HPManager.DestroyObject(0f);
        HPManager.Init(enemyDamage.GetHP,0);
    }

    private void KeyTextNumber()
    {
        switch (enemyDamage.KeyName)
        {
            case "A":
                keyNumber = 0;
                break;
            case "B":
                keyNumber = 1;
                break;

            case "C":
                keyNumber = 2;
                break;
            case "D":
                keyNumber = 3;
                break;

            case "E":
                keyNumber = 4;
                break;
            case "F":
                keyNumber = 5;
                break;

            case "G":
                keyNumber = 6;
                break;
            case "H":
                keyNumber = 7;
                break;

            case "I":
                keyNumber = 8;
                break;
            case "J":
                keyNumber = 9;
                break;

            case "K":
                keyNumber = 10;
                break;
            case "L":
                keyNumber = 11;
                break;

            case "N":
                keyNumber = 12;
                break;
            case "M":
                keyNumber = 13;
                break;

            case "O":
                keyNumber = 14;
                break;
            case "P":
                keyNumber = 15;
                break;

            case "Q":
                keyNumber = 16;
                break;
            case "R":
                keyNumber = 17;
                break;

            case "S":
                keyNumber = 18;
                break;
            case "T":
                keyNumber = 19;
                break;

            case "U":
                keyNumber = 20;
                break;
            case "V":
                keyNumber = 21;
                break;

            case "W":
                keyNumber = 22;
                break;
            case "X":
                keyNumber = 23;
                break;

            case "Y":
                keyNumber = 24;
                break;
            case "Z":
                keyNumber = 25;
                break;

            case "Click":
                keyNumber = 26;
                break;


            default:
                keyNumber = -1;
                break;
        }

        //Debug.LogAssertion(keyNumber);
    }
}
