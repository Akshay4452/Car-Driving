using System.Collections;
using System.Collections.Generic;
using TMPro; // for using text mesh pro
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score;
    private int scoreMultiplier = 5;
    public const string highScoreKey = "HighScore";
    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            // score = player time in the game
            score += Time.deltaTime * scoreMultiplier;
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
        else
        {
            Debug.LogError("Add Text Mesh Pro component");
            return;
        }
        
    }
    private void OnDestroy() 
    {
        // this method will get invoked once we exit the game scene (game is finished)
        int currentHighScore = PlayerPrefs.GetInt(highScoreKey, 0);
        if(score > currentHighScore)
        {
            // if current score is higher than prev high score then it will update highScoreKey constant declared above
            PlayerPrefs.SetInt(highScoreKey, Mathf.FloorToInt(score));
        }    
    }
}
