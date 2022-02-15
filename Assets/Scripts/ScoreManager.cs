using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HighScoreText;
    float SavedHighScore;
    float HighScore;
    public static string playernamestr;
    public Text playername;

    void Start()
    {
        playername.text = playernamestr;
        SavedHighScore = PlayerPrefs.GetFloat("HighScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = Target.howManyKills.ToString();
        HighScoreText.text = SavedHighScore.ToString();

        if (Target.howManyKills > HighScore)
        {
            HighScore = Target.howManyKills;
        }
        if (HighScore > SavedHighScore)
        {
            SavedHighScore = HighScore;
            PlayerPrefs.SetFloat("HighScore", HighScore);
        }
    }
}
