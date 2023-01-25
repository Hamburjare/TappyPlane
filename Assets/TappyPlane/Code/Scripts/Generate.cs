using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Generates the obstacles
public class Generate : MonoBehaviour
{
    [SerializeField]
    GameObject rockPrefab_ = null;

    private void Start()
    {
        InvokeRepeating("GenerateObstacles", 1f, 2f);
    }

    void GenerateObstacles()
    {
        Instantiate(rockPrefab_, RandomPosition(), Quaternion.identity);
    }

    Vector2 RandomPosition()
    {
        float y = Random.Range(-2.5f, 1.5f);
        return new Vector2(5, y);
    }
}
