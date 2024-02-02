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

        // 死んだ敵の数を表示
        enemyDieCountText.text = "のこり " + (playerData.MaxEnemyCount - deadEnemyCount)+"にん";

        // 全ての敵が死んだらゲームクリア
        if (playerData.MaxEnemyCount - deadEnemyCount == 0)
        {
            playerData.ClearFlag = true;
            GameManager.Instance.IsGetTime_flg = false;
        }
    }
}
