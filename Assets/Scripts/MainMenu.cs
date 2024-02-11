using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //string playerName;
    //public InputField nameInputField;
    public TMPro.TMP_InputField nameInputField;
    public TMPro.TMP_Text hiScoreText;

    private void Start()
    {
        PersistentData.Instance.LoadScore();
        hiScoreText.text = $"Best Score : {PersistentData.Instance.hiScoreName} : {PersistentData.Instance.hiScore}";
    }

    public void StartGame()
    {
        PersistentData.Instance.playerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }
}
