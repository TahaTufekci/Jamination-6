using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score;
    [SerializeField] TextMeshProUGUI scoreText;
    public void ScoreChange()
    {
        scoreText.SetText("Score: " + score);
    }
}
