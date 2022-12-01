using System.Collections;
using System.Collections.Generic;
using TMPro; // for using text mesh pro
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private float score;
    

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            // score = player time in the game
            score += Time.deltaTime;
            scoreText.text = Mathf.Floor(score).ToString();
        }
        else
        {
            Debug.LogError("Add Text Mesh Pro component");
            return;
        }
        
    }
}
