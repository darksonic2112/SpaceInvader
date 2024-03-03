using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private Enemy enemy;
    private int enemyRows = 6;
    private int enemyColumns = 3;
    private int score;
    private int highScore;

    private string highScoreFilePath = "highscore.txt";

    void Start()
    {
        LoadHighScore();
        UpdateUI();

        Enemy.OnEnemyDied += HandleEnemyDied;
        for (int enemyAmountColumn = 0; enemyAmountColumn <= enemyColumns; enemyAmountColumn++)
        {
            for (int enemyAmountRow = 0; enemyAmountRow <= enemyRows; enemyAmountRow++)
            {
                Vector3 position = new Vector3(-4 + enemyAmountRow, 3 - enemyAmountColumn, -0.5f);
                if (enemyAmountColumn == 0)
                    Instantiate(enemyPrefab, position, Quaternion.identity);
                if (enemyAmountColumn == 1)
                    Instantiate(enemyPrefab1, position, Quaternion.identity);
                if (enemyAmountColumn == 2)
                    Instantiate(enemyPrefab2, position, Quaternion.identity);
                if (enemyAmountColumn == 3)
                    Instantiate(enemyPrefab3, position, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        UpdateUI();
    }

    void HandleEnemyDied(int pointsWorth)
    {
        score += pointsWorth;
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore();
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score.ToString("00000");
        highScoreText.text = "High Score: " + highScore.ToString("00000");
    }

    void SaveHighScore()
    {
        File.WriteAllText(highScoreFilePath, highScore.ToString());
    }

    void LoadHighScore()
    {
        if (File.Exists(highScoreFilePath))
        {
            string highScoreString = File.ReadAllText(highScoreFilePath);
            if (int.TryParse(highScoreString, out highScore))
            {
                Debug.Log("Loaded High Score: " + highScore);
            }
            else
            {
                Debug.LogError("Failed to parse high score from file.");
            }
        }
        else
        {
            Debug.Log("High score file does not exist. Creating new file.");
            SaveHighScore();
        }
    }
}
