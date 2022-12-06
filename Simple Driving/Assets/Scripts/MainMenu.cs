using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System; // for DateTime

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private int maxEnergy;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private int energyRechargeDuration;
    private int energy;
    private const string EnergyKey = "Energy"; // 
    private const string EnergyReadyKey = "EnergyKey"; // this is where energy will be recharged
    // Start is called before the first frame update
    void Start()
    {
        // storing the high score
        int highScore = PlayerPrefs.GetInt(ScoreSystem.highScoreKey, 0);
        // Update the high score text
        highScoreText.text = $"High Score : {highScore}"; // similar to f-string in python
        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy); // setting by default energy as max energy (5)
        if (energy == 0)
        {
            // when energy is depleted, make player wait for certain time till it recharges
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, String.Empty);

            if(energyReadyString == String.Empty) {return;}

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if(DateTime.Now > energyReady)
            {
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);
            }
        }

        energyText.text = $"Play ({energy})";
    }

    public void Play()
    {
        // check the energy available
        if(energy < 1) {return;}
        // else Decrease the energy by 1
        energy --;

        PlayerPrefs.SetInt(EnergyKey, energy);

        if (energy == 0) 
        {
            // Refill the energy after 1 min
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
            Debug.Log("Energy depleted, please come back after 1 minute");
        }

        SceneManager.LoadScene("Scene_Game");
        
    }
}
