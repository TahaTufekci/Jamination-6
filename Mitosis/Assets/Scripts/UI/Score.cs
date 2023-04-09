using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    [SerializeField] TextMeshProUGUI[] scoreText;
    public void ScoreChange()
    {
        for (int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].SetText("Score: " + score);
        }
    }
}
