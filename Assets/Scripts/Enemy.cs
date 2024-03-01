using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 3;
    public delegate void EnemyDied(int pointsWorth);
    public static event EnemyDied OnEnemyDied;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);

        OnEnemyDied.Invoke(points);

        Destroy(gameObject);
    }
}
