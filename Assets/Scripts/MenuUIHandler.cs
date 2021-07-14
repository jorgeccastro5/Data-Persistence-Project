using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void NewPlayerName()
    {
        string name = nameInput.text;

        if (name != null && name.Length > 0)
        {
            GameManager.Instance.player = name;
        }
        else
        {
            GameManager.Instance.player = "Player";
        }
    }

    public void StartNew()
    {
        NewPlayerName();
        SceneManager.LoadScene("main");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
