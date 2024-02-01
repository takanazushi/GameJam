using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private PlayerData playerData;

    //Sceneが有効になった時
    private void OnEnable()
    {
        //自動的にMethod呼び出し
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Sceneが無効になった時
    private void OnDisable()
    {
        //自動的にMethod削除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Sceneが読み込まれる度に呼び出し
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(SceneManager.GetActiveScene().name== "DragonGameScene")
        {
            playerData.AttackRange = 1;
            playerData.ArrackPower = 1;
            playerData.CanUseSKill = true;
        }

    }
}
