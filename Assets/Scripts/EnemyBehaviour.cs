using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemyRows = 6;
    private int enemyColumns = 3;

    void Start()
    {
        for (int enemyAmountColumn = 0; enemyAmountColumn <= enemyColumns; enemyAmountColumn++)
        {
            for (int enemyAmountRow = 0; enemyAmountRow <= enemyRows; enemyAmountRow++)
            {
                Vector3 position = new Vector3(-4 + enemyAmountRow, 3 - enemyAmountColumn, -0.5f);
                Instantiate(enemyPrefab, position, Quaternion.identity);
            }

        }
    }

    void Update()
    {
        
    }
}
