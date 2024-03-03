using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 40;
    public delegate void EnemyDied(int pointsWorth);
    public static event EnemyDied OnEnemyDied;
    RaycastHit hit;

    void OnCollisionEnter(Collision other)
    {
        //GetPointValue(gameObject.transform.position.y);
        OnEnemyDied.Invoke(points);
        Destroy(gameObject);
        Destroy(other.gameObject); ;
    }

    void GetPointValue(float distance)
    {
    }
}
