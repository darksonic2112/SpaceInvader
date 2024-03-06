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
    public GameObject baricades;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private List<GameObject> enemies = new List<GameObject>();
    private Enemy enemy;
    private int enemyRows = 6;
    private int enemyColumns = 3;
    private int score;
    private int highScore;
    private int maxBaricades = 10;
    private int enemyAmount;

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
                {
                    GameObject enemyInstance = Instantiate(enemyPrefab, position, Quaternion.identity);
                    enemies.Add(enemyInstance);
                }

                if (enemyAmountColumn == 1)
                {
                    GameObject enemyInstance = Instantiate(enemyPrefab1, position, Quaternion.identity);
                    enemies.Add(enemyInstance);
                }

                if (enemyAmountColumn == 2)
                {
                    GameObject enemyInstance = Instantiate(enemyPrefab2, position, Quaternion.identity);
                    enemies.Add(enemyInstance);
                }

                if (enemyAmountColumn == 3)
                {
                    GameObject enemyInstance = Instantiate(enemyPrefab3, position, Quaternion.identity);
                    enemies.Add(enemyInstance);
                }
            }
        }

        for (int baricadeAmount = 0; baricadeAmount <= maxBaricades; baricadeAmount += 2)
        {
            Vector3 baricadePosition1 = new Vector3(-5 + baricadeAmount, -3.25f, -0.5f);
            Vector3 baricadePosition2 = new Vector3(-5 + baricadeAmount + 0.25f, -3.25f, -0.5f);
            Vector3 baricadePosition3 = new Vector3(-5 + baricadeAmount, -3f, -0.5f);
            Vector3 baricadePosition4 = new Vector3(-5 + baricadeAmount + 0.25f, -3f, -0.5f);
            Instantiate(baricades, baricadePosition1, Quaternion.identity);
            Instantiate(baricades, baricadePosition2, Quaternion.identity);
            Instantiate(baricades, baricadePosition3, Quaternion.identity);
            Instantiate(baricades, baricadePosition4, Quaternion.identity);
        } 
        //bool reachedRightBoundary = false;
        //bool reachedLeftBoundary = false;
        //
        //foreach (GameObject enemyInvader in enemies)
        //
        //   enemyInvader.transform.Translate(Vector3.right * Time.deltaTime);
        //   
        //   if (enemyInvader.transform.position.x >= 7f)
        //   {
        //       reachedRightBoundary = true;
        //       break;
        //   }
        //   if (enemyInvader.transform.position.x <= -7f)
        //   {
        //       reachedLeftBoundary = true;
        //       break;
        //   }
        //
        //
        //if (reachedRightBoundary)
        //
        //   foreach (GameObject enemyInvader in enemies)
        //   {
        //       enemyInvader.transform.Translate(Vector3.left * Time.deltaTime);
        //   }
        //
        //if (reachedLeftBoundary)
        //
        //   foreach (GameObject enemyInvader in enemies)
        //   {
        //       enemyInvader.transform.Translate(Vector3.right * Time.deltaTime);
        //   }
        //
    }
    void Update()
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
