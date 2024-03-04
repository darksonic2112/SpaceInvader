using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baricades : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
