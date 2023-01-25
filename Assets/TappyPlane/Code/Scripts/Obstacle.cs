using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    Vector2 obstacleVelocity = new(-4, 0);
    [SerializeField]
    float range = 2f;

    private void Start() {
        GetComponent<Rigidbody2D>().velocity = obstacleVelocity;

        float y = Random.Range(-range, range);
        transform.position = new Vector2(transform.position.x, y);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "ObstacleDeleter")
            Destroy(gameObject);
    }
}
