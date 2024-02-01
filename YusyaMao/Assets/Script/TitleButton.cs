using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    public void StartDragonGame()
    {
        SceneManager.LoadScene("DemonSide");
    }

    public void StartHeroGame()
    {
        SceneManager.LoadScene("HeroGame");
    }

    public void EndGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

        #else
            Application.Quit();

        #endif
    }
}
