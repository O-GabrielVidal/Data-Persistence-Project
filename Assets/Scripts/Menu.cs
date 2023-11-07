using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI namePlayer;
    public TextMeshProUGUI scoreMenu;

    private void Start()
    {
            //nameOfPlayer receive the name of best score for show that name on screen of menu
            SaveData.Instance.nameOfPlayer = SaveData.Instance.nameBestPlayer;
            scoreMenu.text = "Best Score: " + SaveData.Instance.nameBestPlayer + ": " + SaveData.Instance.points;
    }
    public void EnterNewName()
    {
            SaveData.Instance.EnterName(namePlayer.text);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        //Save the name of the best score when exit
        if (namePlayer.text != SaveData.Instance.nameBestPlayer)
        {
            SaveData.Instance.nameOfPlayer=SaveData.Instance.nameBestPlayer;
        }
        SaveData.Instance.SavePoints(SaveData.Instance.points);
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
