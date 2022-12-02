using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText; 
    // Start is called before the first frame update
    void Start()
    {
        // storing the high score
        int highScore = PlayerPrefs.GetInt(ScoreSystem.highScoreKey, 0);
        // Update the high score text
        highScoreText.text = $"High Score : {highScore}";
    }

    public void Play()
    {
        SceneManager.LoadScene("Scene_Game");
    }
}
