using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int currentScore;
    public int maxScore = 21;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        scoreText.text = "Score  " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score  " + currentScore;

        if (currentScore >= 240)
        {
            Victory();
        }
    }

    public void AddScore(int scoreValue)
    {
        currentScore += scoreValue;
        scoreText.text = "Score: " + scoreValue;
    }

    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }
}
