using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DieCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI enemyDieCountText;

    [SerializeField]
    private PlayerDoragonData playerData;

    [SerializeField]
    private GameObject enemyParent;

    private int EnemyDieCount;
    
    private void Start()
    {
        EnemyDieCount = 0;
        Debug.Log(enemyDieCountText);
    }

    // Update is called once per frame
    void Update()
    {
        int deadEnemyCount = 0;
        for (int i = 0; i < enemyParent.transform.childCount; i++)
        {
            Transform child = enemyParent.transform.GetChild(i);
            if (!child.gameObject.activeSelf)
            {
                deadEnemyCount++;
            }
        }

        playerData.EnemyDieCount = deadEnemyCount;

        // Ž€‚ñ‚¾“G‚Ì”‚ð•\Ž¦
        enemyDieCountText.text = "‚Ì‚±‚è " + (playerData.MaxEnemyCount - deadEnemyCount)+"‚É‚ñ";

        // ‘S‚Ä‚Ì“G‚ªŽ€‚ñ‚¾‚çƒQ[ƒ€ƒNƒŠƒA
        if (playerData.MaxEnemyCount - deadEnemyCount == 0)
        {
            playerData.ClearFlag = true;
            GameManager.Instance.IsGetTime_flg = false;
        }
    }
}
