using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameManager gameManager;
    private int oldScore;
    Text text;

    // Use this for initialization
    void Start()
    {
        if (gameManager == null)
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.score != oldScore)
        {
            oldScore = gameManager.score;
            ChangeScoreUI();
        }
    }

    private void ChangeScoreUI()
    {
        text.text = "Score: " + gameManager.score.ToString();
    }
}
