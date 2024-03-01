using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;
  public Transform shottingOffset;

    private void Start()
    {
        Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
    }

    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    }
    void EnemyOnOnEnemyDied(int pointsWorth)
    {
        Debug.Log($"Player received 'EnemyDied' worth {pointsWorth}");
    }
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }
}
