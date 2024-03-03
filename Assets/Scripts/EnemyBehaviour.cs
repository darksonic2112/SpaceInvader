using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;

    private Enemy enemy;
    private int enemyRows = 6;
    private int enemyColumns = 3;

    void Start()
    {
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

    void Update()
    {
        
    }
}
