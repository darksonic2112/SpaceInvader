using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 3;
    public delegate void EnemyDied(int pointsWorth);
    public static event EnemyDied OnEnemyDied;
    RaycastHit hit;

    void OnCollisionEnter(Collision other)
    {
            Destroy(gameObject);
            Destroy(other.gameObject);
            OnEnemyDied.Invoke(points);
    }
}
